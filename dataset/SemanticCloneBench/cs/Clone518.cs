/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41342183
*  Stack Overflow answer #:41343631
*  And Stack Overflow answer#:41342490
*/
private Coordinate Calculate (Coordinate location1, Coordinate location2, Coordinate location3, Coordinate location4) {
    Random random = new Random (DateTime.Now.Millisecond);
    Coordinate randomCoordinate = new Coordinate () {Latitude = random.Next ((int) Math.Floor (location4.Latitude), (int) Math.Floor (location2.Latitude))};
    if (randomCoordinate.Latitude > location1.Latitude) {
        double m1 = (location2.Longitude - location1.Longitude) / (location2.Latitude - location1.Latitude);
        double m2 = (location2.Longitude - location3.Longitude) / (location2.Latitude - location3.Latitude);
        double maxLongitude = (randomCoordinate.Latitude - location2.Latitude) * m1;
        double minLongitude = (randomCoordinate.Latitude - location2.Latitude) * m2;
        randomCoordinate.Longitude = random.Next ((int) Math.Ceiling (minLongitude), (int) Math.Floor (maxLongitude));
    } else {
        double m1 = (location4.Longitude - location1.Longitude) / (location4.Latitude - location1.Latitude);
        double m2 = (location4.Longitude - location3.Longitude) / (location4.Latitude - location3.Latitude);
        double maxLongitude = (randomCoordinate.Latitude - location4.Latitude) * m1;
        double minLongitude = (randomCoordinate.Latitude - location4.Latitude) * m2;
        randomCoordinate.Longitude = random.Next ((int) Math.Ceiling (minLongitude), (int) Math.Floor (maxLongitude));
    }
    return randomCoordinate;
}

private Coordinate [] Calculate (Coordinate location1, Coordinate location2, Coordinate location3, Coordinate location4) {
    Coordinate [] allCoords = {location1, location2, location3, location4};
    double minLat = allCoords.Min (x = > x.Latitude);
    double minLon = allCoords.Min (x = > x.Longitude);
    double maxLat = allCoords.Max (x = > x.Latitude);
    double maxLon = allCoords.Max (x = > x.Longitude);
    Random r = new Random ();
    Coordinate [] result = new Coordinate [500];
    for (int i = 0; i < result.Length; i ++) {
        Coordinate point = new Coordinate ();
        do
            {
                point.Latitude = r.NextDouble () * (maxLat - minLat) + minLat;
                point.Longitude = r.NextDouble () * (maxLon - minLon) + minLon;
            } while (! IsPointInPolygon (point, allCoords));
        result [i] = point;
    }
    return result;
}

