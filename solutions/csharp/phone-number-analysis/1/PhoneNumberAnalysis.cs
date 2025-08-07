public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var phoneNumberParts = phoneNumber.Split("-");
        return (phoneNumberParts[0] == "212", phoneNumberParts[1] == "555", phoneNumberParts[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.Item2;
    }
}
