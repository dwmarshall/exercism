class RemoteControlCar
{
    private int _speed;
    private int _battery;
    private int _drain;
    private int _distance;

    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int drain) {
        _speed = speed;
        _battery = 100;
        _drain = drain;
        _distance = 0;

    }
    public bool BatteryDrained() => _battery < _drain;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (_battery >= _drain) {
            _distance += _speed;
            _battery -= _drain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _length;
    public RaceTrack(int length) {
        _length = length;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < _length && !car.BatteryDrained()) {
            car.Drive();
        }
        return car.DistanceDriven() >= _length;
    }
}
