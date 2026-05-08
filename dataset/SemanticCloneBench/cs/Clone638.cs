/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19674743
*  Stack Overflow answer #:23864691
*  And Stack Overflow answer#:24285363
*/
public static void FindGoodFont (Graphics Graf, string sStringToFit, Size TextRoomAvail, ref Font FontToUse, GraphicsUnit FontUnit) {
    SizeF RealSize = Graf.MeasureString (sStringToFit, FontToUse);
    Debug.WriteLine ("big string is {0}, orig size = {1},{2}", sStringToFit, RealSize.Width, RealSize.Height);
    if ((RealSize.Width <= TextRoomAvail.Width) && (RealSize.Height <= TextRoomAvail.Height)) {
        Debug.WriteLine ("The space is big enough already");
        return;
    }
    float HeightScaleRatio = TextRoomAvail.Height / RealSize.Height;
    float WidthScaleRatio = TextRoomAvail.Width / RealSize.Width;
    float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;
    float ScaleFontSize = FontToUse.Size * ScaleRatio;
    Debug.WriteLine ("Resizing with scales {0},{1} chose {2}", HeightScaleRatio, WidthScaleRatio, ScaleRatio);
    Debug.WriteLine ("Old font size was {0}, new={1} ", FontToUse.Size, ScaleFontSize);
    FontStyle OldFontStyle = FontToUse.Style;
    FontToUse.Dispose ();
    FontToUse = new Font (FontToUse.FontFamily, ScaleFontSize, OldFontStyle, FontUnit);
}

public Font GetAdjustedFont (Graphics GraphicRef, string GraphicString, Font OriginalFont, int ContainerWidth, int MaxFontSize, int MinFontSize, bool SmallestOnFail) {
    for (int AdjustedSize = MaxFontSize; AdjustedSize >= MinFontSize; AdjustedSize --) {
        Font TestFont = new Font (OriginalFont.Name, AdjustedSize, OriginalFont.Style);
        SizeF AdjustedSizeNew = GraphicRef.MeasureString (GraphicString, TestFont);
        if (ContainerWidth > Convert.ToInt32 (AdjustedSizeNew.Width)) {
            return TestFont;
        }
    }
    if (SmallestOnFail) {
        return new Font (OriginalFont.Name, MinFontSize, OriginalFont.Style);
    } else {
        return OriginalFont;
    }
}

