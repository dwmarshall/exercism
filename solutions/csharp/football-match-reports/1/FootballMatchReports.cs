public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case <= 4:
                return "center back";
            case 5:
                return "right back";
            case <= 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int:
                return $"There are {report} supporters at the match.";
            case string:
                return (string)report;
            case Foul f:
                return f.GetDescription();
            case Injury inj:
                string s = inj.GetDescription();
                return $"Oh no! {s} Medics are on the field.";
            case Incident inc:
                return inc.GetDescription();
            case Manager m:
                if (m.Club == null) {
                    return m.Name;
                } else {
                    return $"{m.Name} ({m.Club})";
                }
            default:
                return string.Empty;
        }
    }
}
