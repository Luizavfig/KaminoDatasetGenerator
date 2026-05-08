/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1631414
*  Stack Overflow answer #:1752336
*  And Stack Overflow answer#:1749493
*/
public Point GetShot () {
    Point p = new Point ();
    if (attackVector.Count () > 0) {
        p = ExtendShot ();
        return p;
    }
    Board potential = new Board (size);
    for (p.Y = 0; p.Y < size.Height; ++ p.Y) {
        for (p.X = 0; p.X < size.Width; ++ p.X) {
            if (shotBoard.ShotAt (p)) {
                potential [p] = 0;
                continue;
            }
            foreach (HunterBoard b in targetBoards) {
                potential [p] += b.GetWeightAt (p);
            }
        }
    }
    Point shot;
    shot = potential.GetWeightedRandom (rand.NextDouble ());
    shotBoard [shot] = Shot.Unresolved;
    return shot;
}

public Point GetShot () {
    Point shot;
    if (this.nextShots.Count > 0) {
        if (hitDirection != Direction.UNKNOWN) {
            if (hitDirection == Direction.HORIZONTAL) {
                this.nextShots = this.nextShots.OrderByDescending (x = > x.direction).ToList ();
            } else {
                this.nextShots = this.nextShots.OrderBy (x = > x.direction).ToList ();
            }
        }
        shot = this.nextShots.First ().point;
        lastShotDirection = this.nextShots.First ().direction;
        this.nextShots.RemoveAt (0);
        return shot;
    }
    List < ScanShot > scanShots = new List < ScanShot > ();
    for (int x = 0; x < gameSize.Width; x ++) {
        for (int y = 0; y < gameSize.Height; y ++) {
            if (board [x, y] == ShotResult.UNKNOWN) {
                scanShots.Add (new ScanShot (new Point (x, y), OpenSpaces (x, y)));
            }
        }
    }
    scanShots = scanShots.OrderByDescending (x = > x.openSpaces).ToList ();
    int maxOpenSpaces = scanShots.FirstOrDefault ().openSpaces;
    List < ScanShot > scanShots2 = new List < ScanShot > ();
    scanShots2 = scanShots.Where (x = > x.openSpaces == maxOpenSpaces).ToList ();
    shot = scanShots2 [rand.Next (scanShots2.Count ())].point;
    return shot;
}

