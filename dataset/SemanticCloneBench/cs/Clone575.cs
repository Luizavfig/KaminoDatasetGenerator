/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20676185
*  Stack Overflow answer #:20679895
*  And Stack Overflow answer#:44689035
*/
public override bool Update (float deltaTime) {
    CurrentFramesPerSecond = 1.0f / deltaTime;
    _sampleBuffer.Enqueue (CurrentFramesPerSecond);
    if (_sampleBuffer.Count > MAXIMUM_SAMPLES) {
        _sampleBuffer.Dequeue ();
        AverageFramesPerSecond = _sampleBuffer.Average (i = > i);
    } else {
        AverageFramesPerSecond = CurrentFramesPerSecond;
    }
    TotalFrames ++;
    TotalSeconds += deltaTime;
    return true;
}

public void Update (double timeSinceLastFrame) {
    currentFrame ++;
    if (currentFrame >= frametimes.Length) {
        currentFrame = 0;
    }
    currentFrametimes -= frametimes [currentFrame];
    frametimes [currentFrame] = timeSinceLastFrame;
    currentFrametimes += frametimes [currentFrame];
}

