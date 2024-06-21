using System;
using System.IO; 
using System.Text.Json;

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
             outputFile.WriteLine("Date,Prompt,Response,Humour,Motivation");
            
            foreach(Entry item in _entries){
                item._promptText= item._promptText.Replace(",",";");
                outputFile.WriteLine($"\"{item._date}\",\"{EscapeCSVField(item._promptText)}\",\"{EscapeCSVField(item._entryText)}\",\"{EscapeCSVField(item._mood)}\",{item._motivationLevel}");
            }
        }
    }

    private string EscapeCSVField(string value)
    {
        return value.Replace("\"", "\"\"");
    }

     private string UnescapeCSVField(string value)
    {
        return value.Replace("\"\"", "\"");
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
                Console.WriteLine($"_entryText: {entry._mood}");
                Console.WriteLine($"_entryText: {entry._motivationLevel}");
                Console.WriteLine();
            }
    }

    public void SaveAsJSON(string filename){
        
       
        List<Entry> destination = _entries.Select(d => new Entry  
        {  
                _date = d._date,  
                _promptText = d._promptText,  
                _entryText = d._entryText,
                _mood=d._mood,
                _motivationLevel=d._motivationLevel           
        }).ToList();  
  
  
        string jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions() { WriteIndented = true});  
        using (StreamWriter outputFile = new StreamWriter(filename))  
        {  
            outputFile.WriteLine(jsonString);  
        } 
        
    }
    public void LoadFromFile(string filename){
       
         using (StreamReader reader = new StreamReader(filename))
        {
            // Skip the first line (header)
            reader.ReadLine();

            string line;

            while((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(",");

                string date = parts[0];
                string promptText = UnescapeCSVField(parts[1]);
                string entryText=UnescapeCSVField(parts[2]);
                string mood=UnescapeCSVField(parts[3]);
                int motivation=int.Parse(parts[4]);


                Console.WriteLine($"{date} {promptText} {entryText}, When your wrote your mood was ({mood}) and motivation level  ({motivation})");
            }
        }
    }
}

