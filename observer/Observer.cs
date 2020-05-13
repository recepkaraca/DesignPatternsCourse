using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatternsCourse.Observer
{
    abstract class Car
    {
        private string _brand;
        private double _price;
        private List<IDealer> _dealers = new List<IDealer>();

        public Car(string brand, double price)

        {
            this._brand = brand;
            this._price = price;
        }

        public void Attach(IDealer dealer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            _dealers.Add(dealer);
        }

        public void Detach(IDealer dealer)

        {
            Console.WriteLine("Subject: Detached an observer.");
            _dealers.Remove(dealer);
        }
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (IDealer dealer in _dealers)
            {
                dealer.Update(this);
            }

            Console.WriteLine("");
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        public string Brand
        {
            get { return _brand; }
        }
    }

    class Mercedes : Car { 
        public Mercedes(string brand, double price) : base(brand, price)
        { 
        }
    }

    interface IDealer

    {
        void Update(Car car);
    }

    class Dealer : IDealer
    {
        private string _brand;
        private Car _car;
        public Dealer(string brand)
        {
            this._brand = brand;
        }

        public void Update(Car car)
        {
            Console.WriteLine("Notified {0} of {1}'s " + "change to {2:C}", _car, car.Brand, car.Price);
        }
        public Car Car
        {
            get { return _car; }
            set { _car = value; }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var rnd = new Random();
            Mercedes mercedes = new Mercedes("Mercedes", 200000);
            Dealer dealer1 = new Dealer("Dealer1");
            Dealer dealer2 = new Dealer("Dealer2");
            mercedes.Price = 200000;
            Parallel.For(0, 5, (i, loopState) =>
            {
                int delay;
                lock (rnd)
                    delay = rnd.Next(1, 1001);
                Thread.Sleep(delay);
                Console.WriteLine("Thread : " + i);
                mercedes.Attach(dealer1);
                mercedes.Price += i;
                mercedes.Detach(dealer1);
            });

        }
    }
}
