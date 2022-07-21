using System.Text;

namespace Refactoring
{
    class Program
    {
        private const string PerPound = "PerPound";
        private const string PerItem = "PerItem";
        
        static void Main(string[] args)
        {
            var orders = new Dictionary<string, List<Product>>()
            {
                {
                    "John Doe",
                    new List<Product>
                    {
                        new()
                        {
                            ProductName = "Pulled Pork",
                            Price = 6.99m,
                            Weight = 0.5m,
                            PricingMethod = PerPound,
                        },
                        new()
                        {
                            ProductName = "Coke",
                            Price = 3m,
                            Quantity = 2,
                            PricingMethod = PerItem
                        }
                    }
                }
            };
            
            
            foreach (var order in orders)
            {
                var totalPrice = 0m;
                
                StringBuilder orderSummary = new StringBuilder($"ORDER SUMMARY FOR {order.Key} \r\n");
                
                foreach (var product in order.Value)
                {
                    var productPrice = 0m;
                    orderSummary.Append(product.ProductName);
 
                    if (product.PricingMethod == PerPound)
                    {
                        productPrice = (product.Weight.Value * product.Price);
                        totalPrice += productPrice;
                        orderSummary.Append($" {productPrice} ( {product.Weight} pounds at {product.Price} per pound)");
                    }
                    if(product.PricingMethod == PerItem)
                    {
                        productPrice = (product.Quantity.Value * product.Price);
                        totalPrice += productPrice;
                        orderSummary.Append($" {productPrice} ( {product.Quantity} items at {product.Price} each)");
                    }
 
                    orderSummary.Append("\r\n");
                }
                
                Console.WriteLine(orderSummary.ToString());
                Console.WriteLine($"Total Price: $ {totalPrice} \r\n");
            }
            
          
 
            Console.ReadKey();
        }
    }
}

