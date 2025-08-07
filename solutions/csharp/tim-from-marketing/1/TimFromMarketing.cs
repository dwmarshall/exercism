static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string badge = "";
        if (id != null) {
            badge = $"[{id}] - ";
        }

        badge += name;

        if (department == null) {
            badge += " - OWNER";
        } else {
            badge += " - " + department.ToUpper();
        }

        return badge;
    }
}
