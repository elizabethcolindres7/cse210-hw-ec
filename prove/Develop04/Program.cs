using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Relaxation Activities Program!");

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Looking Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            if (choice == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathingActivity.PerformBreathingActivity();
            }
            else if (choice == 2)
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflectionActivity.PerformReflectionActivity();
            }
            else if (choice == 3)
            {
                ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                listingActivity.PerformListingActivity();
            }
            else if (choice == 4)
            {
                LookingActivity lookingActivity = new LookingActivity("Looking", "This activity will help you recognize and see the things you are surrounded by.");
                lookingActivity.PerformLookingActivity();
            }
            else if (choice == 5)
            {
                Console.WriteLine("Exiting program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose 1, 2, 3, 4 or 5.");
            }
        }
    }
}
