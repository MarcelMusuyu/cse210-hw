public class Product{
    private int _id;
    private string _name;
    private float _price;
    private int _quantity;
    public  Product(int id, string name, float price, int quantity){
        _id=id;
        _name=name;
        _price=price;
        _quantity= quantity;
    }

    public int GetId(){
        return _id;
    }

    public void SetId(int id){
        _id=id;
    }
    public string GetName(){
        return _name;
    }
    public void SetName(string name){
        _name=name;
    }
    public float GetPrice(){
        return _price;
    }
    public void Setprice(float price){
        _price=price;
    }
    public int GetQuantity(){
        return _quantity;
    }
    public void SetQuantity(int quantity){
        _quantity=quantity;
    }

    public float TotalCost(int quantityOrdered){
        if(quantityOrdered >= _quantity){
            throw new Exception("The quantity in stock will not supply the Quantity Ordered");
        }
        return _price*quantityOrdered;
    }
}