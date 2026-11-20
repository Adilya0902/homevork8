using System;

namespace Task_9_1_Home
{
    public class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song PreviousSong { get; set; } 
        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            PreviousSong = null;
        }
        public Song(string name, string author, Song previousSong)
        {
            Name = name;
            Author = author;
            PreviousSong = previousSong;
        }
        public Song()
        {
        }
    }

    class Program
    {
        static void Main()
        {
            Song song1 = new Song("Владимирский централ", "Михаил Круг");
            Song song2 = new Song("Кукла колдуна", "Король и Шут", song1);
            Song mySong = new Song(); 
            Console.WriteLine("Песни созданы успешно.");
        }
    }
}