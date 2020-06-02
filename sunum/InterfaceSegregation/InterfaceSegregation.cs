using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCourse.SOLID
{
    public interface IGenericRcCommander
    {
        void MoveForward();
        void MoveBack();
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void StartEngine();
        void StopEngine();
        void SpeedUpEngine();
        void SpeedDownEngine();
        void LoadContainer();
        void DropContainer();
    }

    class RcCarCommanderGeneric : IGenericRcCommander
    {
        public void MoveForward()
        {
            Console.WriteLine("Move forward signal sent to car.");
        }

        public void MoveBack()
        {
            Console.WriteLine("Move back signal sent to car.");
        }

        public void MoveRight()
        {
            Console.WriteLine("Move right signal sent to car.");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Move left signal sent to car.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start engine signal sent to car.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop engine signal sent to car.");
        }

        public void SpeedUpEngine()
        {
            Console.WriteLine("Speed up signal sent to car.");
        }

        public void SpeedDownEngine()
        {
            Console.WriteLine("Speed down signal sent to car.");
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void LoadContainer() { }
        public void DropContainer() { }
    }

    public interface IBasicRcController
    {
        void MoveForward();
        void MoveBack();
        void MoveRight();
        void MoveLeft();
        void StartEngine();
        void StopEngine();
        void SpeedUpEngine();
        void SpeedDownEngine();
    }

    public interface IFlyableRcController
    {
        void MoveUp();
        void MoveDown();
    }

    public interface IShipRcController
    {
        void LoadContainer();
        void DropContainer();
    }

    class Car { }
    class Ship { }
    class Drone { }

    class RcCarCommander : IBasicRcController
    {
        public Car connectedCar { get; set; }

        public RcCarCommander()
        {
            Console.WriteLine("RC Car Controller Created.");
        }

        public void MoveForward()
        {
            Console.WriteLine("Move forward signal sent to car.");
        }

        public void MoveBack()
        {
            Console.WriteLine("Move back signal sent to car.");
        }

        public void MoveRight()
        {
            Console.WriteLine("Move right signal sent to car.");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Move left signal sent to car.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start engine signal sent to car.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop engine signal sent to car.");
        }

        public void SpeedUpEngine()
        {
            Console.WriteLine("Speed up signal sent to car.");
        }

        public void SpeedDownEngine()
        {
            Console.WriteLine("Speed down signal sent to car.");
        }
    }

    class RcDroneController : IBasicRcController, IFlyableRcController
    {
        public Drone connectedDrone { get; set; }

        public RcDroneController()
        {
            Console.WriteLine("RC Drone Controller Created.");
        }

        public void MoveForward()
        {
            Console.WriteLine("Move forward signal sent to drone.");
        }

        public void MoveBack()
        {
            Console.WriteLine("Move back signal sent to drone.");
        }

        public void MoveRight()
        {
            Console.WriteLine("Move right signal sent to drone.");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Move left signal sent to drone.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start engine signal sent to drone.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop engine signal sent to drone.");
        }

        public void SpeedUpEngine()
        {
            Console.WriteLine("Speed up signal sent to drone.");
        }

        public void SpeedDownEngine()
        {
            Console.WriteLine("Speed down signal sent to drone.");
        }

        public void MoveUp()
        {
            Console.WriteLine("Move up signal sent to drone.");
        }

        public void MoveDown()
        {
            Console.WriteLine("Move down signal sent to drone.");
        }
    }

    class RcShipController : IBasicRcController, IShipRcController
    {
        public Ship connectedShip { get; set; }
        public RcShipController()
        {
            Console.WriteLine("RC Ship Controller Created.");
        }
        public void MoveForward()
        {
            Console.WriteLine("Move forward signal sent to ship.");
        }

        public void MoveBack()
        {
            Console.WriteLine("Move back signal sent to ship.");
        }

        public void MoveRight()
        {
            Console.WriteLine("Move right signal sent to ship.");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Move left signal sent to ship.");
        }

        public void StartEngine()
        {
            Console.WriteLine("Start engine signal sent to ship.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Stop engine signal sent to ship.");
        }

        public void SpeedUpEngine()
        {
            Console.WriteLine("Speed up signal sent to ship.");
        }

        public void SpeedDownEngine()
        {
            Console.WriteLine("Speed down signal sent to ship.");
        }

        public void LoadContainer()
        {
            Console.WriteLine("Load container signal sent to ship.");
        }

        public void DropContainer()
        {
            Console.WriteLine("Drop container signal sent to ship.");
        }
    }

    public class InterfaceSegregation
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            RcCarCommander rcCarCommander = new RcCarCommander();
            rcCarCommander.connectedCar = car;
            rcCarCommander.StartEngine();
            rcCarCommander.MoveForward();
            rcCarCommander.SpeedUpEngine();
            Console.WriteLine();
            Ship ship = new Ship();
            RcShipController rcShipController = new RcShipController();
            rcShipController.connectedShip = ship;
            rcShipController.StartEngine();
            rcShipController.SpeedUpEngine();
            rcShipController.LoadContainer();
            Console.WriteLine();
            Drone drone = new Drone();
            RcDroneController rcDroneController = new RcDroneController();
            rcDroneController.connectedDrone = drone;
            rcDroneController.StartEngine();
            rcDroneController.SpeedUpEngine();
            rcDroneController.MoveUp();
        } 
    }
}
