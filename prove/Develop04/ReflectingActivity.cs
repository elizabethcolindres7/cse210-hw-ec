class ReflectionActivity : Activity
{
    
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    // Reflection questions
    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string name, string description) : base(name, description)
    {
    }

    public void PerformReflectionActivity()
    {
        DisplayStartingMessage();
        Random rand = new Random();

        string prompt = _prompts[rand.Next(_prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience");
        Console.WriteLine("You may begin in:");
        PauseWithSpinner(5);

        int timePerQuestion = 5;
        int totalQuestions = _duration / timePerQuestion;
        int questionIndex = 0;
        int remainingTime = _duration;

        while (remainingTime > 0 && questionIndex < totalQuestions && questionIndex < _questions.Length)
        {
            Console.WriteLine(_questions[questionIndex]);
            PauseWithSpinner(timePerQuestion);
            remainingTime -= timePerQuestion;
            questionIndex++;
        }

        DisplayEndingMessage();
    }
}