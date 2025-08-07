static class LogLine
{
    public static string Message(string logLine)
    {
        int colonPos = logLine.IndexOf(":");
        return logLine.Remove(0, colonPos + 2).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int bracketPos = logLine.IndexOf("]");
        string level = logLine.Substring(1, bracketPos - 1);
        return level.ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string level = LogLevel(logLine);
        return $"{message} ({level})";
    }
}
