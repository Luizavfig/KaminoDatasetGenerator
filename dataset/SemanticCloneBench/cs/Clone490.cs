/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12077361
*  Stack Overflow answer #:52181414
*  And Stack Overflow answer#:52181414
*/
[HttpGet] [Route ("api/{Controller}/{id}")] public IHttpActionResult Put (int id, TEntity entity) {
    try {
        if (! ModelState.IsValid) {
            return BadRequest (ModelState);
        }
        var existing = db.Set < TEntity > ().Find (id);
        if (entity == null) {
            return NotFound ();
        }
        ReflectionHelper.Copy (entity, existing);
        db.SaveChanges ();
        return Ok (entity);
    }
    catch (Exception ex) {
        return InternalServerError (ex);
    }
}

[HttpDelete] [Route ("api/{Controller}/{id}")] public IHttpActionResult Delete (int id) {
    try {
        var entity = db.Set < TEntity > ().Find (id);
        if (entity == null) {
            return NotFound ();
        }
        db.Set < TEntity > ().Remove (entity);
        db.SaveChanges ();
        return Ok ();
    }
    catch (Exception ex) {
        return InternalServerError (ex);
    }
}

