using System;
using System.Collections.Generic;

// Define the Comment class
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Define the Video class
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("Introduction to C#", "Alice", 300);
        var video2 = new Video("Advanced C# Techniques", "Bob", 600);
        var video3 = new Video("C# for Beginners", "Charlie", 480);

        // Add comments to video1
        video1.AddComment(new Comment("John", "Great video! Very informative."));
        video1.AddComment(new Comment("Jane", "Thanks for the tips!"));
        video1.AddComment(new Comment("Sam", "Loved the examples."));

        // Add comments to video2
        video2.AddComment(new Comment("Anna", "Very detailed and helpful."));
        video2.AddComment(new Comment("Mike", "This was a bit advanced for me."));
        video2.AddComment(new Comment("Emma", "Thank you for the insights."));

        // Add comments to video3
        video3.AddComment(new Comment("Ryan", "Perfect for beginners!"));
        video3.AddComment(new Comment("Sophie", "Well explained."));
        video3.AddComment(new Comment("Lucas", "A great introduction."));

        // Store the videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            var comments = video.GetComments();
            foreach (var comment in comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}