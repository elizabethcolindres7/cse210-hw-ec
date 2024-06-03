using System;
using EventPlanning; // Ensure this directive is present

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "62701");
        Address address2 = new Address("456 Elm St", "Chicago", "IL", "60601");
        Address address3 = new Address("789 Oak St", "Peoria", "IL", "61601");

        Lecture lecture = new Lecture("Tech Talk", "A lecture on modern technology.", DateTime.Now.AddDays(5), "10:00 AM", address1, "John Doe", 100);
        Reception reception = new Reception("Company Gala", "Annual company gala event.", DateTime.Now.AddDays(10), "6:00 PM", address2, "rsvp@company.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "A fun outdoor picnic for the community.", DateTime.Now.AddDays(15), "1:00 PM", address3, "Sunny");

        Event[] events = { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("Full Details:");
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("Short Description:");
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
        }
    }
}
