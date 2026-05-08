/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1332328
*  Stack Overflow answer #:1332436
*  And Stack Overflow answer#:1332358
*/
public bool dcpl_radar () {
    if (radar == null)
        return false;
    else {
        if (radar != null) {
            if (radar.InvokeRequired)
                radar.BeginInvoke (new MethodInvoker (delegate () {
                    radar.Visible = false;
                    radar = null;
                }));
            else {
                this.radar.Visible = false;
                radar = null;
            }
        }
        return true;
    }
}

public bool dcpl_radar () {
    if (radar != null) {
        if (radar.InvokeRequired) {
            radar.BeginInvoke (new MethodInvoker (HideRadar));
        } else {
            HideRadar ();
        }
        return true;
    }
    return false;
}

