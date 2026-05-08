/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:278071
*  Stack Overflow answer #:6168408
*  And Stack Overflow answer#:278505
*/
private void Timer1_Tick (Object sender, EventArgs e) {
    int cpuPercent = getCPUCounter ();
    if (cpuPercent >= 90) {
        totalHits = totalHits + 1;
        if (totalHits == 60) {
            Interaction.MsgBox ("ALERT 90% usage for 1 minute");
            totalHits = 0;
        }
    } else {
        totalHits = 0;
    }
    Label1.Text = cpuPercent + " % CPU";
    Label2.Text = getRAMCounter () + " RAM Free";
    Label3.Text = totalHits + " seconds over 20% usage";
}

private static int GetProcessorIdleTime (string selectedServer) {
    try {
        var searcher = new ManagementObjectSearcher (@"\\" + selectedServer + @"\root\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name=\"_Total\"");
        ManagementObjectCollection collection = searcher.Get ();
        ManagementObject queryObj = collection.Cast < ManagementObject > ().First ();
        return Convert.ToInt32 (queryObj ["PercentIdleTime"]);
    }
    catch (ManagementException e) {
        MessageBox.Show ("An error occurred while querying for WMI data: " + e.Message);
    }
    return - 1;
}

