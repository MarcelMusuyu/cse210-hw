using System;

public class Entry{
    public string _date  {get;set;}
    public string _promptText  {get;set;}
    public string _entryText {get;set;}
    public string _mood { get; set; }
    public int _motivationLevel { get; set; }
    //The constructors
    public Entry(){

    }

    public void Display(){
         Console.WriteLine($"{_date},{_promptText},{_entryText}, {_mood}, {_motivationLevel}");
    }
}