/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16324208
*  Stack Overflow answer #:16324295
*  And Stack Overflow answer#:16324275
*/
public bool DoThisJob (string job, int numberOfShifts) {
    if (! String.IsNullOrEmpty (currentJob)) {
        return false;
    }
    for (int i = 0; i < jobsICanDo.Length; i ++) {
        if (jobsICanDo [i] == job) {
            currentJob = job;
            this.shiftsToWork = numberOfShifts;
            shiftsWorked = 0;
            return true;
        }
    }
    return false;
}

public bool DoThisJob (string job, int numberOfShifts) {
    if (! String.IsNullOrEmpty (currentJob)) {
        return false;
    } else {
        for (int i = 0; i < jobsICanDo.Length; i ++)
            if (jobsICanDo [i] == job) {
                currentJob = job;
                this.shiftsToWork = numberOfShifts;
                shiftsWorked = 0;
                return true;
            }
        return false;
    }
}

