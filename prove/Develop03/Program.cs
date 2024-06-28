using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        bool quit = true;

        string text="In the beginning, God created the heaven and earth.";
        Reference reference= new Reference("Genesis",1,1,2);
        Scripture scripture= new Scripture(reference,text);
        List<bool>_hidden = new List<bool>(Enumerable.Repeat(false, scripture.Length()));
      
        while (quit)
        {
            Console.WriteLine("Press Enter to continue or Write 'quit' to stop the program.");
            string input = Console.ReadLine();

          

            if (input.ToLower() == "quit")
            {
                quit = false;
            }
            else
            {
                Console.Clear();
                //Console.WriteLine(scripture.GetDisplayText());
                 Random rand = new Random();
                 
                scripture.HideRandomWord(scripture.Length(),_hidden);
                Console.WriteLine(scripture.GetDisplayText());
            }
        }
        
    }
       
    
    static bool SaveScriptureFromFile(){
            List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Genesis", 1, 1), "In the beginning God created the heaven and the earth."),
            new Scripture(new Reference("Genesis", 1, 26,27), "And God said, Let us make man in our image, after our likeness: and let them have dominion over the fish of the sea, and over the fowl of the air, and over the cattle, and over all the earth, and over every creeping thing that creepeth upon the earth. So God created man in his own image, in the image of God created he him; male and female created he them."),
            new Scripture(new Reference("Exodus", 20, 1), "And God spake all these words, saying, I am the Lord thy God, which have brought thee out of the land of Egypt, out of the house of bondage. Thou shalt have no other gods before me. Thou shalt not make unto thee any graven image, or any likeness of any thing that is in heaven above, or that is in the earth beneath, or that is in the water under the earth: Thou shalt not bow down thyself to them, nor serve them: for I the Lord thy God am a jealous God, visiting the iniquity of the fathers upon the children unto the third and fourth generation of them that hate me; And shewing mercy unto thousands of them that love me, and keep my commandments. Thou shalt not take the name of the Lord thy God in vain; for the Lord will not hold him guiltless that taketh his name in vain. Remember the sabbath day, to keep it holy. Six days shalt thou labour, and do all thy work: But the seventh day is the sabbath of the Lord thy God: in it thou shalt not do any work, thou, nor thy son, nor thy daughter, thy manservant, nor thy maidservant, nor thy cattle, nor thy stranger that is...")
        };
       

        // Écrire les données dans un fichier JSON
        
        string jsonString = JsonSerializer.Serialize(scriptures);
        File.WriteAllText("scriptures.json", jsonString);

        Console.WriteLine("Fichier JSON généré avec succès !");
        return true;
    }

     static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
             
            using (StreamReader r = new StreamReader(filePath))  
            {  
                string json = r.ReadToEnd();  
                scriptures = JsonSerializer.Deserialize<List<Scripture>>(json);  
            }  
         
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error while reading file : {ex.Message}");
        }

        return scriptures;
    }



    private string GetRandomScripture(List<string> scriptures)
    {
        if (scriptures.Count == 0)
            return string.Empty;

        Random rand = new Random();
        int index = rand.Next(0, scriptures.Count);
        return scriptures[index];
    }
}