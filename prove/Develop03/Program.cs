using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a new Scripture object
        Scripture john141516 = new Scripture();

        // Set the reference for John 14:15-16
        john141516.SetReference("John", 14, 15, 16);

        // Add words for the verses
        john141516.AddWord("15.", false);
        john141516.AddWord("If", false);
        john141516.AddWord("ye", false);
        john141516.AddWord("love me", false);
        john141516.AddWord(",", false);
        john141516.AddWord("keep ", false);
        john141516.AddWord("my", false);
        john141516.AddWord("commandments.", false);
        john141516.AddWord("\n16.", false);
        john141516.AddWord("And", false);
        john141516.AddWord("I will", false);
        john141516.AddWord("pray", false);
        john141516.AddWord("the Father,", false);
        john141516.AddWord("and he", false);
        john141516.AddWord("shall", false);
        john141516.AddWord("give", false);
        john141516.AddWord("you", false);
        john141516.AddWord("another", false);
        john141516.AddWord("Comforter,", false);
        john141516.AddWord("that he", false);
        john141516.AddWord("may", false);
        john141516.AddWord("abide", false);
        john141516.AddWord("with you;", false);
        john141516.AddWord("for ever;", false);

        // Display the verse and the scripture
        john141516.Display();

        // Ask the user to continue or quit
        Console.WriteLine("\nPress enter to continue or type \"quit\" to finish.");
        string input = Console.ReadLine();

        // Keep asking until user types "quit"
        while (input.ToLower() != "quit")
        {
            // Replace words until all words are hidden
            if (!john141516.AllWordsHidden())
            {
                john141516.HideRandomWord();
                john141516.ClearConsole();
                john141516.Display();
                Console.WriteLine("\nPress enter to continue or type \"quit\" to finish.");
                input = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("All words are hidden. Here are some questions:");
                john141516.DisplayQuestions();
                Console.WriteLine("\nPress enter to finish.");
                input = Console.ReadLine();

                // Display answers and evaluate correctness
                john141516.EvaluateAnswers();
                break;
            }
        }
    }
}

public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private List<string> questions;
    private Dictionary<string, string> correctAnswers;

    public Scripture()
    {
        reference = new Reference();
        words = new List<Word>();
        questions = new List<string>();
        correctAnswers = new Dictionary<string, string>();

        // Add questions and correct answers associated with the scripture passage
        questions.Add("How can you show Jesus you love him?");
        questions.Add("What will Jesus do if we keep his commandments?");
        
        correctAnswers.Add("How can you show Jesus you love him?", "If the answer includes commandments is correct otherwise is not correct.");
        correctAnswers.Add("What will Jesus do if we keep his commandments?", "And if the answer includes pray is correct otherwise is not correct.");
    }

    public void SetReference(string book, int chapter, int verse, int endVerse)
    {
        reference.SetBook(book);
        reference.SetChapter(chapter);
        reference.SetVerse(verse);
        reference.SetEndVerse(endVerse);
    }

    public void AddWord(string text, bool isHidden)
    {
        words.Add(new Word(text, isHidden));
    }

    public void Display()
    {
        Console.WriteLine($"Scripture: {reference.GetBook()} {reference.GetChapter()}:{reference.GetVerse()}-{reference.GetEndVerse()}");
        foreach (Word word in words)
        {
            if (word.IsHidden)
                Console.Write("_ ");
            else
                Console.Write(word.GetText() + " ");
        }
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(words.Count);
        words[index].Hide();
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }

    public void ClearConsole()
{
    try
    {
        Console.Clear();
    }
    catch (System.IO.IOException)
    {
        // Handle the exception gracefully
        // You can simply ignore it or display a message
        Console.WriteLine("Unable to clear the console.");
    }
}

    public void DisplayQuestions()
    {
        foreach (string question in questions)
        {
            Console.WriteLine(question);
        }
    }

    public void EvaluateAnswers()
    {
        foreach (var question in correctAnswers)
        {
            Console.WriteLine($"Question: {question.Key}");
            Console.WriteLine($"Correct Answer: {question.Value}");
            Console.WriteLine("Your Answer: ");
            string userAnswer = Console.ReadLine();
            if (userAnswer != null && userAnswer.ToLower() == correctAnswers[question.Key].ToLower())
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect!");
            }
            Console.WriteLine();
        }
    }
}

public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text, bool isHidden)
    {
        this.text = text;
        this.isHidden = isHidden;
    }

    public string GetText()
    {
        return text;
    }

    public bool IsHidden
    {
        get { return isHidden; }
    }

    public void Hide()
    {
                isHidden = true;
    }
}

public class Reference
{
    private string book;
    private int chapter;
    private int verse;
    private int endVerse;

    public void SetBook(string book)
    {
        this.book = book;
    }

    public string GetBook()
    {
        return book;
    }

    public void SetChapter(int chapter)
    {
        this.chapter = chapter;
    }

    public int GetChapter()
    {
        return chapter;
    }

    public void SetVerse(int verse)
    {
        this.verse = verse;
    }

    public int GetVerse()
    {
        return verse;
    }

    public void SetEndVerse(int endVerse)
    {
        this.endVerse = endVerse;
    }

    public int GetEndVerse()
    {
        return endVerse;
    }
}
