/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:50987054
*  Stack Overflow answer #:50988961
*  And Stack Overflow answer#:50987180
*/
void Update () {
    if (triggerActive) {
        timecountdown -= Time.deltaTime;
        if (timecountdown <= 0.0f) {
            timecountdown = 8.0f;
            teleport = 1;
            triggerActive = false;
        }
    } else {
        teleport = 0;
        timecountdown = 8.0f;
    }
}

void Update () {
    if (timer1 == 0)
        ;
    {
        teleport = 0;
    } if (timer1 == 1)
        ;
    {
        timecountdown -= Time.deltaTime;
        if (timecountdown <= 0.0f)
            ;
        {
            teleport = 1;
            timer1 = 0;
            timecountdown = 8f;
        }}}

