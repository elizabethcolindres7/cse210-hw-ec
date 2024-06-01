public class Program
{
    public static void Main(string[] args)
    {
        
        Video video1 = new Video("How to Cook Pasta", "Chef John", 600);
        Video video2 = new Video("Yoga for Beginners", "Yoga with Adriene", 1800);
        Video video3 = new Video("Learn C# in 10 Minutes", "CodeAcademy", 600);

        
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative, thanks!"));
        video1.AddComment(new Comment("Charlie", "I love pasta!"));

        video2.AddComment(new Comment("Dave", "This is so helpful."));
        video2.AddComment(new Comment("Eve", "Namaste!"));
        video2.AddComment(new Comment("Frank", "Perfect for beginners."));

        video3.AddComment(new Comment("Grace", "This really helped me understand C#!"));
        video3.AddComment(new Comment("Heidi", "Excellent tutorial."));
        video3.AddComment(new Comment("Ivan", "Quick and easy to follow."));

        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}