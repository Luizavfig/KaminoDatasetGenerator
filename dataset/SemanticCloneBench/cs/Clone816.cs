/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:21022467
*  Stack Overflow answer #:21088489
*  And Stack Overflow answer#:21088489
*/
public static ILog GetLogger (string arg, string name) {
    var repositoryName = arg;
    ILoggerRepository repository = null;
    var repositories = LogManager.GetAllRepositories ();
    foreach (var loggerRepository in repositories) {
        if (loggerRepository.Name.Equals (repositoryName)) {
            repository = loggerRepository;
            break;
        }
    }
    Hierarchy hierarchy = null;
    if (repository == null) {
        repository = LogManager.CreateRepository (repositoryName);
        hierarchy = (Hierarchy) repository;
        hierarchy.Root.Additivity = false;
        var rollingAppender = GetRollingAppender (repositoryName);
        hierarchy.Root.AddAppender (rollingAppender);
        var memoryAppender = GetMemoryAppender (repositoryName);
        hierarchy.Root.AddAppender (memoryAppender);
        BasicConfigurator.Configure (repository);
    }
    return LogManager.GetLogger (repositoryName, name);
}

private static IAppender GetRollingAppender (string arg) {
    var level = Level.All;
    var rollingFileAppenderLayout = new PatternLayout ("%date{HH:mm:ss,fff}|T%2thread|%25.25logger|%5.5level| %message%newline");
    rollingFileAppenderLayout.ActivateOptions ();
    var rollingFileAppenderName = string.Format ("{0}{1}", RollingFileAppenderNameDefault, arg);
    var rollingFileAppender = new RollingFileAppender ();
    rollingFileAppender.Name = rollingFileAppenderName;
    rollingFileAppender.Threshold = level;
    rollingFileAppender.CountDirection = 0;
    rollingFileAppender.AppendToFile = true;
    rollingFileAppender.LockingModel = new FileAppender.MinimalLock ();
    rollingFileAppender.StaticLogFileName = true;
    rollingFileAppender.RollingStyle = RollingFileAppender.RollingMode.Date;
    rollingFileAppender.DatePattern = ".yyyy-MM-dd'.log'";
    rollingFileAppender.Layout = rollingFileAppenderLayout;
    rollingFileAppender.File = string.Format ("{0}.{1}", "log", arg);
    rollingFileAppender.ActivateOptions ();
    return rollingFileAppender;
}

