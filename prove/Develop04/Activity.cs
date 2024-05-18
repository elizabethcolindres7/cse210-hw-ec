using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string _name, string _description)
    {
        this._name = _name;
        this._description  = _description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3); 
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done! You have completed the {_name} Activity.");
        Console.WriteLine($"Duration: {_duration} seconds");
        PauseWithSpinner(3); 
    }

    protected void PauseWithSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000); 
        }
        Console.WriteLine();
    }
}
    