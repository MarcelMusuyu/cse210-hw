public class SimpleGoal: Goal{
    
    private bool _isComplete;
    public SimpleGoal(){
        
    }
    public SimpleGoal(string shortName, string description, int points):base(shortName, description, points){
        _isComplete=false;
        
    }
    public override void RecordEvent() {
        _isComplete=true;
    }
    public override bool IsComplete(){
        return _isComplete;
    }
    public bool GetIsComplete(){
        return _isComplete;
    }
    public override string GetStringRepresentation(){
        return  $"{this}:{base.GetShortName()},{base.GetDescription()},{base.GetPoints()},{_isComplete}";
    }

}