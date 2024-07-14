public class ChecklistGoal: Goal{

    private int _amountCompleted;
    private int _target {get; set;}
    private int _bonus{get;set;}

    public ChecklistGoal(){
        _amountCompleted=0;
        _target=0;
        _bonus=0;
    }


    public int GetTarget(){
        return _target;
    }
    public int GetBonus(){
        return _bonus;
    }
    public ChecklistGoal(string shortName, string description, int points, int target, int bonus):base(shortName, description, points){
        _amountCompleted=0;
        _target=target;
        _bonus=bonus;
    }
     public override void RecordEvent() {
        _amountCompleted++;
    }
    public override bool IsComplete(){
       return _amountCompleted >= _target;
    }
    public override string GetStringRepresentation(){
        return $"{this}:{base.GetShortName()},{base.GetDescription()},{base.GetPoints()},{_target},{_bonus}";
    }

    public override string GetDetailsString() {
        string details = base.GetDetailsString();
  
        details += $" (--Currently Completed {_amountCompleted}/{_target} times)";
        return details;
    }
}