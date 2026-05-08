/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3949033
*  Stack Overflow answer #:3949066
*  And Stack Overflow answer#:3952068
*/
public Player GetNextPlayer () {
    int currentPlayerIndex = Players.FindIndex (o = > o.IsThisPlayersTurn);
    int next = _direction.Equals (Direction.Forwards) ? 1 : - 1;
    int nextPlayerIndex = currentPlayerIndex;
    do
        {
            nextPlayerIndex = (nextPlayerIndex + next + Players.Count) % Players.Count;
        } while (Players [nextPlayerIndex].HasNoCards && nextPlayerIndex != currentPlayerIndex);
    return Players [nextPlayerIndex];
}

private Player GetNextPlayer () {
    if (! Players.Any ())
        throw new InvalidOperationException ("No players.");
    if (Players.Count (p = > p.IsThisPlayersTurn) != 1) {
        throw new InvalidOperationException ("It must be one--and only one--player's turn.");
    }
    var current = Players.Single (p = > p.IsThisPlayersTurn);
    var subsequent = Players.Concat (Players).SkipWhile (p = > p != current).Skip (1).TakeWhile (p = > p != current);
    if (_direction == Direction.Backwards) {
        subsequent = subsequent.Reverse ();
    }
    return subsequent.FirstOrDefault (p = > p.PlayerState != PlayerState.HasNoCards);
}

