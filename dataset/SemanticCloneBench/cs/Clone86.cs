/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2277653
*  Stack Overflow answer #:2277694
*  And Stack Overflow answer#:2277765
*/
int parseCard (char card) {
    if (card >= '2' && card <= '9')
        return card - '0';
    if (card == 'T' || card == 'J' || card == 'Q' || card == 'K')
        return 10;
    if (card == 'A')
        return 11;
    throw new ArgumentException ("card not valid", "card");
}

int parseCard (char card) {
    if (card >= '2' && card <= '9') {
        return card - '0';
    }
    switch (card) {
        case 'T' : case 'J' : case 'Q' : case 'K' :
            return 10;
        case 'A' :
            return 11;
        default :
            throw new ArgumentException ("card not valid", "card");
    }
}

