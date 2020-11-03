using System;
namespace Notes
{
    public class Note
    {

        public string Content { get; set; }
        public int ImageSeed { get; private set; }

        public Note(string content)
        {
            Content = content;
            ImageSeed = new Random().Next(100000);
        }
    }
}
