/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32787230
*  Stack Overflow answer #:39839533
*  And Stack Overflow answer#:32803366
*/
public void SendEmail (MyInternalSystemEmailMessage email) {
    var mailMessage = new System.Net.Mail.MailMessage ();
    mailMessage.From = new System.Net.Mail.MailAddress (email.FromAddress);
    mailMessage.To.Add (email.ToRecipients);
    mailMessage.ReplyToList.Add (email.FromAddress);
    mailMessage.Subject = email.Subject;
    mailMessage.Body = email.Body;
    mailMessage.IsBodyHtml = email.IsHtml;
    foreach (System.Net.Mail.Attachment attachment in email.Attachments) {
        mailMessage.Attachments.Add (attachment);
    }
    var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage (mailMessage);
    var gmailMessage = new Google.Apis.Gmail.v1.Data.Message {Raw = Encode (mimeMessage.ToString ())};
    Google.Apis.Gmail.v1.UsersResource.MessagesResource.SendRequest request = service.Users.Messages.Send (gmailMessage, ServiceEmail);
    request.Execute ();
}

public void SendIt () {
    var msg = new AE.Net.Mail.MailMessage {Subject = "Your Subject", Body = "Hello, World, from Gmail API!", From = new MailAddress ("[you]@gmail.com")};
    msg.To.Add (new MailAddress ("yourbuddy@gmail.com"));
    msg.ReplyTo.Add (msg.From);
    var msgStr = new StringWriter ();
    msg.Save (msgStr);
    var gmail = new GmailService (Context.GoogleOAuthInitializer);
    var result = gmail.Users.Messages.Send (new Message {Raw = Base64UrlEncode (msgStr.ToString ())}, "me").Execute ();
    Console.WriteLine ("Message ID {0} sent.", result.Id);
}

