/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20998894
*  Stack Overflow answer #:22298289
*  And Stack Overflow answer#:22298289
*/
static void LoadDefaultValues () {
    var settingsDict = new NSDictionary (NSBundle.MainBundle.PathForResource ("Settings.bundle/Root.plist", null));
    if (settingsDict != null) {
        var prefSpecifierArray = settingsDict [(NSString) "PreferenceSpecifiers"] as NSArray;
        if (prefSpecifierArray != null) {
            foreach (var prefItem in NSArray.FromArray < NSDictionary > (prefSpecifierArray)) {
                var key = prefItem [(NSString) "Key"] as NSString;
                if (key == null)
                    continue;
                var value = prefItem [(NSString) "DefaultValue"];
                if (value == null)
                    continue;
                switch (key.ToString ()) {
                    case API_PATH_KEY :
                        ApiPath = value.ToString ();
                        break;
                    default :
                        break;
                }
            }
        }
    }
}

public static void SetUpByPreferences () {
    var testVal = NSUserDefaults.StandardUserDefaults.StringForKey (API_PATH_KEY);
    if (testVal == null)
        LoadDefaultValues ();
    else
        LoadEditedValues ();
    SavePreferences ();
}

