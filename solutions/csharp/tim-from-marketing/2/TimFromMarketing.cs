static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var pieces = new List<string>();
        if (id != null) {
            pieces.Add($"[{id}]");
        }

        pieces.Add(name);

        if (department == null) {
            pieces.Add("OWNER");
        } else {
            pieces.Add(department.ToUpper());
        }

        return string.Join(" - ", pieces);
    }
}
