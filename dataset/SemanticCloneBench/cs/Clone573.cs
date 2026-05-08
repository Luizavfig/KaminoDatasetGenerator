/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30579938
*  Stack Overflow answer #:30769789
*  And Stack Overflow answer#:39056970
*/
void SignXml (XmlDocument xmlDoc, RSA Key) {
    SignedXml signedXml = new SignedXml (xmlDoc);
    signedXml.SigningKey = Key;
    Reference reference = new Reference ("");
    reference.AddTransform (new XmlDsigEnvelopedSignatureTransform ());
    signedXml.AddReference (reference);
    signedXml.ComputeSignature ();
    XmlElement xmlSignature = signedXml.GetXml ();
    AssignNameSpacePrefixToElementTree (xmlSignature, "ds");
    xmlDoc.DocumentElement.AppendChild (xmlDoc.ImportNode (xmlSignature, true));
}

public static void SignXml (XmlDocument xmlDoc, X509Certificate2 cert) {
    RSACryptoServiceProvider key;
    SignedXml signedXml = new SignedXml (xmlDoc);
    signedXml.SigningKey = key;
    signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
    signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
    Reference reference = new Reference ();
    reference.Uri = "#foo";
    reference.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
    reference.AddTransform (new XmlDsigEnvelopedSignatureTransform ());
    reference.AddTransform (new XmlDsigExcC14NTransform ());
    signedXml.AddReference (reference);
    KeyInfo keyInfo = new KeyInfo ();
    KeyInfoX509Data keyInfoData = new KeyInfoX509Data ();
    keyInfoData.AddIssuerSerial (cert.IssuerName.Format (false), cert.SerialNumber);
    keyInfo.AddClause (keyInfoData);
    signedXml.KeyInfo = keyInfo;
    signedXml.ComputeSignature ();
    XmlElement signature = signedXml.GetXml ();
    SetPrefix ("ds", signature);
    signedXml.LoadXml (signature);
    signedXml.SignedInfo.References.Clear ();
    signedXml.ComputeSignature ();
    string recomputedSignature = Convert.ToBase64String (signedXml.SignatureValue);
    ReplaceSignature (signature, recomputedSignature);
    xmlDoc.DocumentElement.InsertAfter (xmlDoc.ImportNode (signature, true), xmlDoc.DocumentElement.FirstChild);
}

