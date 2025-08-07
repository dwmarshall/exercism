public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        int originalLength = this.sponsors.Length;
        Array.Resize(ref this.sponsors, this.sponsors.Length + sponsors.Length);
        sponsors.CopyTo(this.sponsors, originalLength);
    }

    public string DisplaySponsor(int sponsorNum) => this.sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum <= this.latestSerialNum)
        {
            serialNum = latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
        else
        {
            latestSerialNum = serialNum;
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            return true;
        }
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int battery;
        int meters;
        if (this.car.GetTelemetryData(ref serialNum, out battery, out meters) && meters != 0)
        {
            int ratio = (100 - battery) / meters;
            return $"usage-per-meter={ratio}";
        }
        else
        {
            return "no data";
        }
    }
}
