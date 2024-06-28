using System.Text;

public class Word{
    private string _text;
    private  bool _isHidden;
    public Word(string word ){
        _text=word;
        _isHidden=false;
    }
    public void Hide(){
        _isHidden=true;

    }
    public void Show(){
        _isHidden=false;
    }
    public string GetDisplayText(){
        if(_isHidden){
            
            return new string('_',_text.Length);
        }else{
            return _text;
        }
    }

    public void SetText(string text){
        _text=text;
    }
    public string GetText(){
        return _text;
    }
    public bool IsHidden(){
        return _isHidden;
    }
}