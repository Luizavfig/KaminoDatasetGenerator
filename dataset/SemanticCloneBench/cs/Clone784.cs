/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:249927
*  Stack Overflow answer #:28553422
*  And Stack Overflow answer#:249942
*/
public static void RecycleApplicationPool (string serverName, string appPoolName) {
    if (! string.IsNullOrEmpty (serverName) && ! string.IsNullOrEmpty (appPoolName)) {
        try {
            using (ServerManager manager = ServerManager.OpenRemote (serverName))
            {
                ApplicationPool appPool = manager.ApplicationPools.FirstOrDefault (ap = > ap.Name == appPoolName);
                if (appPool != null) {
                    bool appPoolRunning = appPool.State == ObjectState.Started || appPool.State == ObjectState.Starting;
                    bool appPoolStopped = appPool.State == ObjectState.Stopped || appPool.State == ObjectState.Stopping;
                    if (appPoolRunning) {
                        while (appPool.State == ObjectState.Starting) {
                            System.Threading.Thread.Sleep (1000);
                        }
                        if (appPool.State != ObjectState.Stopped) {
                            appPool.Stop ();
                        }
                        appPoolStopped = true;
                    }
                    if (appPoolStopped && appPoolRunning) {
                        while (appPool.State == ObjectState.Stopping) {
                            System.Threading.Thread.Sleep (1000);
                        }
                        appPool.Start ();
                    }
                } else {
                    throw new Exception (string.Format ("An Application Pool does not exist with the name {0}.{1}", serverName, appPoolName));
                }
            }}
        catch (Exception ex) {
            throw new Exception (string.Format ("Unable to restart the application pools for {0}.{1}", serverName, appPoolName), ex.InnerException);
        }
    }
}

[ModuleServiceMethod (PassThrough = true)] public ArrayList GetApplicationPoolCollection () {
    ArrayList arrayOfApplicationBags = new ArrayList ();
    ServerManager serverManager = new ServerManager ();
    ApplicationPoolCollection applicationPoolCollection = serverManager.ApplicationPools;
    foreach (ApplicationPool applicationPool in applicationPoolCollection) {
        PropertyBag applicationPoolBag = new PropertyBag ();
        applicationPoolBag [ServerManagerDemoGlobals.ApplicationPoolArray] = applicationPool;
        arrayOfApplicationBags.Add (applicationPoolBag);
        if (applicationPool.State == ObjectState.Stopped) {
            applicationPool.Start ();
        }
    }
    serverManager.CommitChanges ();
    return arrayOfApplicationBags;
}

