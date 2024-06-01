using System;
using System.Collections.Generic;

public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name { get => name; }
    public string ProductId { get => productId; }
    public double Price { get => price; }
    public int Quantity { get => quantity; }

    public double GetTotalCost()
    {
        return price * quantity;
    }
}