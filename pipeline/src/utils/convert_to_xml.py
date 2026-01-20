import json
import xml.etree.ElementTree as ET
from xml.dom import minidom
from src.config import *

def json_to_xml(json_file=FINAL_DATASET, xml_file=FINAL_DATASET_RQ2): 

    # Load JSON
    with open(json_file, "r", encoding="utf-8") as f:
        data = json.load(f)

    # Root element
    root = ET.Element("clones")

    for entry in data:
        entry_id = entry.get("id", "unknown")
        clones = entry.get("clones", [])
        
        for clone in clones:
            clone_id = clone.get("clone_id", "unknown")
            code_content = clone.get("code", "")
            
            # Remove \n and properly indent code for XML
            code_lines = code_content.splitlines()
            code_text = "\n".join(line for line in code_lines)
            
            # <clone> element
            clone_elem = ET.SubElement(root, "clone")
            
            # <source> element
            source_elem = ET.SubElement(
                clone_elem,
                "source",
                file=f"{entry_id}_{clone_id}",
                startline="0",
                endline="0"
            )
            
            # <code> element
            code_elem = ET.SubElement(clone_elem, "code")
            code_elem.text = code_text

    # Pretty print XML
    xml_str = ET.tostring(root, encoding="utf-8")
    parsed_xml = minidom.parseString(xml_str)
    pretty_xml = parsed_xml.toprettyxml(indent="    ")

    # Save to file
    with open(xml_file, "w", encoding="utf-8") as f:
        f.write(pretty_xml)

    print(f"XML saved to {xml_file}")
