/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2178240
*  Stack Overflow answer #:16239389
*  And Stack Overflow answer#:16239389
*/
protected override void OnPaint (PaintEventArgs pevent) {
    CheckBoxRenderer.DrawParentBackground (pevent.Graphics, pevent.ClipRectangle, this);
    RadioButtonState radioButtonState;
    if (Checked) {
        radioButtonState = RadioButtonState.CheckedNormal;
        if (Focused)
            radioButtonState = RadioButtonState.CheckedHot;
        if (! Enabled)
            radioButtonState = RadioButtonState.CheckedDisabled;
    } else {
        radioButtonState = RadioButtonState.UncheckedNormal;
        if (Focused)
            radioButtonState = RadioButtonState.UncheckedHot;
        if (! Enabled)
            radioButtonState = RadioButtonState.UncheckedDisabled;
    }
    Size glyphSize = RadioButtonRenderer.GetGlyphSize (pevent.Graphics, radioButtonState);
    Rectangle rect = pevent.ClipRectangle;
    rect.Width -= glyphSize.Width;
    rect.Location = new Point (rect.Left + glyphSize.Width, rect.Top);
    RadioButtonRenderer.DrawRadioButton (pevent.Graphics, new System.Drawing.Point (0, rect.Height / 2 - glyphSize.Height / 2), rect, this.Text, this.Font, this.Focused, radioButtonState);
}

protected override void OnCheckedChanged (EventArgs e) {
    base.OnCheckedChanged (e);
    if (Checked) {
        var arbControls = (dynamic) null;
        switch (GroupNameLevel) {
            case Level.Parent :
                if (this.Parent != null)
                    arbControls = GetAll (this.Parent, typeof (AdvancedRadioButton));
                break;
            case Level.Form :
                Form form = this.FindForm ();
                if (form != null)
                    arbControls = GetAll (this.FindForm (), typeof (AdvancedRadioButton));
                break;
        }
        if (arbControls != null)
            foreach (Control control in arbControls)
                if (control != this && (control as AdvancedRadioButton).GroupName == this.GroupName)
                    (control as AdvancedRadioButton).Checked = false;
    }
}

