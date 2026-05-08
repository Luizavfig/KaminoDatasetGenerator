/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24911004
*  Stack Overflow answer #:24911177
*  And Stack Overflow answer#:24911291
*/
public static string Encrypt (string strPlainText) {
    System.Text.Encoding enc = System.Text.Encoding.UTF8;
    System.Security.Cryptography.RijndaelManaged objRijndael = new System.Security.Cryptography.RijndaelManaged ();
    byte [] baCipherTextBuffer = null;
    byte [] baPlainTextBuffer = null;
    byte [] baEncryptionKey = null;
    byte [] baInitializationVector = null;
    objRijndael.Key = HexStringToByteArray (strKey);
    objRijndael.IV = HexStringToByteArray (strIV);
    baEncryptionKey = objRijndael.Key;
    baInitializationVector = objRijndael.IV;
    System.Security.Cryptography.ICryptoTransform ifaceAESencryptor = objRijndael.CreateEncryptor (baEncryptionKey, baInitializationVector);
    System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream ();
    System.Security.Cryptography.CryptoStream csEncrypt = new System.Security.Cryptography.CryptoStream (msEncrypt, ifaceAESencryptor, System.Security.Cryptography.CryptoStreamMode.Write);
    baPlainTextBuffer = enc.GetBytes (strPlainText);
    csEncrypt.Write (baPlainTextBuffer, 0, baPlainTextBuffer.Length);
    csEncrypt.FlushFinalBlock ();
    baCipherTextBuffer = msEncrypt.ToArray ();
    return ByteArrayToHexString (baCipherTextBuffer);
}

public static bool Encrypt (ConfigurationSectionType section) {
    bool result = false;
    Configuration config = ConfigurationManager.OpenExeConfiguration (ConfigurationUserLevel.None);
    if (config == null)
        throw new Exception ("Cannot open the configuration file.");
    if (section.HasFlag (ConfigurationSectionType.ConnectionStrings)) {
        result = result || EncryptSection (config, "connectionStrings");
    }
    if (section.HasFlag (ConfigurationSectionType.ApplicationSettings)) {
        result = result || EncryptSection (config, "appSettings");
    }
    return result;
}

