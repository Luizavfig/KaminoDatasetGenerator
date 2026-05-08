/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38638258
*  Stack Overflow answer #:38638914
*  And Stack Overflow answer#:38638521
*/
private void btnAddDriver_Click (object sender, RoutedEventArgs e) {
    decimal policy = 500M;
    decimal Chauffeur = 0.10M;
    decimal Accountant = 0.10M;
    decimal age2125 = 0.20M;
    decimal age2675 = 0.10M;
    if (cmbOccupation.SelectedItem.ToString () == Occumpation.Chauffeur.ToString ()) {
        policy += policy * Chauffeur;
    } else if (cmbOccupation.SelectedItem.ToString () == Occumpation.Accountant.ToString ()) {
        policy -= policy * Accountant;
    }
    DateTime ? birthDate = dpkDOB.SelectedDate;
    if (birthDate != null) {
        if (birthDate.Age ().Years () > 21 && birthDate.Age ().Years () < 26) {
            policy += policy * age2125;
        } else if (birthDate.Age ().Years () > 26 && birthDate.Age ().Years () < 76) {
            policy -= policy * age2675;
        }
    }
    txtPolicy.Text = policy.ToString ();
}

private void btnAddDriver_Click (object sender, RoutedEventArgs e) {
    double tempPolicy = policy;
    if (cmbOccupation.SelectedItem.ToString () == Occumpation.Chauffeur.ToString ()) {
        tempPolicy = (tempPolicy + tempPolicy * Chauffeur);
        txtPolicy.Text = tempPolicy.ToString ();
    } else if (cmbOccupation.SelectedItem.ToString () == Occumpation.Accountant.ToString ()) {
        tempPolicy = (tempPolicy - tempPolicy * Accountant);
        txtPolicy.Text = tempPolicy.ToString ();
    }
    DateTime birthDate = Convert.ToDateTime (dpkDOB.SelectedDate);
    if (birthDate.Age ().Years () > 21 && birthDate.Age ().Years () < 26) {
        tempPolicy = (tempPolicy + tempPolicy * age2125);
        txtPolicy.Text = tempPolicy.ToString ();
    } else if (birthDate.Age ().Years () > 26 && birthDate.Age ().Years () < 76) {
        tempPolicy = (tempPolicy - tempPolicy * age2675);
        txtPolicy.Text = tempPolicy.ToString ();
    }
}

