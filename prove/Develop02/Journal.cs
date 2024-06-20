using System;
using System.IO; 
using System.Text.Json;

/*
    I exceed the requirements by adding two additional methods, 
    Save as Json that allows to record entries in the JSON Format
    and Load from Json that allows to display data from the JSON File
*/
public class Journal {
    public List<Entry> _entries= new List<Entry>();

    //The constructor
    public Journal(){

    }
    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
    }
    public void DisplayAll(){
        foreach (Entry item in _entries)
        {
            item.Display();
        }
    }

    public void SaveToFile(string filename){
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach(Entry item in _entries){
                outputFile.WriteLine($"{item._date}|{item._promptText}|{item._entryText}");
            }
        }
    }

    public void LoadFromJSON(string filename){
            List<Entry> source = new List<Entry>();  
  
            using (StreamReader r = new StreamReader(filename))  
            {  
                string json = r.ReadToEnd();  
                source = JsonSerializer.Deserialize<List<Entry>>(json);  
            }  
           foreach (Entry entry in source)
            {
                Console.WriteLine($"_date: {entry._date}");
                Console.WriteLine($"_promptText: {entry._promptText}");
                Console.WriteLine($"_entryText: {entry._entryText}");
                Console.WriteLine();
            }
    }

    public void SaveAsJSON(string filename){
        
       
        List<Entry> destination = _entries.Select(d => new Entry  
        {  
                _date = d._date,  
                _promptText = d._promptText,  
                _entryText = d._entryText           
        }).ToList();  
  
  
        string jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions() { WriteIndented = true});  
        using (StreamWriter outputFile = new StreamWriter(filename))  
        {  
            outputFile.WriteLine(jsonString);  
        } 
        
    }
    public void LoadFromFile(string filename){
       
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string promptText = parts[1];
            string entryText=parts[2];

            Console.WriteLine($"{date} {promptText} {entryText}");
        }
    }
}

