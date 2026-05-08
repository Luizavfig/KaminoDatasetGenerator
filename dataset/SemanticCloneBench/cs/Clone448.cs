/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3569783
*  Stack Overflow answer #:3571165
*  And Stack Overflow answer#:3570303
*/
static void Main (string [] args) {
    long NumberToEncode = (new Random ()).Next ();
    Console.WriteLine ("Number to encode = {0}.", NumberToEncode);
    byte [] Key = new byte [24];
    (new RNGCryptoServiceProvider ()).GetBytes (Key);
    Console.WriteLine ("Key to encode with is {0}.", ToHex (Key));
    string EncodedValue = Encode (NumberToEncode, Key);
    Console.WriteLine ("The encoded value is {0}.", EncodedValue);
    long DecodedValue;
    bool Success = TryDecode (EncodedValue, Key, out DecodedValue);
    if (Success) {
        Console.WriteLine ("Successfully decoded the encoded value.");
        Console.WriteLine ("The decoded result is {0}.", DecodedValue);
    } else
        Console.WriteLine ("Failed to decode encoded value. Invalid result.");
}

static void Main (string [] args) {
    int theId = 1234;
    byte [] byteArray;
    string encryptedString = Crypto.EncryptStringAES (theId.ToString (), "mysecret");
    Console.WriteLine ("{0} get encrypted as {1}", theId.ToString (), encryptedString);
    byteArray = ASCIIEncoding.Default.GetBytes (encryptedString);
    StringBuilder result = new StringBuilder ();
    foreach (byte outputByte in byteArray) {
        result.Append (outputByte.ToString ("x2"));
    }
    Console.WriteLine ("{0} encrypted is this in hex {1}", encryptedString, result.ToString ());
    int stringLength = result.Length;
    byte [] bytes = new byte [stringLength / 2];
    for (int i = 0; i < stringLength; i += 2) {
        bytes [i / 2] = System.Convert.ToByte (result.ToString ().Substring (i, 2), 16);
    }
    string dehexedString = ASCIIEncoding.Default.GetString (bytes);
    Console.WriteLine ("{0} gets dehexed as {1}", result, dehexedString);
    string decryptedString = Crypto.DecryptStringAES (dehexedString, "mysecret");
    Console.WriteLine ("{0} got decrypted as {1}", dehexedString, decryptedString);
    Console.ReadLine ();
}

