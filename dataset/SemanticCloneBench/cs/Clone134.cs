/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42580535
*  Stack Overflow answer #:42580751
*  And Stack Overflow answer#:42580964
*/
protected bool Move (int xDir, int yDir, out RaycastHit2D hit) {
    Vector2 start = transform.position;
    Vector2 end = start + new Vector2 (xDir, yDir);
    boxCollider.enabled = false;
    hit = Physics2D.Linecast (start, end, blockingLayer);
    boxCollider.enabled = true;
    if (hit.transform == null) {
        StartCoroutine (SmoothMovement (end));
        return true;
    }
    return false;
}

IEnumerator Move (Vector2 direction) {
    Vector2 orgPos = transform.Position;
    Vector2 newPos = orgPos + direction;
    float t = 0;
    while (t < 1.0f) {
        transform.position = Vector2.Lerp (orgPos, newPos, (t += Time.deltaTime * m_SpeedFactor));
        yield return new WaitForEndFrame ();
    }
    StopCoroutine (m_MoveCoroutine);
    m_MoveCoroutine = null;
}

