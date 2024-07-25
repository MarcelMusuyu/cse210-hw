using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2024", 30, 4.8));
        activities.Add(new Cycling("04 Nov 2024", 45, 20));
        activities.Add(new Swimming("05 Nov 2024", 35, 10));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}