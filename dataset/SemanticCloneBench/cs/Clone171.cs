/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45729647
*  Stack Overflow answer #:45730728
*  And Stack Overflow answer#:45730782
*/
private void btnAdd_Click (object sender, RoutedEventArgs e) {
    string customer = btnEditCustomer1.Text;
    string piece = btnPiece.Text;
    string material = txtMaterial.Text;
    int quantity = Convert.ToInt32 (txtQuantity.Text);
    float weight = float.Parse (txtWeight.Text);
    if (customer != null && piece != null && material != null) {
        var item = new Liste {Customer = customer, Piece = piece, Material = material, Quantity = quantity, Weight = weight};
        AllItems.Add (item);
    }
}

private void btnAdd_Click (object sender, RoutedEventArgs e) {
    float weight;
    int quantity;
    string customer, piece, material;
    customer = btnEditCustomer1.Text;
    piece = btnPiece.Text;
    material = txtMaterial.Text;
    quantity = Convert.ToInt32 (txtQuantity.Text);
    weight = float.Parse (txtWeight.Text);
    if (customer != null && piece != null && material != null) {
        Liste kayit = new Liste ();
        kayit.Customer = customer;
        kayit.Piece = piece;
        kayit.Material = material;
        kayit.Quantity = quantity;
        kayit.Weight = weight;
        list.Add (kayit);
    }
}

