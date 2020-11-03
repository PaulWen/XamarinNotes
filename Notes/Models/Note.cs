using System;
namespace Notes
{
    public class Note
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public int ImageSeed { get; private set; }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
            ImageSeed = new Random().Next(100000);
        }
    }
}
