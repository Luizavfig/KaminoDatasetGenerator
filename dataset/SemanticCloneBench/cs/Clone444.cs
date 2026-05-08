/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1218986
*  Stack Overflow answer #:1224885
*  And Stack Overflow answer#:1222790
*/
static void Main () {
    Bitmap mask = new Bitmap (@"mask.bmp");
    Bitmap bmp = new Bitmap (@"test.jpg");
    int width = bmp.Width;
    int height = bmp.Height;
    for (int x = 0; x < width; x ++)
        for (int y = 0; y < height; y ++)
            if (mask.GetPixel (x, y).R < 250)
                bmp.SetPixel (x, y, mask.GetPixel (x, y));
    bmp.Save (@"test3.jpg");
}

static void Main () {
    Bitmap bmp = new Bitmap ("test.jpg");
    int width = bmp.Width;
    int height = bmp.Height;
    Dictionary < Point, int > currentLayer = new Dictionary < Point, int > ();
    currentLayer [new Point (0, 0)] = 0;
    currentLayer [new Point (width - 1, height - 1)] = 0;
    while (currentLayer.Count != 0) {
        foreach (Point p in currentLayer.Keys)
            bmp.SetPixel (p.X, p.Y, Color.Black);
        Dictionary < Point, int > newLayer = new Dictionary < Point, int > ();
        foreach (Point p in currentLayer.Keys)
            foreach (Point p1 in Neighbors (p, width, height))
                if (Distance (bmp.GetPixel (p1.X, p1.Y), Color.White) < 40)
                    newLayer [p1] = 0;
        currentLayer = newLayer;
    }
    bmp.Save ("test2.jpg");
}

