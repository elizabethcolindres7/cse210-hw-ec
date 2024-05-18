class LookingActivity : Activity
{
    public LookingActivity(string name, string description) : base(name, description)
    {
    }
    public void PerformLookingActivity()
    {
        DisplayStartingMessage();

        string[] prompts = {
            "Recognize 5 things you can see in this moment.",
            "Recognize 4 things you can listen to in this moment.",
            "Recognize 3 things you can feel in this moment.",
            "Recognize 2 things you can smell at this moment.",
            "Recognize 1 thing you can taste in this moment."
        };

        int timePerPrompt = _duration / prompts.Length;

        foreach (string prompt in prompts)
        {
            Console.WriteLine(prompt);
            PauseWithSpinner(timePerPrompt);
        }

        DisplayEndingMessage();
    }
}
