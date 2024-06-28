public class Scripture{
    private Reference _reference {get;set;}
    private List<Word> _words=new List<Word>();
   
   public Scripture(){
    
   }

    
    private  List<string> texts;
    
    public Scripture(Reference reference, string text){
        _reference=reference;
        texts=text.Split(" ").ToList();
       
        foreach(string val in texts){
             
             Word word1= new Word(val);
            _words.Add(word1);
        }
       
    }
    

    public  int Length(){
        return _words.Count;
    }
   
    public void HideRandomWord(int numberToHide,List<bool> _hidden){
        int len= _words.Count;
        Random rand = new Random();
      
         List<int> unhiddenIndices = Enumerable.Range(0, len)
                                           .Where(i => !_hidden[i])
                                           .ToList();
      
          if (unhiddenIndices.Count < numberToHide)
          {
              numberToHide = unhiddenIndices.Count;
          }
        Console.WriteLine($"Number to hide {numberToHide}");
       
       int index1=rand.Next(1,numberToHide);
       Console.WriteLine($"first Index {index1}");
        for (int i =0; i<index1; i++){  
                
            int index = rand.Next(unhiddenIndices.Count);
            Console.WriteLine($"The index is {index}");
            _words[index].Hide();
            _hidden[index]=true;    
            
        // Mettre à jour la liste en partant de la fin pour ne pas invalider les indices
            //Console.WriteLine($"{_words[index].GetText()} --{_words[index].GetDisplayText()}");
            
            // foreach (string item in texts)
            // {
            //     if (item.ToLower()==_words[index].GetText().ToLower()){
            //        texts[index]=_words[index].GetDisplayText();
            //         _hidden[index]=true;
                   
                   
            //     }
            // }
          
          
            texts[index]=_words[index].GetDisplayText();
            unhiddenIndices.RemoveAt(index);
            // Console.WriteLine($"The remains number {unhiddenIndices.Count}");
          
            if(IsCompletelyHidden(_hidden)){
                Console.WriteLine("All words are hidden. End program.");
                Environment.Exit(0);
            }
            
        }
        Console.WriteLine($"The remains number {unhiddenIndices.Count}");
       

    }

    public string GetDisplayText(){
        
        // The Join methods convert a collection into a string

        string text = string.Join(" ",texts);
        
        return $"{_reference.GetDisplayText()} {text}";
    }
    public bool IsCompletelyHidden(List<bool> _hidden){     
        return _hidden.All(h => h);
       
    }
   
}