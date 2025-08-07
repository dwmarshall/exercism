using System.Runtime.InteropServices;
public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}


public static class Appointment
{

    public static bool windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    public static Dictionary<Location, string> zones = new Dictionary<Location, string>{
        {Location.NewYork, windows ? "Eastern Standard Time" : "America/New_York"},
        {Location.London, windows ? "GMT Standard Time" : "Europe/London"},
        {Location.Paris, windows ? "W. Europe Standard Time" : "Europe/Paris"}
    };

    public static Dictionary<AlertLevel, TimeSpan> alerts = new Dictionary<AlertLevel, TimeSpan>{
        {AlertLevel.Early, new TimeSpan(1, 0, 0, 0)},
        {AlertLevel.Standard, new TimeSpan(1, 45, 0)},
        {AlertLevel.Late, new TimeSpan(0, 30, 0)},
    };

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime dt;
        DateTime.TryParse(appointmentDateDescription, out dt);

        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(zones[location]);
        return TimeZoneInfo.ConvertTimeToUtc(dt, tz);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => appointment.Subtract(alerts[alertLevel]);


    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeSpan oneWeek = TimeSpan.FromDays(7);
        bool isDst = dt.IsDaylightSavingTime();
        bool wasDst = dt.Subtract(oneWeek).IsDaylightSavingTime();
        return isDst ^ wasDst;

    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        throw new NotImplementedException("Please implement the (static) Appointment.NormalizeDateTime() method");
    }
}
