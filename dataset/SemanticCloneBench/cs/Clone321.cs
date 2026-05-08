/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20143264
*  Stack Overflow answer #:24487548
*  And Stack Overflow answer#:20405583
*/
public void FindPath () {
    ManagementObjectSearcher entity = new ManagementObjectSearcher ("SELECT * FROM Win32_DiskDrive");
    foreach (ManagementObject obj in entity.Get ()) {
        if (obj ["PNPDeviceID"].ToString ().Contains ("USBSTOR")) {
            if (! USBobjects.Contains (obj ["PNPDeviceID"].ToString ()))
                USBobjects.Add (obj ["PNPDeviceID"].ToString ());
        }
    }
}

public void FindPath () {
    foreach (ManagementObject entity in new ManagementObjectSearcher ("select * from Win32_USBHub Where DeviceID Like '%VID_XXXX&PID_XXXX%'").Get ()) {
        Entity = entity ["DeviceID"].ToString ();
        foreach (ManagementObject controller in entity.GetRelated ("Win32_USBController")) {
            foreach (ManagementObject obj in new ManagementObjectSearcher ("ASSOCIATORS OF {Win32_USBController.DeviceID='" + controller ["PNPDeviceID"].ToString () + "'}").Get ()) {
                if (obj.ToString ().Contains ("DeviceID"))
                    USBobjects.Add (obj ["DeviceID"].ToString ());
            }
        }
    }
    int VidPidposition = USBobjects.IndexOf (Entity);
    for (int i = VidPidposition; i <= USBobjects.Count; i ++) {
        if (USBobjects [i].Contains ("USBSTOR")) {
            Secondentity = USBobjects [i];
            break;
        }
    }
}

