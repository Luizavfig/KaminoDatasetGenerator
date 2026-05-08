/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35630892
*  Stack Overflow answer #:35631802
*  And Stack Overflow answer#:35631041
*/
void CannonKiller () {
    Collider [] hitColliders = Physics.OverlapSphere (transform.position, 4);
    foreach (Collider hitCollider in hitColliders) {
        if (hitCollider.gameObject.tag == "EnemyCannon") {
            Destroy (hitCollider.gameObject);
            if (enemyCans.FirstOrDefault (cannon = > cannon != null) == null) {
            }
        }
    }
}

void CannonKiller () {
    foreach (var cannon in GameObject.FindGameObjectsWithTag ("EnemyCannon").Select (enemyCans = > enemyCans.transform).ToArray ()) {
        foreach (var aCan in enemyCans) {
            float enemyDis = Vector3.Distance (cannon.position, transform.position);
            if (enemyDis <= 4) {
                Destroy (aCan);
                bool allDestoyed = true;
                foreach (GameObject o in enemyCans) {
                    if (o != null && o != aCan) {
                        allDestoyed = false;
                        break;
                    }
                }
                if (allDestoyed) {
                }
            }
        }
    }
}

