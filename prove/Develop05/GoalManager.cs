using System.Text.Json;
using System.IO;  // include the System.IO 
public class GoalManager{

    
    private int _points;

    private List<Goal> _goalList;
    Goal goal;
    Goal _newGoal;

    public GoalManager(){
        _points=0;
        _goalList= new List<Goal>();
    }

   

    private void DisplayPlayerInfo(){
         Console.ForegroundColor= ConsoleColor.Green;
         Console.WriteLine($"----------You have {_points} points--------------\n");
         Console.ResetColor();
    }

   
    //This function will display a list of goals name present in our file
    private  void ListGoalNames(){
        string filename = "goals.txt";
        using (StreamReader reader = new StreamReader(filename))
        {
            // Skip the first line (header)
            reader.ReadLine();

            string line;
            int indice=1;
            while((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(":");

                string goal = parts[0];
               
                Console.WriteLine($"{indice}. {goal}");
                indice++;
            }
    }
    }

    private void RecordEvent(){
        //This function will display a list of goals name present in our file
       
         Console.WriteLine("The types of Goals are:");
         ListGoalNames();
         Console.Write("Which type of goal did you accomplish ?");
         int choice=int.Parse(Console.ReadLine());
         //int filePoints=0;
         //Console.WriteLine($"Congratulations! you have earned {filePoints}");
         int count=2;
         string newLine="SimpleGoal:Exercise,Go for a run,10,False";
         using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                   if(choice+1 == count){
                        newLine=line;
                        break;
                   } 
                   count++;
                   
                }
               
            }
            Goal loadedGoal = CreateNewGoal(newLine);
            Console.WriteLine($"Congratulations! you have earned {loadedGoal.GetPoints()}");

    }


        public  Goal CreateNewGoal(string goalString)
    {
        string[] parts = goalString.Split(':');
        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid goal string format.");
        }
        

        string className=parts[0];

        string[] details = parts[1].Split(',');
        string shortName = details[0];
        string description = details[1];
        int points = int.Parse(details[2]);
        if (className=="SimpleGoal"){
             bool isComplete = bool.Parse(details[3]);
            _newGoal = new SimpleGoal(shortName, description, points);
           
            _newGoal.RecordEvent();
        }else if(className == "EternalGoal"){
            _newGoal= new EternalGoal(shortName,description,points);
            _newGoal.RecordEvent();
        }else if (className=="ChecklistGoal"){
             int target = int.Parse(details[3]);
             int bonus=int.Parse(details[4]);
            _newGoal= new ChecklistGoal(shortName,description,points,target,bonus);
            _newGoal.RecordEvent();
        }
       
       

        return _newGoal;
    }

    private void SaveGoalsAsJson(){
        Console.WriteLine("Write the filename");
        string filename=Console.ReadLine();
        
           string json = JsonSerializer.Serialize((new { Goals = _goalList, Points = _points }));
            File.WriteAllText(filename, json);
        
    }

    private void SaveGoals(){
        Console.Write("Write the filename: ");
        string filename=Console.ReadLine();
        using(StreamWriter outputFile = new StreamWriter(filename)){
        outputFile.WriteLine($"{_points}");
         foreach(Goal goal in _goalList){
           
            var type = goal.GetType();
            if(type.ToString() =="SimpleGoal"){
                SimpleGoal goal1 = goal as SimpleGoal;
                  outputFile.WriteLine(goal1.GetStringRepresentation());
            }else if(type.ToString()=="ChecklistGoal"){
                ChecklistGoal goal2= goal as ChecklistGoal;
                 outputFile.WriteLine(goal2.GetStringRepresentation());
           
            }else if(type.ToString()=="EternalGoal"){
                EternalGoal goal3= goal as EternalGoal;
                 outputFile.WriteLine(goal3.GetStringRepresentation());
           
            }else{
                 outputFile.WriteLine("Not an object in a specific list");
            }

            
        }
        }
       
        
    }

    private void LoadGoals(){
        Console.WriteLine("Write the filename");
        string filename=Console.ReadLine();
        string json = File.ReadAllText(filename);

        // Deserialize the JSON into an anonymous object
        var data = JsonSerializer.Deserialize<dynamic>(json);

        // Load the goals and points from the deserialized data
        _goalList = JsonSerializer.Deserialize<List<Goal>>(data.Goals.ToString());
        _points = (int)data.Points;
       
    }

    private  void ListGoalDetails(){
        foreach (Goal goal in _goalList)
        {
            string checkbox = goal.IsComplete() ? "[X]" : "[ ]";
            string details = $"{checkbox} {goal.GetDetailsString()}";
            Console.WriteLine(details);
        }
    }

    /*
        This method takes one parameter which represents the goal type 
        that the user has choosen to create
    */
    private  void CreateGoal(int goalType){
        string name;
        string description;
        int points;
        int times;
        int bonus;
       
        // The if statement ensures just the option prompted be whithin the range of existing ones
        if (goalType <=3){
            Console.Write("What is the name of your goal?:");
            name=Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is a short description of it?:");
            description=Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is the amount of points associated with this goal? ");
            points=int.Parse(Console.ReadLine());
            Console.WriteLine();
                        
            if(goalType==1){
                goal =new SimpleGoal(name,description,points);
            }else if(goalType==2){
                goal= new EternalGoal(name,description,points);
            }else if(goalType == 3){
                Console.Write("How many times does this goal need to be accomplished for bonus? ");
                times=int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("What is the bonus for accomplishing it that many times ? ");
                bonus=int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name,description,points,times,bonus);

            }
            _goalList.Add(goal);
            Console.WriteLine($"Goal Created  {_goalList.Count}");
        }
        else{
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("----------Invalid Choice--------------");
                Console.ResetColor();
        }
    }


    public void Start(){
        int choice;
        int choice2;
       
        do{
            
             DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"\t1. Create New Goal");
            Console.WriteLine($"\t2. List Goals");
            Console.WriteLine($"\t3. Save Goals");
            Console.WriteLine($"\t4. Load Goals");
            Console.WriteLine($"\t5. Record Event");
            Console.WriteLine($"\t6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice=int.Parse(Console.ReadLine());
        
             switch (choice)
                {
                  
                    case 1:
                        
                        Console.WriteLine("The types of Goals are:");
                        Console.WriteLine($"\t1. Simple Goal");
                        Console.WriteLine($"\t2. Eternal Goal");
                        Console.WriteLine($"\t3. Checklist Goal");
                        Console.Write("Which type of goal would you like to create? ");
                        choice2=int.Parse(Console.ReadLine());
                        //The create goal Method
                        CreateGoal(choice2);
                       
                        
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor= ConsoleColor.White;
                        Console.WriteLine("----------List Goals--------------");
                        ListGoalDetails();
                        Console.ResetColor();
                       
                        break;
                    case 3:
                        
                        Console.ForegroundColor= ConsoleColor.DarkGreen;
                        Console.WriteLine("----------Save Goals--------------");
                        SaveGoals();
                        Console.ResetColor();
                        
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor= ConsoleColor.White;
                        Console.WriteLine("----------Load Goals--------------");
                        Console.ResetColor();
                        LoadGoals();
                        break;
                    case 5:
                       
                        Console.ForegroundColor= ConsoleColor.DarkBlue;
                        Console.WriteLine("----------Record Event--------------");
                        RecordEvent();
                        Console.ResetColor();
                        break;
                    
                }
        
        } while(choice < 6);
    }
}