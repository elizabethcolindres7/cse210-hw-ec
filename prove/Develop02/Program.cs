using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journals journals = new Journals();
        PromptGenerator promptGenerator = new PromptGenerator();

        Dictionary<int, Action<Journals, PromptGenerator>> menuOptions = new Dictionary<int, Action<Journals, PromptGenerator>>()
        {
            { 1, WriteJournalEntry },
            { 2, DisplayAllEntries },
            { 3, LoadEntries },
            { 4, SaveEntries },
            { 5, (j, p) => Environment.Exit(0) } 
        };

        Console.WriteLine("Welcome to the journal Program!");

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (menuOptions.ContainsKey(choice))
                {
                    menuOptions[choice].Invoke(journals, promptGenerator);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose again.");
            }
        }
    }

    static void WriteJournalEntry(Journals journals, PromptGenerator promptGenerator)
{
    Console.WriteLine("Writing journal entry...");

    string randomPrompt = promptGenerator.GetRandomPrompt();

    
    string dailyPrompt = promptGenerator.GetDailyPrompt();

    
    Console.WriteLine("Random Prompt: " + randomPrompt);
    Console.WriteLine("Daily Prompt: " + dailyPrompt);

    
    Console.WriteLine("Choose a prompt above or write your own:");
    string userPrompt = Console.ReadLine();

    
    string promptToUse = !string.IsNullOrWhiteSpace(userPrompt) ? userPrompt : randomPrompt;
    Entry newEntry = new Entry(promptToUse);
    journals.AddEntry(newEntry);
}

    static void DisplayAllEntries(Journals journals, PromptGenerator promptGenerator)
    {
        Console.WriteLine("Displaying all entries:");
        journals.DisplayAll();
    }

    static void LoadEntries(Journals journals, PromptGenerator promptGenerator)
    {
        Console.Write("Enter file name to load: ");
        string loadFile = Console.ReadLine();
        journals.LoadFromFile(loadFile);
    }

    static void SaveEntries(Journals journals, PromptGenerator promptGenerator)
    {
        Console.Write("Enter file name to save: ");
        string saveFile = Console.ReadLine();
        journals.SaveToFile(saveFile);
    }
}

class Journals
{
    private List<Entry> _entries;

    public Journals()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine("Journal entry added.");
        Console.WriteLine();
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine();
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine("Entries saved to file.");
        Console.WriteLine();
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(loadedEntry);
            }
        }
        Console.WriteLine("Entries loaded from file.");
        Console.WriteLine();
    }
}

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public Entry(string promptText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _promptText = promptText;
        Console.WriteLine($"{_promptText}");
        _entryText = Console.ReadLine();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    public override string ToString()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}

class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetDailyPrompt()
    {
        string[] dailyPrompts = {
            "Write about a goal you want to accomplish this week.",
            "Describe a challenge you faced today and how you overcame it.",
            "Reflect on a recent success or achievement and what it means to you.",
            "What is something new you learned today? Write about it.",
            "Imagine your ideal day. What does it look like?"
        };
        
        
        DateTime today = DateTime.Today;
        int index = today.DayOfYear % dailyPrompts.Length; 

        return dailyPrompts[index];
    }
}
