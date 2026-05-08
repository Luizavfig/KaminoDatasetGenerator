/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:40014094
*  Stack Overflow answer #:40084113
*  And Stack Overflow answer#:40098304
*/
public void deleteFromDatabase (int denom_id) {
    var realm = Realm.GetInstance (config);
    var denom = realm.All < CashDenomination > ().FirstOrDefault (c = > c.denom_id == denom_id);
    if (denom == null)
        return;
    using (var transaction = realm.BeginWrite ())
    {
        realm.Remove (denom);
        transaction.Commit ();
    }}

public void deleteFromDatabase (int denom_ID, int form_ID) {
    realm = Realm.GetInstance (config);
    realm.Write (() = > {
        var cashflow_denom = realm.All < CashDenomination > ().Where (c = > c.denom_id == denom_ID);
        var cashflow_form = realm.All < CashForm > ().Where (c = > c.form_id == form_ID);
        realm.RemoveRange (((RealmResults < CashDenomination >) cashflow_denom));
        realm.RemoveRange (((RealmResults < CashForm >) cashflow_form));
    });
}

