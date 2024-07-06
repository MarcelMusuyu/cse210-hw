public class Activity{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description,int duration){
        _name=name;
        _description=description;
        _duration=duration;
    }

    public Activity(){

    }

    public int GetDuration(){
        return _duration;
    }
    public Activity(string name, string description){
        _name=name;
        _description=description;
        _duration=50;
    }

    public void SetDuration(int duration){
        _duration=duration;
    }


    public void DisplayStartingMessage(){
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{_description}");
        Console.ResetColor();
    }

    public void SetName(string name){
        _name=name;
    }

    public void SetDescription(string description){
        _description=description;
    }
    public void DisplayEndingMessage(){

    }

    public void ShowSpinner(int seconds){
        Console.Write("Please wait while ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{seconds} seconds");
        Console.ResetColor();
        Console.Write(" : ");

        for (int i = 0; i < seconds; i++)
        {
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(500);
           
            Console.Write("\b \b"); // Erase the + character
            Console.Write("."); 
            
        }
        Console.ResetColor();

        Console.WriteLine();
    }


    

    public void ShowCountDown(int seconds){
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{seconds} seconds");
        Console.ResetColor();
        Console.Write(" : ");

        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);     
            Console.Write("\b ");
        }

        Console.WriteLine();
    
    }
}