/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16100
*  Stack Overflow answer #:52588251
*  And Stack Overflow answer#:27378161
*/
private static Task < string > GetStringForEnum (string model) {
    return Task.Run (() = > {
        Regex rgx = new Regex ("[^a-zA-Z0-9 -]");
        var nonAlphanumericData = rgx.Matches (model);
        if (nonAlphanumericData.Count < 1) {
            return model;
        }
        foreach (var item in nonAlphanumericData) {
            model = model.Replace ((string) item, "");
        }
        return model;
    });
}

public static T ParseEnum < T > (string value, T defaultValue) where T : struct {
    try {
        T enumValue;
        if (! Enum.TryParse (value, true, out enumValue)) {
            return defaultValue;
        }
        return enumValue;
    }
    catch (Exception) {
        return defaultValue;
    }
}

