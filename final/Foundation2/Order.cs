public class Order{
    private List<Product> _productList=new List<Product>();
    private Customer _customer;
    private float _shippingCost;
   
   public Order(List<Product> products, Customer customer){
        _productList=products;
        _customer=customer;
        if(customer.IsLivingIsUSA()){
            _shippingCost=5;
        }else{
            _shippingCost=35;
        }
   }
        public float ComputeTotalCost(){
            float totalCost=0;
            foreach(Product product in _productList){
                totalCost +=product.GetPrice()*product.GetQuantity();
            }
            totalCost+=_shippingCost;
            return totalCost;
        }

        public string GetPackingLabel(){
            string packingLabel="-----------Packing Label-------------\n";
            foreach(Product product in _productList){
                packingLabel+= $"\t {product.GetName()}_{product.GetId()}";
            }
            return packingLabel;
        }

        public string GetShippingLabel(){
            return $"{_customer.GetName()}, {_customer.GetAddress().GetFullAddress()}";
        }
        
   }



