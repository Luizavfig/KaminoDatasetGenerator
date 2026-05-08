/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16120171
*  Stack Overflow answer #:22544058
*  And Stack Overflow answer#:22544058
*/
public override void WellKnownBinary (Stream sout) {
    sout.WriteByte (BitConverter.IsLittleEndian ? (byte) 1 : (byte) 0);
    sout.Write (GeoBase.PolygonWkbs, 0, 4);
    sout.Write (BitConverter.GetBytes (this.Rings.Count), 0, 4);
    foreach (var ring in this.Rings) {
        sout.Write (BitConverter.GetBytes (ring.Count), 0, 4);
        foreach (var position in ring) {
            position.WellKnownBinary (sout);
        }
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

