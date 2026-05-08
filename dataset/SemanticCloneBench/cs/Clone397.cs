/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:721201
*  Stack Overflow answer #:37000110
*  And Stack Overflow answer#:34935611
*/
public static int Asc (char String) {
    int num1 = Convert.ToInt32 (String);
    if (num1 < 128)
        return num1;
    try {
        Encoding fileIoEncoding = Utils.GetFileIOEncoding ();
        char [] chars = new char [1] {String};
        if (fileIoEncoding.IsSingleByte) {
            byte [] bytes = new byte [1];
            fileIoEncoding.GetBytes (chars, 0, 1, bytes, 0);
            return (int) bytes [0];
        }
        byte [] bytes1 = new byte [2];
        if (fileIoEncoding.GetBytes (chars, 0, 1, bytes1, 0) == 1)
            return (int) bytes1 [0];
        if (BitConverter.IsLittleEndian) {
            byte num2 = bytes1 [0];
            bytes1 [0] = bytes1 [1];
            bytes1 [1] = num2;
        }
        return (int) BitConverter.ToInt16 (bytes1, 0);
    }
    catch (Exception ex) {
        throw ex;
    }
}

static int Asc (char c) {
    int converted = c;
    if (converted >= 0x80) {
        byte [] buffer = new byte [2];
        if (System.Text.Encoding.Default.GetBytes (new char [] {c}, 0, 1, buffer, 0) == 1) {
            converted = buffer [0];
        } else {
            converted = buffer [0] << 16 | buffer [1];
        }
    }
    return converted;
}

