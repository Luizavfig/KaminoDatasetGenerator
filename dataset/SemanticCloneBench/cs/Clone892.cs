/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32125570
*  Stack Overflow answer #:32229159
*  And Stack Overflow answer#:32125787
*/
protected void btnNext_Click1 (object sender, EventArgs e) {
    DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter ();
    DataTable dt = new DataTable ();
    if (txtNextStep.Tag == null)
        dt = eobj.GetTicketFirstUpdate (txtSupportRef.Text);
    else
        dt = eobj.GetNextTicketUpdate (txtSupportRef.Text, (string) txtNextStep.Tag);
    if (dt.Rows.Count != 0) {
        txtNextStep.Text = dt.Rows [0] ["NextStep"].ToString ();
        txtNextStep.Tag = dt.Rows [0] ["Id"].ToString ();
    }
}

protected void btnPrevious_Click1 (object sender, EventArgs e) {
    if (Session ["ClickCount"] == null)
        Session ["ClickCount"] = 0;
    int ClickCount = Convert.ToInt32 (Session ["ClickCount"]) + 1;
    Session ["ClickCount"] = ClickCount;
    DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter ();
    DataTable dt = new DataTable ();
    eobj.GetTicketUpdates (txtSupportRef.Text);
    txtNextStep.Text = eobj.GetTicketData (txtSupportRef.Text).Rows [ClickCount - 1] ["NextStep"].ToString ();
}

