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

    public double GetShippingCost()
    {
        return customer.LivesInUSA() ? 5 : 35;
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }
        total += GetShippingCost();
        return total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in products)
        {
            packingLabel += $"Product: {product.Name}, ID: {product.ProductId}, Price: ${product.Price:0.00}, Quantity: {product.Quantity}, Total Cost: ${product.GetTotalCost():0.00}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
    }
}