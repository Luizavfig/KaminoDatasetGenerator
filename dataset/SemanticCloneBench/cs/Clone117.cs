/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5184253
*  Stack Overflow answer #:5184838
*  And Stack Overflow answer#:5184838
*/
protected override Expression Visit (Expression exp) {
    if (exp == null) {
        return null;
    }
    if (this.candidates.Contains (exp)) {
        return this.Evaluate (exp);
    }
    return base.Visit (exp);
}

protected override Expression Visit (Expression expression) {
    if (expression != null) {
        bool saveCannotBeEvaluated = this.cannotBeEvaluated;
        this.cannotBeEvaluated = false;
        base.Visit (expression);
        if (! this.cannotBeEvaluated) {
            if (this.fnCanBeEvaluated (expression)) {
                this.candidates.Add (expression);
            } else {
                this.cannotBeEvaluated = true;
            }
        }
        this.cannotBeEvaluated |= saveCannotBeEvaluated;
    }
    return expression;
}

