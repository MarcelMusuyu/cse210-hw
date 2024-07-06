public class ListingActivity: Activity{
    private int _count;
    private List<string> _prompts= new List<string>() ;
    private List<string> responses =new List<string>();

    public ListingActivity(string name, string description,int duration,int count,List<string> prompts):base(name,description,duration){
        _count=count;
        _prompts=prompts;
    }

    public ListingActivity(string name, string description):base(name,description){
        _count=GetListFromUser().Count;
        string[] newArray= {
            
            " Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            " Who are some of your personal heroes?"
        };
        _prompts=new List<string>(newArray) ;
    }

    public ListingActivity(){
        SetName("Listing");
        SetDescription("This activity will help you reflect on the good things in your life \n by having you list as many things as you can in a certain area.");
        string[] newArray= {
            
            " Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            " Who are some of your personal heroes?"
        };
        _prompts=new List<string>(newArray) ;
    
    }
    public void Run(){
         
         FillList();
         Console.WriteLine(GetDuration());   
         //Console.WriteLine($"The number of items is {GetListFromUser().Count}");
    }

    public void GetRandomPrompt(){
       Random rand = new Random();

       int index= rand.Next(0,_prompts.Count);
      
       Console.ForegroundColor= ConsoleColor.DarkRed;
       Console.WriteLine($"------------{ _prompts[index]}------------");
       Console.ResetColor();
    }

    private void FillList(){
        DisplayStartingMessage();
        Console.Write("\nHow long this activity will take you? ");
        int duration=int.Parse(Console.ReadLine());
        SetDuration(duration);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        Console.WriteLine("Get ready... \n");
        Thread.Sleep(200);
        ShowSpinner(duration);
        Console.WriteLine("Listed as many responses to the following prompt");
        GetRandomPrompt();
        Console.WriteLine("You may begin in: ");
        while(DateTime.Now < futureTime){
            Console.Write("> ");
            string response= Console.ReadLine();
            responses.Add(response);
        }
        Console.WriteLine("---------------------------\n");
        Console.WriteLine($"You listed {GetListFromUser().Count} items");
        Console.WriteLine("---------------------------\n\n");
        Console.WriteLine("Well done !!! \n");
        ShowSpinner(duration);
        Thread.Sleep(200);

        Console.WriteLine($"You have completed another {duration} of Listing Activity");

    }

    public List<string> GetListFromUser(){
        return responses;
    }

    
}