using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Start Investing", "MoneyDecoded", 420);
        video1._comments.Add(new Comment("James", "This was really helpful."));
        video1._comments.Add(new Comment("Ada", "I finally understand index funds."));
        video1._comments.Add(new Comment("Michael", "Great explanation and examples."));

        Video video2 = new Video("Top 5 Budgeting Mistakes", "Finance Hub", 315);
        video2._comments.Add(new Comment("Sarah", "I’ve made at least two of these."));
        video2._comments.Add(new Comment("Daniel", "Simple and easy to follow."));
        video2._comments.Add(new Comment("Grace", "Please make a part 2."));
        video2._comments.Add(new Comment("Tobi", "The zero-based budget tip was gold."));

        Video video3 = new Video("Why Smart People Stay Broke", "MoneyDecoded", 510);
        video3._comments.Add(new Comment("Chris", "This title got my attention immediately."));
        video3._comments.Add(new Comment("Ella", "The lifestyle inflation point was so true."));
        video3._comments.Add(new Comment("Victor", "One of your best videos so far."));

        Video video4 = new Video("Emergency Fund Basics", "Wealth Builders", 280);
        video4._comments.Add(new Comment("Nina", "Short and practical."));
        video4._comments.Add(new Comment("Sam", "I’m starting mine this month."));
        video4._comments.Add(new Comment("Peter", "Thanks for keeping it simple."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}