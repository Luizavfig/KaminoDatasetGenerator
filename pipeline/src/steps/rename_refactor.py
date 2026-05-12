import json, random, keyword, builtins, ast, textwrap

import libcst as cst
from libcst.metadata import ScopeProvider, ParentNodeProvider, MetadataWrapper
from src.config import *


def rename_refactor_clones(input_file=FINAL_DATASET, output_file=FINAL_DATASET_REF):
    print("Clone rename refactoring process started")
    with open(input_file, "r", encoding="utf-8") as f:
        dataset = json.load(f)

    for i, item in enumerate(dataset):
        print(f"Refactoring clones for entry {item['id']}")
        for j, clone in enumerate(item.get("clones", [])):
            try:
                seed = hash(f"{item['id']}_{j}") & 0xffffffff
                clone["code"] = _transform_code(clone["code"], seed)
            except cst.ParserSyntaxError:
                try:
                    fixed_code = _fix_syntax(clone["code"])
                    clone["code"] = _transform_code(fixed_code, seed)
                except Exception as e:
                    print(f"Failed {item.get('id')} clone {j} after fix attempt: {e}")
                    print("ORIGINAL CODE:")
                    print(clone["code"])
                    print("FIXED CODE:")
                    print(fixed_code)

    with open(output_file, "w", encoding="utf-8") as f:
        json.dump(dataset, f, indent=2)
    print(f"Finished rename refactoring process, clones saved at {output_file}")

def _random_name(rng):
    letters = "abcdefghijklmnopqrstuvwxyz"
    return rng.choice(letters) + "".join(rng.choices(letters + "0123456789", k=5))


def _get_dotted_name_root(node):
    """Walk an Attribute/Name node and return the root name string."""
    while isinstance(node, cst.Attribute):
        node = node.value
    if isinstance(node, cst.Name):
        return node.value
    return None


