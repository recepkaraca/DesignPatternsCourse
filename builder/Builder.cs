using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCourse.Builder
{
    class BuilderMain
    {
        static void Main(string[] args)
        {
            PhoneBuilder builder;

            Shop shop = new Shop();

            builder = new AppleBuilder();
            shop.Construct(builder);
            builder.Phone.Show();

            builder = new SamsungBuilder();
            shop.Construct(builder);
            builder.Phone.Show();

            builder = new XiaomiBuilder();
            shop.Construct(builder);
            builder.Phone.Show();
        }
    }

    class Shop
    {
        public void Construct(PhoneBuilder phoneBuilder)
        {
            phoneBuilder.BuildProcessor();
            phoneBuilder.BuildScreen();
            phoneBuilder.BuildRam();
            phoneBuilder.BuildMemory();
        }
    }

    abstract class PhoneBuilder
    {
        protected Phone phone;

        public Phone Phone
        {
            get { return phone; }
        }

        public abstract void BuildProcessor();
        public abstract void BuildScreen();
        public abstract void BuildRam();
        public abstract void BuildMemory();
    }

    class AppleBuilder : PhoneBuilder
    {
        public AppleBuilder()
        {
            phone = new Phone("Apple");
        }

        public override void BuildProcessor()
        {
            phone["processor"] = "Apple A13 Bionic";
        }

        public override void BuildScreen()
        {
            phone["screen"] = "6.5 inch";
        }

        public override void BuildRam()
        {
            phone["ram"] = "4 GB";
        }

        public override void BuildMemory()
        {
            phone["memory"] = "512 GB";
        }
    }

    class SamsungBuilder : PhoneBuilder

    {
        public SamsungBuilder()
        {
            phone = new Phone("Samsung");
        }

        public override void BuildProcessor()
        {
            phone["processor"] = "Exynos 990";
        }

        public override void BuildScreen()
        {
            phone["screen"] = "6.9 inch";
        }

        public override void BuildRam()
        {
            phone["ram"] = "12 GB";
        }

        public override void BuildMemory()
        {
            phone["memory"] = "128 GB";
        }
    }

    class XiaomiBuilder : PhoneBuilder

    {
        public XiaomiBuilder()
        {
            phone = new Phone("Xiaomi");
        }

        public override void BuildProcessor()
        {
            phone["processor"] = "Snapdragon 865";
        }

        public override void BuildScreen()
        {
            phone["screen"] = "6.67 inch";
        }

        public override void BuildRam()
        {
            phone["ram"] = "8 GB";
        }

        public override void BuildMemory()
        {
            phone["memory"] = "256 GB";
        }
    }

    class Phone
    {
        private string _brand;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();

        public Phone(string brand)
        {
            this._brand = brand;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine(" Phone Brand: {0}", _brand);
            Console.WriteLine(" Processor : {0}", _parts["processor"]);
            Console.WriteLine(" Screen : {0}", _parts["screen"]);
            Console.WriteLine(" Ram : {0}", _parts["ram"]);
            Console.WriteLine(" Internal Memory : {0}", _parts["memory"]);
        }
    }
}
