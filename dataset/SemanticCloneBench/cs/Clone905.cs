/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6591090
*  Stack Overflow answer #:28606299
*  And Stack Overflow answer#:29827054
*/
public static bool IsWindowOnAnyScreen (Window Window, short WindowSizeX, short WindowSizeY, bool AutoAdjustWindow) {
    var Screen = System.Windows.Forms.Screen.FromHandle (new WindowInteropHelper (Window).Handle);
    bool LeftSideTest = false, TopSideTest = false, BottomSideTest = false, RightSideTest = false;
    if (Window.Left >= Screen.WorkingArea.Left)
        LeftSideTest = true;
    if (Window.Top >= Screen.WorkingArea.Top)
        TopSideTest = true;
    if ((Window.Top + WindowSizeY) <= Screen.WorkingArea.Bottom)
        BottomSideTest = true;
    if ((Window.Left + WindowSizeX) <= Screen.WorkingArea.Right)
        RightSideTest = true;
    if (LeftSideTest && TopSideTest && BottomSideTest && RightSideTest)
        return true;
    else {
        if (AutoAdjustWindow) {
            if (! LeftSideTest)
                Window.Left = Window.Left - (Window.Left - Screen.WorkingArea.Left);
            if (! TopSideTest)
                Window.Top = Window.Top - (Window.Top - Screen.WorkingArea.Top);
            if (! BottomSideTest)
                Window.Top = Window.Top - ((Window.Top + WindowSizeY) - Screen.WorkingArea.Bottom);
            if (! RightSideTest)
                Window.Left = Window.Left - ((Window.Left + WindowSizeX) - Screen.WorkingArea.Right);
        }
    }
    return false;
}

static bool WindowAllVisible (Rectangle windowRectangle) {
    int areaOfWindow = windowRectangle.Width * windowRectangle.Height;
    int areaVisible = 0;
    foreach (Screen screen in Screen.AllScreens) {
        Rectangle windowPortionOnScreen = screen.WorkingArea;
        windowPortionOnScreen.Intersect (windowRectangle);
        areaVisible += windowPortionOnScreen.Width * windowPortionOnScreen.Height;
        if (areaVisible >= areaOfWindow) {
            return true;
        }
    }
    return false;
}

