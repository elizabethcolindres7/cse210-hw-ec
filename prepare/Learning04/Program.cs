using System;

class Program
{
    static void Main(string[] args) 
    {
        Assignment a1 = new Assignment("Abel Castro", "Math");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Abel Castro", "Math", "Section 7.3", "Problems 8-19");
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
