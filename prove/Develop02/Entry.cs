using System;

public class Entry{
    public string _date  {get;set;}
    public string _promptText  {get;set;}
    public string _entryText {get;set;}
    //The constructor
    public Entry(){

    }

    public void Display(){
         Console.WriteLine($"{_date},{_promptText},{_entryText}");
    }
}