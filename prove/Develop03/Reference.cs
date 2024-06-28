public class Reference{
    private string _book{get;set;}
    private int _chapter{get;set;}
    private int _verse{get; set;}
    private int _endVerse {get; set;}
    public Reference(string book, int chapter, int verse){
        _book=book;
        _chapter=chapter;
        _verse=verse;
    }

     public Reference(string book, int chapter, int startVerse,int endVerse){
        _book=book;
        _chapter=chapter;
        _verse=startVerse;
        _endVerse=endVerse;
    }

    private string GetSingleVerse(){
        return $"{_book} {_chapter}:{_verse}";
    }

    private string GetFullVerses(){
        return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }

    public string GetDisplayText(){
        if(_endVerse==0){
            return GetSingleVerse();
        }
        return GetFullVerses();
    }
}