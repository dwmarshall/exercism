// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar? other)
    {
        if (other == null) return 1;
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        if (prc2 != null && prc1.CompareTo(prc2) < 0)
        {
            return [prc1, prc2];
        }
        else
        {
            return [prc2, prc1];
        }
    }
}
