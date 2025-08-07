using System.Text;
public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < identifier.Length; i++) {
            char c = identifier[i];
            if (c == ' ') {
                sb.Append('_');
            } else if (char.IsControl(c)) {
                sb.Append("CTRL");
            } else if (c == '-') {
                sb.Append(char.ToUpper(identifier[++i]));
            } else if (char.IsLetter(c) && ! char.IsBetween(c, 'α', 'ω')) {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
