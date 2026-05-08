/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14099246
*  Stack Overflow answer #:14099328
*  And Stack Overflow answer#:14100214
*/
private Bitmap GetSprite (bool anim, int tsIndex, int tileIdx) {
    Rectangle cloneRect;
    string prefix = (anim) ? "A" : "S";
    using (Bitmap b = new Bitmap (prefix + tsIndex.ToString () + ".png"))
    {
        if (anim) {
            cloneRect = new Rectangle (BaseObjects.A_AnimSpriteSets [tsIndex].StaticRecs [tileIdx].X, BaseObjects.A_AnimSpriteSets [tsIndex].StaticRecs [tileIdx].Y, BaseObjects.A_AnimSpriteSets [tsIndex].RecWidth, BaseObjects.A_AnimSpriteSets [tsIndex].RecHeight);
        } else {
            cloneRect = new Rectangle (BaseObjects.A_StaticSpriteSets [tsIndex].StaticRecs [tileIdx].X, BaseObjects.A_StaticSpriteSets [tsIndex].StaticRecs [tileIdx].Y, BaseObjects.A_StaticSpriteSets [tsIndex].RecWidth, BaseObjects.A_StaticSpriteSets [tsIndex].RecHeight);
        }
        return b.Clone (cloneRect, b.PixelFormat);
    }}

private Bitmap GetSprite (bool anim, int tsIndex, int tileIdx) {
    string prefix;
    System.Drawing.Rectangle cloneRect;
    SpriteSet set;
    if (anim) {
        prefix = "A";
        set = BaseObjects.A_AnimSpriteSets [tsIndex];
    } else {
        prefix = "S";
        set = BaseObjects.A_StaticSpriteSets [tsIndex];
    }
    cloneRect = new System.Drawing.Rectangle (set.StaticRecs [tileIdx].X, set.StaticRecs [tileIdx].Y, set.RecWidth, set.RecHeight);
    try {
        using (Bitmap b = new Bitmap (prefix + tsIndex.ToString () + ".png"))
        {
            return b.Clone (cloneRect, b.PixelFormat);
        }}
    catch (Exception ex) {
        MessageBox.Show ("Error: " + ex.Message + "\n\nCause: " + "SpriteSet not yet loaded.");
        return null;
    }
}

