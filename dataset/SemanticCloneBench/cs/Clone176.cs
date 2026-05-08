/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3210010
*  Stack Overflow answer #:16852411
*  And Stack Overflow answer#:3210034
*/
static void Main () {
    var moCollection = new ManagementClass ("Win32_LogicalDisk").GetInstances ();
    foreach (var mo in moCollection) {
        if (mo ["DeviceID"] != null && mo ["DriveType"] != null && mo ["Size"] != null && mo ["FreeSpace"] != null) {
            if (Convert.ToInt32 (mo ["DriveType"]) == 3) {
                Console.WriteLine ("Drive {0}", mo ["DeviceID"]);
                Console.WriteLine ("Size {0} bytes", mo ["Size"]);
                Console.WriteLine ("Free {0} bytes", mo ["FreeSpace"]);
            }
        }
    }
}

public static void Main () {
    DriveInfo [] allDrives = DriveInfo.GetDrives ();
    foreach (DriveInfo d in allDrives) {
        Console.WriteLine ("Drive {0}", d.Name);
        Console.WriteLine ("  File type: {0}", d.DriveType);
        if (d.IsReady == true) {
            Console.WriteLine ("  Volume label: {0}", d.VolumeLabel);
            Console.WriteLine ("  File system: {0}", d.DriveFormat);
            Console.WriteLine ("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
            Console.WriteLine ("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);
            Console.WriteLine ("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
        }
    }
}

