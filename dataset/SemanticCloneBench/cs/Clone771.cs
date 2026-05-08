/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8846136
*  Stack Overflow answer #:8847067
*  And Stack Overflow answer#:8846176
*/
private void Interval (object sender, EventArgs e) {
    if (cbPause.Checked) {
        randomLine = random.Next (lbMessage.Items.Count);
        tmrSpace.Enabled = true;
        if (whenStart)
            tickCount ++;
        else
            whenStart = true;
    } else {
        if (cbRandomLine.Checked) {
            SendKeys.Send (lbMessage.Items [random.Next (lbMessage.Items.Count)].ToString () + "{enter}");
        } else {
            if (tickCount < lbMessage.Items.Count) {
                SendKeys.Send (lbMessage.Items [tickCount].ToString () + "{enter}");
                tickCount ++;
            }
        }
    }
    if (tickCount == lbMessage.Items.Count)
        tickCount = 0;
    SetInterval ();
}

private void Space (object sender, EventArgs e) {
    if (cbRandomLine.Checked || tickCount < lbMessage.Items.Count) {
        var index = cbRandomLine.Checked ? randomLine : tickCount;
        var item = lbMessage.Items [index].ToString ();
        SendKeys.Send (item.Substring (currentChar ++, 1));
        if (currentChar == item.Length) {
            SendKeys.Send ("{enter}");
            tmrSpace.Enabled = false;
            currentChar = 0;
        }
    }
    tmrSpace.Interval = random.Next (50, 100);
}

