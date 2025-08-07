public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string other)
    {
        int location = str.IndexOf(other);
        return str.Substring(location + other.Length);
    }

    public static string SubstringBetween(this string str, string A, string B)
    {
        int locationA = str.IndexOf(A) + A.Length;
        int locationB = str.IndexOf(B);
        int subLength = locationB - locationA;
        return str.Substring(locationA, subLength);
    }

    public static string Message(this string str) => str.SubstringAfter(": ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}
