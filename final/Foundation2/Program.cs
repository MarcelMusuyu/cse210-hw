using System;

class Program
{
    static void Main(string[] args)
    {
        Address address=new Address("Barker street","Manathan","New work","USA");
        Customer client= new Customer("John Doe",address);
        Product product1= new Product(1,"LapTop",500,2);
        Product product2= new Product(2,"Hard drive",50,14);
        Product product3=new Product(3,"Window Server",1000,1);
        List<Product> _productsList=new List<Product>{product1,product2,product3};
        Order order =new Order(_productsList,client);
       
       
        Console.WriteLine($"{order.GetPackingLabel()}\n");
        Console.WriteLine($"{order.GetShippingLabel()}\n");
        Console.WriteLine($"The total order cost is ${order.ComputeTotalCost()}");
       

        Console.WriteLine();
        Address address2=new Address("National park street","Central City","Kinshasa","DRC");
        Customer client2= new Customer("Jonny Ashley",address2);
        Product product4= new Product(5,"Pizza",50f,2);
        Product product5= new Product(6,"Cake",2f,14);
        Product product6=new Product(9,"Candy",100,2);
        Product product7=new Product(10,"Biscuit",5f,15);
        List<Product> _productsList2=new List<Product>{product4,product5,product6,product7};
        Order order2 =new Order(_productsList2,client2);
     
         Console.WriteLine($"{order2.GetPackingLabel()}\n");
        Console.WriteLine($"{order2.GetShippingLabel()}\n");
           Console.WriteLine($"The total order cost is ${order2.ComputeTotalCost()}");
    }
}