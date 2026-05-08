/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7054922
*  Stack Overflow answer #:7339262
*  And Stack Overflow answer#:7055237
*/
private bool checkTextWillFit (string enteredText) {
    StringFormat format1 = new StringFormat ();
    format1.Trimming = StringTrimming.Word;
    RectangleF rectfText;
    int iCharactersFitted, iLinesFitted;
    rectfText = new RectangleF (60.0F, 200.0F, 560.0F, 200.0F);
    Graphics g = printDocument1.PrinterSettings.CreateMeasurementGraphics ();
    Font myFont = new Font ("Times New Roman", 10, FontStyle.Regular);
    g.MeasureString (enteredText, myFont, rectfText.Size, format1, out iCharactersFitted, out iLinesFitted);
    if (iLinesFitted > 12) {
        return true;
    } else {
        return false;
    }
}

private bool checkTextWillFit (string enteredText) {
    Graphics g = pd.PrinterSettings.CreateMeasurementGraphics ();
    Font myFont = new Font ("Arial", 12, FontStyle.Regular, GraphicsUnit.Millimeter);
    if (g.MeasureString (enteredText, myFont).Width > 100) {
        return true;
    } else {
        return false;
    }
}

