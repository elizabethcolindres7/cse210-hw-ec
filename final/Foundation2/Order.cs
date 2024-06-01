public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public Customer Customer { get => customer; }
    public List<Product> Products { get => products; }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{customer.Name}\n{customer.Address}";
    }
}



Address
street: string      
city: string        
stateOrProvince: string 
country: string     
________________________
Address(street: string, city: string, stateOrProvince: string, country: string)
Street: string {get} 
City: string {get}   
StateOrProvince: string {get} 
Country: string {get}
IsInUSA(): bool      
ToString(): string   


Customer       
name: string      
address: Address  
_______________
Customer(name: string, address: Address)
Name: string {get} 
Address: Address {get}
LivesInUSA(): bool 


Order           
products: List<Product
customer: Customer    
____________________
 Order(customer: Customer)
Customer: Customer {get} 
Products: List<Product> {get}
AddProduct(product: Product)
GetTotalCost(): double    
GetPackingLabel(): string 
GetShippingLabel(): string