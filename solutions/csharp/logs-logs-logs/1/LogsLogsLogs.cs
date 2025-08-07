enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
}
static class LogLine
{
    static Dictionary<string, LogLevel> levels = new Dictionary<string, LogLevel>{
        {"TRC", LogLevel.Trace},
        {"DBG", LogLevel.Debug},
        {"INF", LogLevel.Info},
        {"WRN", LogLevel.Warning},
        {"ERR", LogLevel.Error},
        {"FTL", LogLevel.Fatal},
    };

    static Dictionary<LogLevel, int> codes = new Dictionary<LogLevel, int>{
        {LogLevel.Unknown, 0},
        {LogLevel.Trace, 1},
        {LogLevel.Debug, 2},
        {LogLevel.Info, 4},
        {LogLevel.Warning, 5},
        {LogLevel.Error, 6},
        {LogLevel.Fatal, 42}
    };

    public static LogLevel ParseLogLevel(string logLine)
    {
        string key = logLine[1..4];
        if (levels.ContainsKey(key))
        {
            return levels[key];
        }
        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{codes[logLevel]}:{message}";

}
