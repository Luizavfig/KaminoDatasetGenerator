/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24911004
*  Stack Overflow answer #:24911177
*  And Stack Overflow answer#:24911177
*/
public static string DeCrypt (string strEncryptedInput) {
    string strReturnValue = null;
    if (string.IsNullOrEmpty (strEncryptedInput)) {
        throw new ArgumentNullException ("strEncryptedInput", "strEncryptedInput may not be string.Empty or NULL, because these are invid values.");
    }
    System.Text.Encoding enc = System.Text.Encoding.UTF8;
    System.Security.Cryptography.RijndaelManaged objRijndael = new System.Security.Cryptography.RijndaelManaged ();
    byte [] baCipherTextBuffer = HexStringToByteArray (strEncryptedInput);
    byte [] baDecryptionKey = HexStringToByteArray (strKey);
    byte [] baInitializationVector = HexStringToByteArray (strIV);
    System.Security.Cryptography.ICryptoTransform ifaceAESdecryptor = objRijndael.CreateDecryptor (baDecryptionKey, baInitializationVector);
    System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream (baCipherTextBuffer);
    System.Security.Cryptography.CryptoStream csDecrypt = new System.Security.Cryptography.CryptoStream (msDecrypt, ifaceAESdecryptor, System.Security.Cryptography.CryptoStreamMode.Read);
    byte [] baPlainTextBuffer = new byte [baCipherTextBuffer.Length + 1];
    csDecrypt.Read (baPlainTextBuffer, 0, baPlainTextBuffer.Length);
    strReturnValue = enc.GetString (baPlainTextBuffer);
    if (! string.IsNullOrEmpty (strReturnValue))
        strReturnValue = strReturnValue.Trim ('\0');
    return strReturnValue;
}

public static string DeCrypt (string SourceText) {
    string strReturnValue = "";
    if (string.IsNullOrEmpty (SourceText)) {
        return strReturnValue;
    }
    using (System.Security.Cryptography.TripleDESCryptoServiceProvider Des = new System.Security.Cryptography.TripleDESCryptoServiceProvider ())
    {
        using (System.Security.Cryptography.MD5CryptoServiceProvider HashMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider ())
        {
            Des.Key = HashMD5.ComputeHash (System.Text.Encoding.UTF8.GetBytes (strSymmetricKey));
            Des.Mode = System.Security.Cryptography.CipherMode.ECB;
            System.Security.Cryptography.ICryptoTransform desdencrypt = Des.CreateDecryptor ();
            byte [] buff = System.Convert.FromBase64String (SourceText);
            strReturnValue = System.Text.Encoding.UTF8.GetString (desdencrypt.TransformFinalBlock (buff, 0, buff.Length));
        }} return strReturnValue;
}

