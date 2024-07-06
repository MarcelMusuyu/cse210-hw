public class References
{
    private string _book{get;set;}
    private int _chapter{get;set;}
    private int _verse{get; set;}
    private int _endVerse {get; set;}
    public References(string book, int chapter, int verse){
        _book=book;
        _chapter=chapter;
        _verse=verse;
    }

     public References(string book, int chapter, int startVerse,int endVerse){
        _book=book;
        _chapter=chapter;
        _verse=startVerse;
        _endVerse=endVerse;
    }
}

  