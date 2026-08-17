using System.Collections.Generic;
using System.Text.RegularExpressions;

// BigCodeBench/818
// Python: re.split(r'\s+', text) -> per word: re.sub(f'[{PUNCTUATION}]', '', word).lower()
//
// Language-specific adaptations:
// - string.punctuation (Python's constant `!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~`)
//   has no built-in C# equivalent, so it is inlined as a literal constant.
//   Several of these characters (]  \  ^  -) are regex metacharacters, so the
//   character class is built carefully (']' and '\\' escaped, '^' not first,
//   '-' placed last) to mean exactly "any of these literal characters", just
//   like Python's re.sub(f'[{PUNCTUATION}]', ...) does implicitly.
// - re.split(r'\s+', text) splits on runs of whitespace; C#'s Regex.Split with
//   the same pattern behaves identically, including producing a leading/
//   trailing empty string when the input starts/ends with whitespace (this
//   is exercised by the original test_string_with_whitespaces test case).
// - str.lower() -> string.ToLowerInvariant(). Invariant (not culture-specific
//   ToLower()) is used because Python's str.lower() for ASCII text is
//   locale-independent, and ToLowerInvariant avoids the classic Turkish-I
//   locale bug where ToLower() on some systems maps 'I' -> 'ı' instead of 'i'.
// - Pitfall hit and fixed while verifying this port: Python builds its regex
//   as f'[{string.punctuation}]', embedding the punctuation characters RAW.
//   That only works in Python because string.punctuation happens to already
//   contain a backslash immediately before ']' (".../@[\]^_...") and its '-'
//   sits between ',' and '.', so it accidentally self-escapes -- an ASCII-
//   ordering coincidence, not a principled construction. A first attempt at
//   this port used `"[" + Regex.Escape(Punctuation) + "]"`, which compiled
//   and ran without error but silently stripped NO punctuation: .NET's
//   Regex.Escape does not escape ']', so the un-escaped ']' inside Punctuation
//   closed the character class early. The fix below escapes every punctuation
//   character individually before building the class, which is correct
//   regardless of character order or regex engine.
public static class Solution
{
    private const string Punctuation = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
    private static readonly Regex PunctuationPattern = new Regex(BuildCharClass(Punctuation));
    private static readonly Regex WhitespacePattern = new Regex(@"\s+");

    private static string BuildCharClass(string chars)
    {
        // Regex.Escape() correctly no-ops on characters that don't need escaping,
        // but (unlike Python's re) .NET rejects "\_" as an unrecognized escape --
        // it only accepts backslash before its own recognized metacharacters, so
        // ']' (the one character Regex.Escape leaves un-escaped but that MUST be
        // escaped to appear literally inside a class) is special-cased here.
        var sb = new System.Text.StringBuilder("[");
        foreach (char c in chars)
        {
            sb.Append(c == ']' ? "\\]" : Regex.Escape(c.ToString()));
        }
        sb.Append(']');
        return sb.ToString();
    }

    public static List<string> TaskFunc(string text)
    {
        var words = WhitespacePattern.Split(text ?? "");
        var cleanedWords = new List<string>(words.Length);

        foreach (var word in words)
        {
            string cleaned = PunctuationPattern.Replace(word, "").ToLowerInvariant();
            cleanedWords.Add(cleaned);
        }

        return cleanedWords;
    }
}
