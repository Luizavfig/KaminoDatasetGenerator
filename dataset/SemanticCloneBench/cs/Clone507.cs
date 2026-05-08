/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2725529
*  Stack Overflow answer #:2725584
*  And Stack Overflow answer#:2725772
*/
static void Main (string [] args) {
    Image image = Image.FromFile (@"C:\some_animated_gif.gif");
    FrameDimension dimension = new FrameDimension (image.FrameDimensionsList [0]);
    int frameCount = image.GetFrameCount (dimension);
    StringBuilder sb;
    int left = Console.WindowLeft, top = Console.WindowTop;
    char [] chars = {'#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' '};
    for (int i = 0;; i = (i + 1) % frameCount) {
        sb = new StringBuilder ();
        image.SelectActiveFrame (dimension, i);
        for (int h = 0; h < image.Height; h ++) {
            for (int w = 0; w < image.Width; w ++) {
                Color cl = ((Bitmap) image).GetPixel (w, h);
                int gray = (cl.R + cl.G + cl.B) / 3;
                int index = (gray * (chars.Length - 1)) / 255;
                sb.Append (chars [index]);
            }
            sb.Append ('\n');
        }
        Console.SetCursorPosition (left, top);
        Console.Write (sb.ToString ());
        System.Threading.Thread.Sleep (100);
    }
}

static void Main (string [] args) {
    Console.CursorVisible = false;
    var arr = new [] {@"        ________________.  ___     .______  ", @"       /                | /   \    |   _  \", @"      |   (-----|  |----`/  ^  \   |  |_)  |", @"       \   \    |  |    /  /_\  \  |      /", @"  .-----)   |   |  |   /  _____  \ |  |\  \-------.", @"  |________/    |__|  /__/     \__\| _| `.________|", @"   ____    __    ____  ___     .______    ________.", @"   \   \  /  \  /   / /   \    |   _  \  /        |", @"    \   \/    \/   / /  ^  \   |  |_)  ||   (-----`", @"     \            / /  /_\  \  |      /  \   \", @"      \    /\    / /  _____  \ |  |\  \---)   |", @"       \__/  \__/ /__/     \__\|__| `._______/",};
    var maxLength = arr.Aggregate (0, (max, line) = > Math.Max (max, line.Length));
    var x = Console.BufferWidth / 2 - maxLength / 2;
    for (int y = - arr.Length; y < Console.WindowHeight + arr.Length; y ++) {
        ConsoleDraw (arr, x, y);
        Thread.Sleep (100);
    }
}

