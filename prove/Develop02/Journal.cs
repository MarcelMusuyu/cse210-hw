using System;
using System.IO; 
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

