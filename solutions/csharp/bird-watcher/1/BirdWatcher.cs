class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => ++birdsPerDay[^1];

    public bool HasDayWithoutBirds() => birdsPerDay.Any(n => n == 0);

    public int CountForFirstDays(int numberOfDays) => birdsPerDay[0..numberOfDays].Sum();

    public int BusyDays() => birdsPerDay.Count(n => n >= 5);
}
