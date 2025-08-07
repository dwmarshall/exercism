using System.Text.RegularExpressions;
public class LogParser
{
    string eolPattern = @"end-of-line\d+";
    string passwordPattern = @""".*?password.*?""";
    string splitPattern = @"<[=\^\*-]+>";
    string typePattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
    public bool IsValidLine(string text) => Regex.IsMatch(text, typePattern);

    public string[] SplitLogLine(string text) => Regex.Split(text, splitPattern);

    public int CountQuotedPasswords(string lines) => Regex.Count(lines, passwordPattern, RegexOptions.IgnoreCase);

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, eolPattern, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string weakPattern = @"(password\S+)";
        Regex r = new Regex(weakPattern, RegexOptions.IgnoreCase);

        string[] result = new string[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            Match m = r.Match(lines[i]);
            if (m.Success)
            {
                result[i] = m.Groups[1].Value + ": " + lines[i];
            }
            else
            {
                result[i] = "--------: " + lines[i];
            }
        }
        return result;
    }
}
