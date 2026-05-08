/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:428494
*  Stack Overflow answer #:10724744
*  And Stack Overflow answer#:428556
*/
public static void ShowWithParentFormLock (this Form childForm, Form parentForm, Action actionAfterClose) {
    if (childForm == null)
        throw new ArgumentNullException ("childForm");
    if (parentForm == null)
        throw new ArgumentNullException ("parentForm");
    EventHandler activatedDelegate = (object sender, EventArgs e) = > {
        childForm.Focus ();
    };
    childForm.FormClosed += (sender, closedEventArgs) = > {
        try {
            parentForm.Focus ();
            if (actionAfterClose != null)
                actionAfterClose ();
        }
        finally {
            try {
                parentForm.Activated -= activatedDelegate;
                if (! childForm.IsDisposed || ! childForm.Disposing)
                    childForm.Dispose ();
            }
            catch {
            }
        }
    };
    parentForm.Activated += activatedDelegate;
    childForm.Show (parentForm);
}

[STAThread] static void Main () {
    Application.EnableVisualStyles ();
    Button loadB, loadC;
    Form formA = new Form {Text = "Form A", Controls = {(loadC = new Button {Text = "Load C", Dock = DockStyle.Top}), (loadB = new Button {Text = "Load B", Dock = DockStyle.Top})}};
    loadC.Click += delegate {
        Form formC = new Form {Text = "Form C"};
        formC.Show (formA);
    };
    loadB.Click += delegate {
        Thread thread = new Thread (() = > {
            Button loadD;
            Form formB = new Form {Text = "Form B", Controls = {(loadD = new Button {Text = "Load D", Dock = DockStyle.Top})}};
            loadD.Click += delegate {
                Form formD = new Form {Text = "Form D"};
                formD.ShowDialog (formB);
            };
            formB.ShowDialog ();
        });
        thread.SetApartmentState (ApartmentState.STA);
        thread.Start ();
    };
    Application.Run (formA);
}

