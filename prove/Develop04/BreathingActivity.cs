public class BreathingActivity : Activity{

    public BreathingActivity(string name, string description,int duration):base(name,description,duration){

    }

     public BreathingActivity(string name, string description):base(name,description){
        
    }

    public BreathingActivity(){
        SetName("Breathing");
        SetDescription("This activity will help you relax by walking your through breathing in and out slowly. \nClear your mind and focus on your breathing.");
    }


    public void Run(){
        DisplayStartingMessage();
        Console.Write("\nHow long this activity will take you? ");
        int duration=int.Parse(Console.ReadLine());
        SetDuration(duration);
       
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        Console.WriteLine("Get ready... \n");
        Thread.Sleep(200);
        ShowSpinner(duration);
       
        while(DateTime.Now < futureTime){
           Console.Write("Breathe In... ");
           Random rand= new Random();
           int second= rand.Next(2,10);
           ShowCountDown(second);
          
           Console.WriteLine();
           Console.Write("Now Breathe Out... ");
           
           second= rand.Next(2,10);
           ShowCountDown(second);
          
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