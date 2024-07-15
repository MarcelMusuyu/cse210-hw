public class Video{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _commentsList;
    public Video(string title, string author, int length){
        _title=title;
        _author=author;
        _length=length;
        _commentsList=new List<Comment>();
    } 
    public void StoreComments(Comment comment){
        _commentsList.Add(comment);
    }

    public int GetNumberComments(){
        return _commentsList.Count;
    }
    public string GetTitle(){
        return _title;
    }

    public List<Comment> GetComments(){
        return _commentsList;
    }


    public string GetAuthor(){
        return _author;
    }

    public int GetLength(){
        return _length;
    }
    
}


