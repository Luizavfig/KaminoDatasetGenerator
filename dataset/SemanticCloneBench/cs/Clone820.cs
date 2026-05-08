/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31828907
*  Stack Overflow answer #:36061935
*  And Stack Overflow answer#:36061935
*/
protected override void OnRender (DrawingContext drawingContext) {
    ensureTextBlock ();
    base.OnRender (drawingContext);
    var formattedText = new FormattedText (_textBlock.Text, CultureInfo.CurrentUICulture, _textBlock.FlowDirection, new Typeface (_textBlock.FontFamily, _textBlock.FontStyle, _textBlock.FontWeight, _textBlock.FontStretch), _textBlock.FontSize, Brushes.Black);
    formattedText.TextAlignment = _textBlock.TextAlignment;
    formattedText.Trimming = _textBlock.TextTrimming;
    formattedText.LineHeight = _textBlock.LineHeight;
    formattedText.MaxTextWidth = _textBlock.ActualWidth - _textBlock.Padding.Left - _textBlock.Padding.Right;
    formattedText.MaxTextHeight = _textBlock.ActualHeight - _textBlock.Padding.Top;
    while (formattedText.Extent == double.NegativeInfinity) {
        formattedText.MaxTextHeight ++;
    }
    var _textGeometry = formattedText.BuildGeometry (new Point (_textBlock.Padding.Left, _textBlock.Padding.Top));
    var textPen = new Pen (Stroke, StrokeThickness);
    drawingContext.DrawGeometry (Brushes.Transparent, textPen, _textGeometry);
}

private void StrokeTextBlock_LayoutUpdated (object sender, EventArgs e) {
    if (_adorned)
        return;
    _adorned = true;
    var adornerLayer = AdornerLayer.GetAdornerLayer (this);
    adornerLayer.Add (_adorner);
    this.LayoutUpdated -= StrokeTextBlock_LayoutUpdated;
}