class RandomRenamer(cst.CSTTransformer):

    METADATA_DEPENDENCIES = (ScopeProvider, ParentNodeProvider)

    def __init__(self, seed):
        self.rng = random.Random(seed)
        self.rename_map = {}
        self.global_names = set()  # names declared global inside any function
        self.protected = set(keyword.kwlist)
        self.protected.update(dir(builtins))
        self.protected.add("task_func")

        self.imported = set()
        self.imported_modules = set()
        self.task_params = set()

    def visit_Global(self, node):
        for name_item in node.names:
            self.global_names.add(name_item.name.value)

    def visit_Nonlocal(self, node):
        for name_item in node.names:
            self.global_names.add(name_item.name.value)

    def visit_Import(self, node):
        if isinstance(node.names, cst.ImportStar):
            return
        for alias in node.names:
            if alias.asname is not None:
                asname_node = alias.asname
                if isinstance(asname_node, cst.AsName) and isinstance(asname_node.name, cst.Name):
                    self.imported.add(asname_node.name.value)
                # Also protect the root even when aliased
                root = _get_dotted_name_root(alias.name)
                if root:
                    self.imported_modules.add(root)
            else:
                root = _get_dotted_name_root(alias.name)
                if root:
                    self.imported.add(root)
                    self.imported_modules.add(root)

    def visit_ImportFrom(self, node):
        if isinstance(node.names, cst.ImportStar):
            return
        
        # Protect the module being imported from too
        if node.module is not None:
            root = _get_dotted_name_root(node.module)
            if root:
                self.imported.add(root)
                self.imported_modules.add(root)
        
        for alias in node.names:
            if not isinstance(alias, cst.ImportAlias):
                continue
            if alias.asname is not None:
                asname_node = alias.asname
                if isinstance(asname_node, cst.AsName) and isinstance(asname_node.name, cst.Name):
                    self.imported.add(asname_node.name.value)
            else:
                root = _get_dotted_name_root(alias.name)
                if root:
                    self.imported.add(root)

    def visit_FunctionDef(self, node):
        if node.name.value == "task_func":
            for p in node.params.params:
                self.task_params.add(p.name.value)

    def leave_FunctionDef(self, original, updated):
        name = original.name.value

        if name == "task_func":
            return updated

        if name in self.protected or name in self.imported:
            return updated

        scope = self.get_metadata(ScopeProvider, original)
        key = ("func", id(scope), name)

        if key not in self.rename_map:
            self.rename_map[key] = _random_name(self.rng)

        return updated.with_changes(name=cst.Name(self.rename_map[key]))

    def leave_Name(self, original, updated):
        name = original.value
        parent = self.get_metadata(ParentNodeProvider, original)

        if self._should_skip_name(name, parent, original):
            return updated

        scope = self.get_metadata(ScopeProvider, original)

        # Find referents for this access
        referents = None
        for access in scope.accesses:
            if access.node is original:
                if access.referents:
                    referents = access.referents  # keep as set of Assignment objects
                break

        # Skip references to loop/comprehension iteration variables
        if referents is not None:
            for ref in referents:
                ref_parent = self.get_metadata(ParentNodeProvider, ref.node)
                if isinstance(ref_parent, (cst.For, cst.CompFor)):
                    if ref_parent.target is ref.node:
                        return updated
            key = frozenset(id(a.node) for a in referents)
        else:
            # Assignment target
            key = frozenset([id(original)])

        if key not in self.rename_map:
            self.rename_map[key] = _random_name(self.rng)

        return updated.with_changes(value=self.rename_map[key])

    def _should_skip_name(self, name, parent, original):
    # Skip Python keywords and builtins
        if name in self.protected:
            return True

        # Skip imported names and modules
        if name in self.imported:
            return True
        if name in self.imported_modules:
            return True

        # Skip task_func parameters
        if name in self.task_params:
            return True

        # Skip dunder names (__name__, __file__, __all__, etc.)
        if name.startswith('__') and name.endswith('__'):
            return True

        # Skip globally/nonlocally declared names
        if name in self.global_names:
            return True

        # Skip attribute access (e.g. the `bar` in `foo.bar`)
        if isinstance(parent, cst.Attribute):
            # Skip only if this name is the attribute being accessed (e.g. `bar` in `foo.bar`)
            # NOT if it's the object (e.g. `foo` in `foo.bar`)
            if parent.attr is original or parent.attr.value == name:
                return True

        # Skip import alias targets
        if isinstance(parent, cst.ImportAlias):
            return True

        # Skip `as` targets in imports and with-statements
        if isinstance(parent, cst.AsName):
            # Only skip for import contexts, not `with ... as var`
            grandparent = self.get_metadata(ParentNodeProvider, parent)
            if isinstance(grandparent, (cst.ImportAlias,)):
                return True
        
        # for loop variables
        if isinstance(parent, cst.For) and parent.target is original:
            return True

        if isinstance(parent, cst.CompFor) and parent.target is original:
            return True
        
        # Skip global/nonlocal statements
        if isinstance(parent, (cst.Global, cst.Nonlocal)):
            return True

        # Skip keyword argument LABELS only (e.g. `key` in sorted(x, key=fn))
        # but NOT the values (e.g. `fn` in sorted(x, key=fn))
        if isinstance(parent, cst.Arg) and parent.keyword is not None:
            if isinstance(parent.keyword, cst.Name) and parent.keyword.value == name:
                return True

        return False


def _transform_code(code, seed):
    module = cst.parse_module(code)
    wrapper = MetadataWrapper(module)
    transformed = wrapper.visit(RandomRenamer(seed))
    try:
        cst.parse_module(transformed.code)
    except cst.ParserSyntaxError as e:
        print("TRANSFORMED CODE:")
        for i, line in enumerate(transformed.code.splitlines(), 1):
            print(f"{i:3}: {line}")
        raise
    return transformed.code


def _fix_syntax(code: str) -> str:
    """Attempt to fix common syntax issues caused by incomplete cleaning."""
    try:
        ast.parse(code)
        return code  # already valid
    except SyntaxError:
        pass

    lines = code.splitlines(keepends=True)

    # Fix 1: dedent orphaned indented blocks at module level
    fixed_lines = []
    for line in lines:
        if line and line[0] in (' ', '\t'):
            line = textwrap.dedent(line)
        fixed_lines.append(line)
    fixed = "".join(fixed_lines)
    try:
        ast.parse(fixed)
        return fixed
    except SyntaxError:
        pass

    # Fix 2: drop lines that are still invalid after dedenting
    valid_lines = []
    for line in lines:
        candidate = "".join(valid_lines + [line])
        try:
            ast.parse(candidate)
            valid_lines.append(line)
        except SyntaxError:
            # Try dedented version first
            dedented = textwrap.dedent(line)
            candidate2 = "".join(valid_lines + [dedented])
            try:
                ast.parse(candidate2)
                valid_lines.append(dedented)
            except SyntaxError:
                pass  # drop the line entirely

    fixed = "".join(valid_lines)
    try:
        ast.parse(fixed)
        return fixed
    except SyntaxError:
        return code  # give up, return original