/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6171705
*  Stack Overflow answer #:6773243
*  And Stack Overflow answer#:35132933
*/
[STAThread] static void Main () {
    Form dummyForm = null;
    dummyForm = new Form () {ShowInTaskbar = false, WindowState = FormWindowState.Minimized};
    dummyForm.Show ();
    dummyForm.TopMost = true;
    dummyForm.TopMost = false;
    OpenFileDialog ofd = new OpenFileDialog ();
    ofd.ShowDialog (dummyForm);
    SaveFileDialog sfd = new SaveFileDialog ();
    sfd.ShowDialog (dummyForm);
}

[STAThread] static void Main (string [] args) {
    var threadFolderBrowserDialog = new Thread (voidFolderBrowserDialog);
    threadFolderBrowserDialog.IsBackground = true;
    threadFolderBrowserDialog.SetApartmentState (ApartmentState.STA);
    threadFolderBrowserDialog.Start ();
    Console.WriteLine ("Запу�?к выбора папки и файла в новом потоке");
    bool Exit = false;
    while (! Exit) {
        var exit = Console.ReadLine () == "exit" ? Exit = true : Exit = false;
        Console.WriteLine ("Выход из программы по команде exit");
    }
}

