class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private int count; 

    public ListingActivity(string name, string description) : base(name, description)
    {
        // No need to initialize count here since it's automatically initialized to 0 by default
    }

    public void PerformListingActivity()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine($"You have {_duration} seconds to list as many items as you can.\n");

        var endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                break; 
            }
            else
            {
                count++;
                Console.WriteLine(input); 
            }
        }

        Console.WriteLine($"\nYou listed {count} items.");
        DisplayEndingMessage();
    }
}
