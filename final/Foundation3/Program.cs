using System;

class Program
{
    static void Main(string[] args)
    {
        // Create events
        Address address = new Address("123 Main Street", "New York", "NY", "USA");
        Address address1= new Address("456 Elm Street", "New York", "NY", "USA");
        Weather weather = new Weather("Sunny and warm", 25, 10, "Partly Cloudy", 60);

        Lectures lecture = new Lectures("AI and the Future", "Explore the impact of artificial intelligence on society.", "2024-03-15", "10:00 AM", address, "Dr. Smith", 100);
        Reception reception = new Reception("Networking Event", "Connect with industry professionals.", "2024-03-22", "6:00 PM",address1, "rsvp@example.com");
        OutdoorGathering gathering = new OutdoorGathering("Summer Picnic", "Enjoy a relaxing day outdoors.", "2024-06-15", "12:00 PM", address, weather);

        // Print marketing messages
        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(gathering.GetStandardDetails());
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine(gathering.GetShortDescription());
    }
}