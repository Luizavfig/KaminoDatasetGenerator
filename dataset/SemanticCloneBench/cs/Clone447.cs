/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30272108
*  Stack Overflow answer #:30276017
*  And Stack Overflow answer#:30272135
*/
function Confirm () {
    var Result = confirm ("Do you want to remove this employee from this group?");
    var confirm_value = document.querySelector ('[name="confirm_value"]');
    if (Result) {
        return true;
    } else {
        return false;
    }
}

function Confirm () {
    var confirm_value = document.querySelector ('[name="confirm_value"]');
    if (! confirm_value) {
        confirm_value = document.createElement ("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        document.forms [0].appendChild (confirm_value);
    }
    if (confirm ("Do you want to remove this employee from this group?")) {
        confirm_value.value = "1";
    } else {
        confirm_value.value = "2";
    }
}

