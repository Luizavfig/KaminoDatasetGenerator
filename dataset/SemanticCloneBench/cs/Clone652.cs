/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2819934
*  Stack Overflow answer #:2819974
*  And Stack Overflow answer#:2820667
*/
string getOSInfo () {
    OperatingSystem os = Environment.OSVersion;
    Version vs = os.Version;
    string operatingSystem = "";
    if (os.Platform == PlatformID.Win32Windows) {
        switch (vs.Minor) {
            case 0 :
                operatingSystem = "95";
                break;
            case 10 :
                if (vs.Revision.ToString () == "2222A")
                    operatingSystem = "98SE";
                else
                    operatingSystem = "98";
                break;
            case 90 :
                operatingSystem = "Me";
                break;
            default :
                break;
        }
    } else if (os.Platform == PlatformID.Win32NT) {
        switch (vs.Major) {
            case 3 :
                operatingSystem = "NT 3.51";
                break;
            case 4 :
                operatingSystem = "NT 4.0";
                break;
            case 5 :
                if (vs.Minor == 0)
                    operatingSystem = "2000";
                else
                    operatingSystem = "XP";
                break;
            case 6 :
                if (vs.Minor == 0)
                    operatingSystem = "Vista";
                else if (vs.Minor == 1)
                    operatingSystem = "7";
                else if (vs.Minor == 2)
                    operatingSystem = "8";
                else
                    operatingSystem = "8.1";
                break;
            case 10 :
                operatingSystem = "10";
                break;
            default :
                break;
        }
    }
    if (operatingSystem != "") {
        operatingSystem = "Windows " + operatingSystem;
        if (os.ServicePack != "") {
            operatingSystem += " " + os.ServicePack;
        }
    }
    return operatingSystem;
}

public string GetOSVersion () {
    int _MajorVersion = Environment.OSVersion.Version.Major;
    switch (_MajorVersion) {
        case 5 :
            return "Windows XP";
        case 6 :
            switch (Environment.OSVersion.Version.Minor) {
                case 0 :
                    return "Windows Vista";
                case 1 :
                    return "Windows 7";
                default :
                    return "Windows Vista & above";
            }
            break;
        default :
            return "Unknown";
    }
}

