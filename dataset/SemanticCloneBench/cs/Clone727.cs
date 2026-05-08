/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1772614
*  Stack Overflow answer #:1772834
*  And Stack Overflow answer#:1772687
*/
static void Main (string [] args) {
    lacie BackupDrive = new lacie ();
    BackupDrive.findLacie ();
    xml xmlFile = new xml ();
    xmlFile.ProcessXML ();
    size BackupSize = new size ();
    System.Threading.ThreadPool.QueueUserWorkItem (s = > {
        BackupSize.GetSize (xmlFile.Path);
    });
    int SizeofBackup = (int) (((BackupSize.BackupSize) / 1024f) / 1024f) / 1024;
    Console.WriteLine ("Drive Letter: " + BackupDrive.Drive);
    Console.WriteLine ("Volume Name: " + BackupDrive.VolumeLabel);
    Console.WriteLine ("Free Space: " + Convert.ToString (BackupDrive.AvailableSize) + "G");
    Console.WriteLine ("Size of Lacie: " + Convert.ToString (BackupDrive.TotalSize) + "G");
    Console.WriteLine ("Backup Size: " + Convert.ToString (SizeofBackup + "G"));
    Console.WriteLine ("Backing up " + BackupSize.FileCount + " files found in " + BackupSize.FolderCount + " folders.");
    Console.ReadKey (true);
}

void thread1_Thread1Completed (object sender, AsyncCompletedEventArgs e) {
    if (this.InvokeRequired) {
        BeginInvoke (new AsyncCompletedEventHandler (thread1_Thread1Completed), new object [] {sender, e});
    } else {
        if (e.Error == null) {
            MessageBox.Show ("Worker thread completed successfully");
            DataYouWantToReturn someData = e.UserState as DataYouWantToReturn;
            MessageBox.Show ("Your data my lord: " + someData.someProperty);
        } else {
            MessageBox.Show ("The following error occurred:" + Environment.NewLine + e.Error.ToString ());
        }
    }
}

