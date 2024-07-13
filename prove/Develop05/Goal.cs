public abstract class Goal{
    
    private string _shortName{get;set;}
    private string _description {get;set;}
    private int _points {get;set;}
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public Goal(){
        _shortName="";
        _description="";
        _points=0;
    }
    public Goal(string shortName, string description, int points){
        _shortName=shortName;
        _description=description;
        _points=points;
    }
    
   
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString() {
        string details = $"{_shortName} - {_description}";
        return details;
    }

}