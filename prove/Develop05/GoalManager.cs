class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private List<string> _positivePhrases;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _positivePhrases = new List<string>
        {
            "What you do today can improve all your tomorrows. Ralph Marston",
            "To hell with circumstances; I create opportunities. Bruce Lee",
            "Action is the foundational key to all success. Pablo Picasso",
            "Things do not happen. Things are made to happen. John F. Kennedy",
            "The most effective way to do it, is to do it. Amelia Earhart",
            "You just can't beat the person who never gives up. Babe Ruth",
            "Step by step and the thing is done. Charles Atlas",
            "Enthusiasm moves the world. Arthur Balfour",
            "From a small seed a mighty trunk may grow. Aeschylus",
            "There is nothing impossible to him who will try. Alexander the Great"
        };
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string choice = Console.ReadLine();

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter the target number of times to complete the goal: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points for completing the goal: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
            writer.WriteLine($"Score|{_score}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts[0] == "SimpleGoal")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]))
                    {
                        IsCompleteGoal = bool.Parse(parts[4])
                    };
                    _goals.Add(goal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]))
                    {
                        AmountCompleted = int.Parse(parts[4])
                    };
                    _goals.Add(goal);
                }
                else if (parts[0] == "Score")
                {
                    _score = int.Parse(parts[1]);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select the goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Goal goal = _goals[choice];
            goal.RecordEvent();

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetPointsForCompletion();
            }
            else
            {
                _score += goal.Points;
            }

            DisplayPositivePhrase();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void DisplayPositivePhrase()
    {
        Random random = new Random();
        int index = random.Next(_positivePhrases.Count);
        Console.WriteLine(_positivePhrases[index]);
    }
}