/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1631414
*  Stack Overflow answer #:1752336
*  And Stack Overflow answer#:1749493
*/
public void ShotHit (Point shot, bool sunk) {
    shotBoard [shot] = Shot.Hit;
    if (! sunk) {
        if (attackVector.Count == 0) {
            attackVector.Push (new Attack (this, shot));
        } else {
            attackVector.Peek ().AddHit (shot);
        }
    }
    if (sunk) {
        if (attackVector.Count > 0) {
            attackVector.Pop ();
        }
    }
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

