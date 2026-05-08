/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14876345
*  Stack Overflow answer #:14878216
*  And Stack Overflow answer#:14878216
*/
public static void moveMouse (ref int currentx, ref int currenty, string whattodo, int pNombre) {
    switch (whattodo) {
        case "addX" :
            for (int i = 0; i < pNombre; i ++) {
                currentx ++;
                SetCursorPos (currentx + Form1.m_Border_x, currenty + Form1.m_Border_y);
            }
            break;
        case "addY" :
            for (int i = 0; i < pNombre; i ++) {
                currenty ++;
                SetCursorPos (currentx + Form1.m_Border_x, currenty + Form1.m_Border_y);
            }
            break;
        case "remX" :
            for (int i = 0; i < pNombre; i ++) {
                currentx --;
                SetCursorPos (currentx + Form1.m_Border_x, currenty + Form1.m_Border_y);
            }
            break;
        case "remY" :
            for (int i = 0; i < pNombre; i ++) {
                currenty --;
                SetCursorPos (currentx + Form1.m_Border_x, currenty + Form1.m_Border_y);
            }
            break;
        default :
            break;
    }
}

public static void DoMouseRightClickOp1 (int nx, int ny) {
    Random objRandom = new Random ();
    SetCursorPos (nx + Form1.m_Border_x, ny + Form1.m_Border_y);
    mouse_event (MOUSEEVENTF_RIGHTDOWN, nx + Form1.m_Border_x, ny + Form1.m_Border_y, 0, 0);
    Thread.Sleep (objRandom.Next (6, 237));
    mouse_event (MOUSEEVENTF_RIGHTUP, nx + Form1.m_Border_x, ny + Form1.m_Border_y, 0, 0);
    Handler.getFocus ();
    Thread.Sleep (objRandom.Next (1, 332));
    moveMouse (ref nx, ref ny, "addY", 20);
    DoMouseLeftClick (nx, ny);
}

