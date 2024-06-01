public class Program
{
    public static void Main()
    {
        
        Address address1 = new Address("123 Elm Street", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");

        
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        Product product1 = new Product("Widget", "W123", 10.00, 2);
        Product product2 = new Product("Gadget", "G456", 20.00, 1);
        Product product3 = new Product("Thingamajig", "T789", 5.00, 5);
        Product product4 = new Product("Doohickey", "D012", 7.50, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}