/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16437083
*  Stack Overflow answer #:16438187
*  And Stack Overflow answer#:22098063
*/
public void UndoAll (DbContext context) {
    context.ChangeTracker.DetectChanges ();
    var entries = context.ChangeTracker.Entries ().Where (e = > e.State != EntityState.Unchanged).ToList ();
    foreach (var dbEntityEntry in entries) {
        var entity = dbEntityEntry.Entity;
        if (entity == null)
            continue;
        if (dbEntityEntry.State == EntityState.Added) {
            var set = context.Set (entity.GeType ());
            set.Remove (entity);
        } else if (dbEntityEntry.State == EntityState.Modified) {
            dbEntityEntry.Reload ();
        } else if (dbEntityEntry.State == EntityState.Deleted)
            dbEntityEntry.State = EntityState.Modified;
    }
}

public void RejectChanges () {
    foreach (var entry in ChangeTracker.Entries ()) {
        switch (entry.State) {
            case EntityState.Modified : case EntityState.Deleted :
                entry.State = EntityState.Modified;
                entry.State = EntityState.Unchanged;
                break;
            case EntityState.Added :
                entry.State = EntityState.Detached;
                break;
        }
    }
}

