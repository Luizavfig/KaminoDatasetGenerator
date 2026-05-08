/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44402898
*  Stack Overflow answer #:44415788
*  And Stack Overflow answer#:44540868
*/
private void Dispose (bool disposing) {
    if (! disposedValue) {
        if (disposing) {
        }
        if (m_freeStack != null) {
            SharpDX.Direct3D11.Texture2D texture;
            while (m_freeStack.TryPop (out texture)) {
                texture.Dispose ();
            }
            m_freeStack = null;
        }
        disposedValue = true;
    }
}

protected virtual void Dispose (bool disposing) {
    if (! disposedValue) {
        if (disposing) {
        }
        if (m_pDebugTexture != null) {
            m_pDebugTexture.Dispose ();
        }
        disposedValue = true;
    }
}

