using System;
using System.Collections.Generic;

/*
    I exceed the requirements by adding two additional methods, 
    Save as Json that allows to record entries in the JSON Format
    and Load from Json that allows to display data from the JSON File

    Think of other problems that keep people from writing in their journal and address one of those.
    for these I added two additional properties which are mood and motivation level

    Improve the process of saving and loading to save as a .csv file that could be opened 
    in Excel (make sure to account for quotation marks and commas correctly in your content.
    I managed this by using the Replace method and Escape characters \" to allow Double quote before saving content
*/
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
        
        string[] options=["1.Write","2.Display","3.Load","4.Save","5.Save As JSON","6.load from JSON","7.Quit"];
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

                //To improve the way of saving text in CSV file, we will replace all commas present in the 
                // Provided text by a semicolon
                answer= answer.Replace(",",";");
                Console.WriteLine("What is your current mood ?");
                string mood= Console.ReadLine();
                Console.Write("What is your motivation level? ...");
                int motivation= int.Parse(Console.ReadLine());
                Entry newEntry=new Entry();
                newEntry._date=dateText;
                newEntry._promptText=promptRandomText;
                newEntry._entryText=answer;
                newEntry._mood=mood;
                newEntry._motivationLevel=motivation;
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
            }else if(response==5){
                 Console.WriteLine("What is the filename ");
                string filename=Console.ReadLine();
                journal.SaveAsJSON(filename);
            }else if(response==6){
                 Console.WriteLine("What is the filename ");
                string filename=Console.ReadLine();
                journal.LoadFromJSON(filename);
            }
        }while(response < options.Length);
    }
}