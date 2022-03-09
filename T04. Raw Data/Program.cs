using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Raw_Data
{
    class Car
    {
        public Car(string model, Engine engineData, Cargo cargoData)
        {
            this.Model = model;
            this.EngineInfo = engineData;
            this.CargoInfo = cargoData;
        }

        public string Model { get; set; }

        public Engine EngineInfo { get; set; }

        public Cargo CargoInfo { get; set; }
    }

    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cargoSpecs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // "<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>"
                string model = cargoSpecs[0];
                int engineSpeed = int.Parse(cargoSpecs[1]);
                int enginePower = int.Parse(cargoSpecs[2]);
                int cargoWeight = int.Parse(cargoSpecs[3]);
                string cargoType = cargoSpecs[4];

                allCars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeight, cargoType)));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in allCars.Where(c => c.CargoInfo.CargoType == "fragile" && c.CargoInfo.CargoWeight < 1000))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                foreach (Car car in allCars.Where(c => c.CargoInfo.CargoType == "flamable" && c.EngineInfo.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
