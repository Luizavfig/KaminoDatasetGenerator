/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5461338
*  Stack Overflow answer #:5464332
*  And Stack Overflow answer#:5461950
*/
public static byte [] CreateGridImage (int maxXCells, int maxYCells, int cellXPosition, int cellYPosition, int boxSize) {
    using (var bmp = new System.Drawing.Bitmap (maxXCells * boxSize + 1, maxYCells * boxSize + 1))
    {
        using (Graphics g = Graphics.FromImage (bmp))
        {
            g.Clear (Color.Yellow);
            Pen pen = new Pen (Color.Black);
            pen.Width = 1;
            Rectangle rect = new Rectangle (boxSize * (cellXPosition - 1), boxSize * (cellYPosition - 1), boxSize, boxSize);
            g.FillRectangle (new SolidBrush (Color.Red), rect);
            g.DrawLine (pen, boxSize * (cellXPosition - 1), boxSize * (cellYPosition - 1), boxSize * cellXPosition, boxSize * cellYPosition);
            g.DrawLine (pen, boxSize * (cellXPosition - 1), boxSize * cellYPosition, boxSize * cellXPosition, boxSize * (cellYPosition - 1));
            for (int i = 0; i <= maxXCells; i ++) {
                g.DrawLine (pen, (i * boxSize), 0, i * boxSize, boxSize * maxYCells);
            }
            for (int i = 0; i <= maxYCells; i ++) {
                g.DrawLine (pen, 0, (i * boxSize), boxSize * maxXCells, i * boxSize);
            }
        } var memStream = new MemoryStream ();
        bmp.Save (memStream, ImageFormat.Jpeg);
        return memStream.ToArray ();
    }}

public byte [] GetData () {
    Form form = new Form ();
    DataGridView dataGridView1 = new DataGridView ();
    form.Controls.Add (dataGridView1);
    dataGridView1.RowHeadersVisible = false;
    dataGridView1.ColumnHeadersVisible = false;
    dataGridView1.ScrollBars = ScrollBars.None;
    dataGridView1.AutoSize = true;
    dataGridView1.DataSource = GetDataTable ();
    Bitmap bitmap = new Bitmap (dataGridView1.Width, dataGridView1.Height);
    dataGridView1.DrawToBitmap (bitmap, new Rectangle (Point.Empty, dataGridView1.Size));
    MemoryStream ms = new MemoryStream ();
    bitmap.Save (ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    bitmap.Dispose ();
    form.Dispose ();
    return ms.ToArray ();
}

