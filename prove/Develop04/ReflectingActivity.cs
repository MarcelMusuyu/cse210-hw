public class ReflectingActivity: Activity{
    private List<string> _prompts =new List<string>();
    private List<string> _questions =new List<string>();

    public ReflectingActivity(string name, string description,int duration,List<string> prompts,List<string> questions):base(name,description,duration){
        _prompts=prompts;
        _questions=questions;
    }

    public ReflectingActivity(){
        SetName("Reflecting");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. \n This will help you recognize the power you have and how you can use it in other aspects of your life.");
        string[] newArray={
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _prompts=new List<string>(newArray);
        string[] questionsArray= {
            
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
            
                 
       };
        _questions=new List<string>(questionsArray);
    
    }

      public ReflectingActivity(string name, string description):base(name,description){
        string[] newArray={
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _prompts=new List<string>(newArray);
        string[] questionsArray= {
            
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
            
                 
       };
        _questions=new List<string>(questionsArray);
    }


    public void Run(){
        DisplayStartingMessage();
        
        DisplayQuestions();
       
    }

    public string GetRandomPrompt(){
       Random rand = new Random();
       int index= rand.Next(0,_prompts.Count);
       return _prompts[index];
    }

    public string GetRandomQuestion(){
       Random rand = new Random();
       int index= rand.Next(0,_questions.Count);
       return _questions[index];
    }

    public void DisplayPrompt(){
        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.WriteLine($"------------{GetRandomPrompt()}------------");
        Console.ResetColor();
        Console.WriteLine("When you have something in mind: Press Enter to continue");
    }

    public void DisplayQuestions(){
        Console.Write("\nHow long this activity will take you? ");
        int duration=int.Parse(Console.ReadLine());
        SetDuration(duration);
         DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        Console.WriteLine("Get ready... \n");
        Thread.Sleep(200);
        ShowSpinner(duration);
        Console.WriteLine("Consider the following prompt: ");
        DisplayPrompt();
        Random rand= new Random();
        int second= rand.Next(2,10);
        Console.WriteLine("Now ponder on each of the following questions as they related with this experience")
        Console.Write("You may begin in: ");
        ShowCountDown(second);
        while(DateTime.Now < futureTime){
           int index=rand(_questions.Count);
           Console.Write(_questions[index]);
           ShowSpinner(duration);
           Thread.Sleep(200);
        }

        Console.WriteLine("---------------------------\n\n");
        Console.WriteLine("Well done !!! \n");
        ShowSpinner(duration);
        Thread.Sleep(200);
        Console.WriteLine($"You have completed another {duration} of Listing Activity");
        ShowSpinner(duration);
        Thread.Sleep(200);
        
    }
}