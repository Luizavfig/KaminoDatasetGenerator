/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:58510
*  Stack Overflow answer #:16469313
*  And Stack Overflow answer#:13614746
*/
public static string GetMimeType (string sFilePath) {
    string sMimeType = GetMimeTypeFromList (sFilePath);
    if (String.IsNullOrEmpty (sMimeType)) {
        sMimeType = GetMimeTypeFromFile (sFilePath);
        if (String.IsNullOrEmpty (sMimeType)) {
            sMimeType = GetMimeTypeFromRegistry (sFilePath);
        }
    }
    return sMimeType;
}

public static string GetMimeType (byte [] file, string fileName) {
    string mime = "application/octet-stream";
    if (string.IsNullOrWhiteSpace (fileName)) {
        return mime;
    }
    string extension = Path.GetExtension (fileName) == null ? string.Empty : Path.GetExtension (fileName).ToUpper ();
    if (file.Take (2).SequenceEqual (BMP)) {
        mime = "image/bmp";
    } else if (file.Take (8).SequenceEqual (DOC)) {
        mime = "application/msword";
    } else if (file.Take (2).SequenceEqual (EXE_DLL)) {
        mime = "application/x-msdownload";
    } else if (file.Take (4).SequenceEqual (GIF)) {
        mime = "image/gif";
    } else if (file.Take (4).SequenceEqual (ICO)) {
        mime = "image/x-icon";
    } else if (file.Take (3).SequenceEqual (JPG)) {
        mime = "image/jpeg";
    } else if (file.Take (3).SequenceEqual (MP3)) {
        mime = "audio/mpeg";
    } else if (file.Take (14).SequenceEqual (OGG)) {
        if (extension == ".OGX") {
            mime = "application/ogg";
        } else if (extension == ".OGA") {
            mime = "audio/ogg";
        } else {
            mime = "video/ogg";
        }
    } else if (file.Take (7).SequenceEqual (PDF)) {
        mime = "application/pdf";
    } else if (file.Take (16).SequenceEqual (PNG)) {
        mime = "image/png";
    } else if (file.Take (7).SequenceEqual (RAR)) {
        mime = "application/x-rar-compressed";
    } else if (file.Take (3).SequenceEqual (SWF)) {
        mime = "application/x-shockwave-flash";
    } else if (file.Take (4).SequenceEqual (TIFF)) {
        mime = "image/tiff";
    } else if (file.Take (11).SequenceEqual (TORRENT)) {
        mime = "application/x-bittorrent";
    } else if (file.Take (5).SequenceEqual (TTF)) {
        mime = "application/x-font-ttf";
    } else if (file.Take (4).SequenceEqual (WAV_AVI)) {
        mime = extension == ".AVI" ? "video/x-msvideo" : "audio/x-wav";
    } else if (file.Take (16).SequenceEqual (WMV_WMA)) {
        mime = extension == ".WMA" ? "audio/x-ms-wma" : "video/x-ms-wmv";
    } else if (file.Take (4).SequenceEqual (ZIP_DOCX)) {
        mime = extension == ".DOCX" ? "application/vnd.openxmlformats-officedocument.wordprocessingml.document" : "application/x-zip-compressed";
    }
    return mime;
}

