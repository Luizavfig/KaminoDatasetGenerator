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
    sout.Write (GeoBase.MultiLineStringWkbs, 0, 4);
    sout.Write (BitConverter.GetBytes (this.LineStrings.Count), 0, 4);
    foreach (var lineString in this.LineStrings) {
        sout.WriteByte (order);
        sout.Write (GeoBase.LineStringWkbs, 0, 4);
        sout.Write (BitConverter.GetBytes (lineString.Count), 0, 4);
        foreach (var position in lineString) {
            position.WellKnownBinary (sout);
        }
    }
}

