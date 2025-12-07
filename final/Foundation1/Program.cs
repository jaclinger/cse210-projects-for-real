using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Cook Rice", "Chef Lina", 420);
        Video video2 = new Video("C# Beginner Tutorial", "TechGuru", 900);

        video1.AddComment(new Comment("Sarah", "This helped so much!"));
        video1.AddComment(new Comment("Mike", "Perfect tutorial."));
        video1.AddComment(new Comment("Jess", "Thanks Chef!"));

        video2.AddComment(new Comment("Leo", "Very clear explanation."));
        video2.AddComment(new Comment("Anna", "Exactly what I needed!"));

        List<Video> videos = new List<Video> { video1, video2 };

        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}
