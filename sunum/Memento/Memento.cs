using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCourse.Memento
{
    class MusicPlayer
    {
        public string MusicName { get; set; }
        public int Duration { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }

        public override string ToString()
        {
            return $"You are currently listening\nMusic Name: {MusicName}\nDuration: {Duration} second\n" +
                $"Artist: {Artist}\nRelease Year: {ReleaseYear}";
        }

        public MusicPlayerMemento Save()
        {
            return new MusicPlayerMemento
            {
                MusicName = this.MusicName,
                Duration = this.Duration,
                Artist = this.Artist,
                ReleaseYear = this.ReleaseYear,
            };
        }

        public void PreviousMusic(MusicPlayerMemento memento)
        {
            this.MusicName = memento.MusicName;
            this.Duration = memento.Duration;
            this.Artist = memento.Artist;
            this.ReleaseYear = memento.ReleaseYear;

            Console.WriteLine("\nGoing back to previous music...\n");
        }
    }

    class MusicPlayerMemento
    {
        public string MusicName { get; set; }
        public int Duration { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
    }

    class MusicPlayerCareTaker
    {
        public MusicPlayerMemento Memento { get; set; }
    }

    class MementoRun
    {
        static void Main(string[] args)
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.MusicName = "Moves Like Jagger";
            musicPlayer.Duration = 278;
            musicPlayer.Artist = "Maroon 5";
            musicPlayer.ReleaseYear = 2011;
            Console.WriteLine(musicPlayer.ToString());

            MusicPlayerCareTaker taker = new MusicPlayerCareTaker();
            taker.Memento = musicPlayer.Save();

            musicPlayer.MusicName = "World Hold On";
            musicPlayer.Duration = 218;
            musicPlayer.Artist = "Bob Sinclar";
            musicPlayer.ReleaseYear = 2006;
            Console.WriteLine("\n" + musicPlayer.ToString());

            musicPlayer.PreviousMusic(taker.Memento);
            Console.WriteLine(musicPlayer.ToString());
        }
    }
}
