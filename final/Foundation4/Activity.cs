public abstract class  Activity{
    private string _date;
    private int _length;
    public Activity(string date, int length){
        _date=date;
        _length=length;
    }

     public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_length} min) - Distance {GetDistance():F1} km, Speed {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
    public int GetLength()
    {
        return _length;
    }

    public string GetDate()
    {
        return _date;
    }
}



