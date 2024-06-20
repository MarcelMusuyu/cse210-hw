using System;

public class Entry{
    public string _date;
    public string _promptText;
    public string _entryText;
    //The constructor
    public Entry(){

    }

    public void Display(){
         Console.WriteLine($"{_date},{_promptText},{_entryText}");
    }
}