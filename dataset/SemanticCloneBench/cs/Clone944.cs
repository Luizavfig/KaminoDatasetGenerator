/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1156608
*  Stack Overflow answer #:1156732
*  And Stack Overflow answer#:1156732
*/
private void RunTest () {
    byte [] iba;
    iba = ReadImage ("D:\\Images\\Image01.jpg");
    using (Image img = DeserializeImage (iba))
    {
        SaveImage (img, "D:\\Images\\Image01_Copy.jpg");
    } iba = ReadImage ("D:\\Images\\Image02.png");
    using (Image img1 = DeserializeImage (iba))
    {
        SaveImage (img1, "D:\\Images\\Image02_Copy.png");
    } iba = ReadImage ("D:\\Images\\Image03.gif");
    using (var img2 = DeserializeImage (iba))
    {
        SaveImage (img2, "D:\\Images\\Image03_Copy.gif");
    } MessageBox.Show ("Test Complete");
}

private static void SaveImage (Image imageObject, string filePath) {
    using (Image img = new Bitmap (imageObject.Width, imageObject.Height))
    {
        using (Graphics tg = Graphics.FromImage (img))
        {
            tg.DrawImage (imageObject, 0, 0);
        } img.Save (filePath, img.RawFormat);
    } return;
}

