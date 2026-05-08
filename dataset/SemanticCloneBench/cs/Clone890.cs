/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18386108
*  Stack Overflow answer #:19172550
*  And Stack Overflow answer#:19172550
*/
public bool CheckForCrossing (List < Line2D > lines) {
    List < endpointEntry > pts = new List < endpointEntry > (2 * lines.Count);
    foreach (Line2D lin in lines) {
        endpointEntry hi, lo;
        if (lin.P1.X < lin.P2.X) {
            hi = new endpointEntry () {XValue = lin.P2.X, isHi = true, line = lin, hi = lin.P2.X, lo = lin.P1.X};
            lo = new endpointEntry () {XValue = lin.P1.X, isHi = false, line = lin, hi = lin.P1.X, lo = lin.P2.X};
        } else {
            hi = new endpointEntry () {XValue = lin.P1.X, isHi = true, line = lin, hi = lin.P1.X, lo = lin.P2.X};
            lo = new endpointEntry () {XValue = lin.P2.X, isHi = false, line = lin, hi = lin.P2.X, lo = lin.P1.X};
        }
        pts.Add (hi);
        pts.Add (lo);
    }
    pts.Sort (new endpointSorter ());
    endpointEntry prev = null;
    foreach (endpointEntry pt in pts) {
        if (prev != null) {
            pt.bLink = prev;
            prev.fLink = pt;
        }
        prev = pt;
    }
    foreach (endpointEntry pt in pts) {
        if (pt.isHi) {
            for (endpointEntry pLo = pt.fLink; (pLo != null) && (pLo.XValue >= pt.lo); pLo = pLo.fLink) {
                if (! pLo.isHi) {
                    if (pt.line.intersectsLine (pLo.line))
                        return true;
                }
            }
        }
    }
    return false;
}

public int Compare (endpointEntry c1, endpointEntry c2) {
    if (c1.XValue > c2.XValue) {
        return - 1;
    } else if (c1.XValue < c2.XValue) {
        return 1;
    } else if (c1.isHi && ! c2.isHi) {
        return - 1;
    } else if (! c1.isHi && c2.isHi) {
        return 1;
    } else {
        return 0;
    }
}

