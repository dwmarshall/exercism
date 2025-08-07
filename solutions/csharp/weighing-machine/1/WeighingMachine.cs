class WeighingMachine
{

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
    public int Precision { get; }

    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _weight = value;
        }
    }

    public string DisplayWeight
    {
        get
        {
            double display = Weight - TareAdjustment;
            string format = $"F{Precision}";
            string formattedDisplay = display.ToString(format);
            return $"{formattedDisplay} kg";
        }
    }
    public double TareAdjustment { get; set; } = 5.0;
}
