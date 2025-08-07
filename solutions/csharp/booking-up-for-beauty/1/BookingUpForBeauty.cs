static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime dt;
        DateTime.TryParse(appointmentDateDescription, out dt);
        return dt;
    }

    public static bool HasPassed(DateTime appointmentDate) => appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) => appointmentDate.Hour is >= 12 and < 18;

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate.ToString("G")}.";
    }

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15);
}
