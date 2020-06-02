using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DesignPatternsCourse.Adapter
{
    class CPUs
    {
        public int getCoreCount(string cpu)
        {
            switch(cpu.ToLower())
            {
                case "intel i9 9900k":
                case "intel i7 9700k":
                case "amd ryzen7 3700x":
                    return 8;
                case "amd ryzen5 3600":
                    return 6;
                default:
                    return 0;
            }
        }

        public int getThreadCount(string cpu)
        {
            switch (cpu.ToLower())
            {
                case "intel i9 9900k":
                case "amd ryzen7 3700x":
                    return 16;
                case "intel i7 9700k":
                    return 8;
                case "amd ryzen5 3600":
                    return 12;
                default:
                    return 0;
            }
        }

        public double getBaseClockSpeed(string cpu) 
        {
            switch (cpu.ToLower())
            {
                case "intel i9 9900k":
                case "intel i7 9700k":
                case "amd ryzen7 3700x":
                case "amd ryzen5 3600":
                    return 3.6;
                default:
                    return 0;
            }
        }

        public int getCacheSize(string cpu) 
        {
            switch (cpu.ToLower())
            {
                case "intel i9 9900k":
                    return 16;
                case "intel i7 9700k":
                    return 12;
                case "amd ryzen7 3700x":
                    return 36;
                case "amd ryzen5 3600":
                    return 35;
                default:
                    return 0;
            }
        }

        public int getReleaseYear(string cpu) 
        {
            switch (cpu.ToLower())
            {
                case "intel i9 9900k":
                case "intel i7 9700k":
                    return 2018;
                case "amd ryzen7 3700x":
                case "amd ryzen5 3600":
                    return 2019;
                default:
                    return 0;
            }
        }
    }

    class CPU
    {
        protected string CPUName;
        protected int CoreCount;
        protected int ThreadCount;
        protected double BaseClockSpeed;
        protected int CacheSize;
        protected int ReleaseYear;

        public CPU(string cpu)
        {
            this.CPUName = cpu;
        }

        public virtual void GetData()
        {
            Console.WriteLine("CPU: {0} ------> ", CPUName);

        }
    }

    class CPUInformations : CPU
    {
        private CPUs _cpus;

        public CPUInformations(string cpu) : base(cpu)
        {
        }

        public override void GetData()
        {
            _cpus = new CPUs();

            CoreCount = _cpus.getCoreCount(CPUName);
            ThreadCount = _cpus.getThreadCount(CPUName);
            BaseClockSpeed = _cpus.getBaseClockSpeed(CPUName);
            CacheSize = _cpus.getCacheSize(CPUName);
            ReleaseYear = _cpus.getReleaseYear(CPUName);

            base.GetData();
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine("<html lang='en'>");
            Console.WriteLine("\t<head>");
            Console.WriteLine("\t\t<title>{0}</title>", CPUName);
            Console.WriteLine("\t</head>");
            Console.WriteLine("\t<body>");
            Console.WriteLine("\t\t<div>");
            Console.WriteLine("\t\t\tCore Count: " + CoreCount);
            Console.WriteLine("\t\t\tThread Count: " + ThreadCount);
            Console.WriteLine("\t\t\tCore Count: " + CoreCount);
            Console.WriteLine("\t\t\tBase Clock Speed: " + BaseClockSpeed);
            Console.WriteLine("\t\t\tCache Size: " + CacheSize);
            Console.WriteLine("\t\t\tRelease Year: " + ReleaseYear);
            Console.WriteLine("\t\t</div>");
            Console.WriteLine("\t</body>");
            Console.WriteLine("</html>\n");
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Without adapter:");
            CPU cpu = new CPU("INTEL I9 9900K");
            cpu.GetData();
            Console.WriteLine();

            Console.WriteLine("With adapter:");
            CPUInformations intel9900k = new CPUInformations("INTEL I9 9900K");
            intel9900k.GetData();

            CPUInformations intel9700k = new CPUInformations("INTEL I7 9700K");
            intel9700k.GetData();

            CPUInformations amd3700x = new CPUInformations("AMD RYZEN7 3700X");
            amd3700x.GetData();

            CPUInformations amd3600 = new CPUInformations("AMD RYZEN5 3600");
            amd3600.GetData();
        }
    }
}
