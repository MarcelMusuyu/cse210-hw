using System;

class Program
{
    static void Main(string[] args)
    {
       // Create a list of videos
        List<Video> videos = new List<Video>();

        // Create some videos
        Video video1 = new Video("Amazing Nature Scenes", "National Geographic", 360);
        Video video2 = new Video("How to Code in C#", "Codecademy", 1200);
        Video video3 = new Video("Funny Cat Videos Compilation", "The Cat Channel", 180);

        // Add comments to the videos
        video1.StoreComments(new Comment("John Doe", "Wow, such beautiful scenery!"));
        video1.StoreComments(new Comment("Jane Smith", "I love the music in this video."));
        video1.StoreComments(new Comment("Bob Johnson", "This is so relaxing."));

        video2.StoreComments(new Comment("Alice Brown", "This tutorial is really helpful!"));
        video2.StoreComments(new Comment("Charlie White", "I'm learning so much."));
        video2.StoreComments(new Comment("David Green", "Can't wait to try this out."));
        video2.StoreComments(new Comment("Marcel Nyembo", "Which wonderful  tutorial."));

        video3.StoreComments(new Comment("Emily Black", "These cats are hilarious!"));
        video3.StoreComments(new Comment("Frank Blue", "I can't stop laughing."));
        video3.StoreComments(new Comment("Gina Red", "This is the best cat video ever!"));
        video3.StoreComments(new Comment("France Paris", "very excited to see this video"));
        video3.StoreComments(new Comment("Emmanuel Macron","This the msot hilarious one"));

        // Add the videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Print information about each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Video Title: {video.GetTitle()}");
            Console.WriteLine($"Video Author: {video.GetAuthor()}");
            Console.WriteLine($"Video Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberComments()}");
            Console.WriteLine();
            foreach(Comment comment in video.GetComments()){
                Console.WriteLine($"\tComment Person: {comment.GetPersonName()}");
                Console.WriteLine($"\tComment Text: {comment.GetText()}");
                Console.WriteLine();
            }
        }
    }
}