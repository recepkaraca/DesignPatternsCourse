using System;

namespace DesignPatternsCourse
{
    class Singleton
    {
        static void Main(string[] args)
        {
            GameSun sun1 = GameSun.Instance;
            GameSun sun2 = GameSun.Instance;
            sun1.sunRadius = 3;
            sun2.sunRadius = 5;
            Console.WriteLine(sun1.sunRadius);
        }
    }

    public sealed class GameSun
    {
        public int sunRadius { get; set; }

        private GameSun()
        {
        }

        private static readonly Lazy<GameSun> gameSun = new Lazy<GameSun>(() => new GameSun());

        public static GameSun Instance
        {
            get
            {
                return gameSun.Value;
            }
        }

        public void Rise()
        {
            Console.WriteLine("Sun raised") ;
        }
    }
}
