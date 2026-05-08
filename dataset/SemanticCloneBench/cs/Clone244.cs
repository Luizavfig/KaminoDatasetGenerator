/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1631414
*  Stack Overflow answer #:1688053
*  And Stack Overflow answer#:1749493
*/
public void ShotHit (Point shot, bool sunk) {
    HitShots.AddLast (shot);
    MissCount = 0;
    EndPoints [1] = shot;
    if (EndPoints [0] == null)
        EndPoints [0] = shot;
    if (sunk)
        NullOutTarget ();
}

public void ShotHit (Point shot, bool sunk) {
    board [shot.X, shot.Y] = ShotResult.HIT;
    if (! sunk) {
        hitDirection = lastShotDirection;
        if (shot.X != 0) {
            this.nextShots.Add (new NextShot (new Point (shot.X - 1, shot.Y), Direction.HORIZONTAL));
        }
        if (shot.Y != 0) {
            this.nextShots.Add (new NextShot (new Point (shot.X, shot.Y - 1), Direction.VERTICAL));
        }
        if (shot.X != this.gameSize.Width - 1) {
            this.nextShots.Add (new NextShot (new Point (shot.X + 1, shot.Y), Direction.HORIZONTAL));
        }
        if (shot.Y != this.gameSize.Height - 1) {
            this.nextShots.Add (new NextShot (new Point (shot.X, shot.Y + 1), Direction.VERTICAL));
        }
    } else {
        hitDirection = Direction.UNKNOWN;
        this.nextShots.Clear ();
    }
}

