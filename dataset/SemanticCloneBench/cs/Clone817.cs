/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:398388
*  Stack Overflow answer #:33440846
*  And Stack Overflow answer#:52150793
*/
private void SaevAsMultiPageTiff (string sOutFile, string [] pagesbase64Array) {
    System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
    ImageCodecInfo encoderInfo = ImageCodecInfo.GetImageEncoders ().First (i = > i.MimeType == "image/tiff");
    EncoderParameters encoderParameters = new EncoderParameters (1);
    encoderParameters.Param [0] = new EncoderParameter (encoder, (long) EncoderValue.MultiFrame);
    Bitmap firstImage = null;
    try {
        using (MemoryStream ms1 = new MemoryStream ())
        {
            using (MemoryStream ms = new MemoryStream (Convert.FromBase64String (pagesbase64Array [0])))
            {
                Image.FromStream (ms).Save (ms1, ImageFormat.Tiff);
                firstImage = (Bitmap) Image.FromStream (ms1);
            } firstImage.Save (sOutFile, encoderInfo, encoderParameters);
        } encoderParameters.Param [0] = new EncoderParameter (encoder, (long) EncoderValue.FrameDimensionPage);
        Bitmap imagePage;
        for (int i = 1; i < pagesbase64Array.Length; i ++) {
            using (MemoryStream ms1 = new MemoryStream ())
            {
                using (MemoryStream ms = new MemoryStream (Convert.FromBase64String (pagesbase64Array [i])))
                {
                    Image.FromStream (ms).Save (ms1, ImageFormat.Tiff);
                    imagePage = (Bitmap) Image.FromStream (ms1);
                } firstImage.SaveAdd (imagePage, encoderParameters);
            }}
    }
    catch (Exception) {
        throw;
    }
    finally {
        encoderParameters.Param [0] = new EncoderParameter (encoder, (long) EncoderValue.Flush);
        firstImage.SaveAdd (encoderParameters);
    }
}

private static System.Drawing.Image SaveImages (System.Drawing.Imaging.ImageCodecInfo tiffCodec, System.IO.MemoryStream outputStream, System.Drawing.Image tiffImage, System.Drawing.Image firstImage) {
    using (System.Drawing.Imaging.EncoderParameters encParameters = new System.Drawing.Imaging.EncoderParameters (3))
    {
        if (firstImage == null) {
            encParameters.Param [0] = new System.Drawing.Imaging.EncoderParameter (System.Drawing.Imaging.Encoder.SaveFlag, (long) System.Drawing.Imaging.EncoderValue.MultiFrame);
        } else {
            encParameters.Param [0] = new System.Drawing.Imaging.EncoderParameter (System.Drawing.Imaging.Encoder.SaveFlag, (long) System.Drawing.Imaging.EncoderValue.FrameDimensionPage);
        }
        encParameters.Param [1] = new System.Drawing.Imaging.EncoderParameter (System.Drawing.Imaging.Encoder.ColorDepth, 24L);
        encParameters.Param [2] = new System.Drawing.Imaging.EncoderParameter (System.Drawing.Imaging.Encoder.Compression, (long) System.Drawing.Imaging.EncoderValue.CompressionLZW);
        if (firstImage == null) {
            firstImage = tiffImage;
            ((System.Drawing.Bitmap) tiffImage).SetResolution (96, 96);
            firstImage.Save (outputStream, tiffCodec, encParameters);
        } else {
            ((System.Drawing.Bitmap) tiffImage).SetResolution (96, 96);
            firstImage.SaveAdd (tiffImage, encParameters);
        }
        if (encParameters.Param [0] != null)
            encParameters.Param [0].Dispose ();
        if (encParameters.Param [1] != null)
            encParameters.Param [1].Dispose ();
        if (encParameters.Param [2] != null)
            encParameters.Param [2].Dispose ();
    } return firstImage;
}

