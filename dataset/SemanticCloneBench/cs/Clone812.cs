/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16693593
*  Stack Overflow answer #:16693936
*  And Stack Overflow answer#:16693936
*/
public void GenereateSettingsFile (List < Node > nodeList, string filePath) {
    _rootNode.RemoveChild (_userNode);
    _userNode = _xmlDoc.CreateElement ("Display_Settings");
    _rootNode.AppendChild (_userNode);
    foreach (Node n in nodeList) {
        foreach (XmlElement e in n.GenerateXML (_xmlDoc)) {
            _userNode.AppendChild (e);
        }
    }
    _xmlDoc.Save (filePath);
}

private void saveAsToolStripMenuItem_Click (object sender, EventArgs e) {
    using (SaveFileDialog dialog = new SaveFileDialog ())
    {
        dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        dialog.FilterIndex = 2;
        dialog.RestoreDirectory = true;
        if (dialog.ShowDialog () == DialogResult.OK) {
            inmo.GenereateSettingsFile (_nodeList, dialog.FileName);
        }
    }}

