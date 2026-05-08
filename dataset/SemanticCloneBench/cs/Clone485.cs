/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4137552
*  Stack Overflow answer #:4137901
*  And Stack Overflow answer#:4137922
*/
public void Send () {
    if (String.IsNullOrEmpty (Server)) {
        throw new PreferenceNotSetException ("Server not set");
    }
    if (String.IsNullOrEmpty (From)) {
        throw new PreferenceNotSetException ("Sender's E-Mail address not set.");
    }
    if (String.IsNullOrEmpty (To)) {
        throw new PreferenceNotSetException ("Recipient's E-Mail address not set.");
    }
    using (MailMessage message = new MailMessage (From, To, Subject, FormattedText))
    {
        message.IsBodyHtml = true;
        using (SmtpClient client = new SmtpClient (Server))
        {
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            int temp = ServicePointManager.MaxServicePointIdleTime;
            ServicePointManager.MaxServicePointIdleTime = 1;
            try {
                client.Send (message);
            }
            catch (Exception ex) {
                MessageBox.Show (ex.ToString ());
            }
            finally {
                ServicePointManager.MaxServicePointIdleTime = temp;
            }
        }}}

public void Send () {
    if (string.IsNullOrEmpty (this.Server)) {
        throw new PreferenceNotSetException ("Server not set");
    }
    if (string.IsNullOrEmpty (this.From)) {
        throw new PreferenceNotSetException ("E-Mail address not set.");
    }
    if (string.IsNullOrEmpty (this.To)) {
        throw new PreferenceNotSetException ("Recipients E-Mail address not set.");
    }
    using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage (this.From, this.To, this.Subject, this.FormattedText))
    {
        message.IsBodyHtml = true;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient (this.Server);
        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        try {
            client.Send (message);
        }
        catch (System.Exception ex) {
            System.Windows.Forms.MessageBox.Show (ex.ToString ());
        }
    }}

