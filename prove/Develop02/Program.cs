using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        
        Journal journal= new Journal();
        int response=1;

       
        //Initializing the prompts list
        PromptGenerator prompt= new PromptGenerator();
        string[] prompts=["What is the most important thing I plan to do today?",
                         "Which daily task don't I get done?",
                         "How can I bring any contribution to my community today?",
                         "Which emotion should I promote today?",
                         "If the lord asked me one thing he could do today in my life, what would it be?",
                         "How many scripture do I ponder today?"];
        foreach (string item in prompts)
        {
            prompt._prompts.Add(item);
        }
        
        string[] options=["1.Write","2.Display","3.Load","4.Save","5.Quit"];
        //int len= int.Parse(options.Count);
       
        do{
          
            foreach (string item in options)
            {
                Console.WriteLine(item);   
            }
            response= int.Parse(Console.ReadLine());
            if (response == 1){
                string promptRandomText=prompt.GetRandomPrompt();
                Console.WriteLine($"{promptRandomText}");
                string answer= Console.ReadLine();
                Entry newEntry=new Entry();
                newEntry._date=dateText;
                newEntry._promptText=promptRandomText;
                newEntry._entryText=answer;
                journal.AddEntry(newEntry);
            }else if(response==2){
                journal.DisplayAll();
            }else if(response==3){
                Console.WriteLine("What is the filename ");
                string filename=Console.ReadLine();
                journal.LoadFromFile(filename);
            }else if(response==4){
                 Console.WriteLine("What is the filename ");
                string filename=Console.ReadLine();
                journal.SaveToFile(filename);
            }
        }while(response < options.Length);
    }
}