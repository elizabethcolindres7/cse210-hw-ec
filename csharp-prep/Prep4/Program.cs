using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)

    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;

        do
        {
            Console.WriteLine("Enter number: ");
            number = int.Parse(Console.ReadLine());
            numbers.Add(number);
        }while (number != 0);

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum of the numbers entered is: {sum}");

         float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int num in numbers)
        {
            if (number > max)
            {
                // if this number is greater than the max, we have found the new max!
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}