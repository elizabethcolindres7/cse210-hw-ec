using System;

class Program
{
    static void Main(string[] args)
    {
        
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()}"); // Using GetFractionString
        Console.WriteLine($"Fraction 1 Decimal Value: {fraction1.GetDecimalValue()}"); // Using GetDecimalValue

        
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()}");
        Console.WriteLine($"Fraction 2 Decimal Value: {fraction2.GetDecimalValue()}");

        
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()}");
        Console.WriteLine($"Fraction 3 Decimal Value: {fraction3.GetDecimalValue()}");

        
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"Fraction 4: {fraction4.GetFractionString()}");
        Console.WriteLine($"Fraction 4 Decimal Value: {fraction4.GetDecimalValue()}");
    }
}
