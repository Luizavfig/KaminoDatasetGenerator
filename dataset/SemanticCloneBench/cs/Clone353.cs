/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16120171
*  Stack Overflow answer #:22544058
*  And Stack Overflow answer#:22544058
*/
public override void WellKnownBinary (Stream sout) {
    byte order = BitConverter.IsLittleEndian ? (byte) 1 : (byte) 0;
    sout.WriteByte (order);
    sout.Write (GeoBase.MultiPointWkbs, 0, 4);
    sout.Write (BitConverter.GetBytes (this.Points.Count), 0, 4);
    foreach (var point in this.Points) {
        sout.WriteByte (order);
        sout.Write (GeoBase.PointWkbs, 0, 4);
        point.WellKnownBinary (sout);
    }
}

public override void WellKnownBinary (Stream sout) {
    byte order = BitConverter.IsLittleEndian ? (byte) 1 : (byte) 0;
    sout.WriteByte (order);
    sout.Write (GeoBase.MultiPolygonWkbs, 0, 4);
    sout.Write (BitConverter.GetBytes (this.Polygons.Count), 0, 4);
    foreach (var polygon in this.Polygons) {
        sout.WriteByte (order);
        sout.Write (GeoBase.PolygonWkbs, 0, 4);
        sout.Write (BitConverter.GetBytes (polygon.Count), 0, 4);
        foreach (var ring in polygon) {
            sout.Write (BitConverter.GetBytes (ring.Count), 0, 4);
            foreach (var position in ring) {
                position.WellKnownBinary (sout);
            }
        }
    }
}

