class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    public void PerformBreathingActivity()
    {
        DisplayStartingMessage();
        int count = 0;
        while (count < _duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithSpinner(3);
            Console.WriteLine("Breathe out...");
            PauseWithSpinner(3);
            count += 6;
        }
        DisplayEndingMessage();
    }
}