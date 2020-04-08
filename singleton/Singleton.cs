using System;

namespace DesignPatternsCourse
{
    public class SingletonMainClass
    {
        public static void Main(string[] args)
        {
            GameSun sun1 = GameSun.Instance;
            GameSun sun2 = GameSun.Instance;

            sun1.sunName = "sun1";
            Thread thr1 = new Thread(new ThreadStart(sun1.Rise));
            thr1.Start();
            sun2.sunName = "sun2";
            Thread thr2 = new Thread(new ThreadStart(sun2.Rise));
            thr2.Start();
        }
    }

    public sealed class GameSun
    {
        public string sunName { get; set; }

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
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine(sunName + " raised!");
            }
        }
    }
}
