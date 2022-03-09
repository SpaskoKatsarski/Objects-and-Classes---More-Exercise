using System;
using System.Collections.Generic;

namespace T03._Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKilometer;
            this.TraveledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double TraveledDistance { get; set; }

        public bool CanTheCarTravelDistance(double distanceToTravelInKm)
        {
            if (this.FuelAmount >= distanceToTravelInKm * this.FuelConsumptionPerKm)
            {
                return true;
            }

            return false;
        }

        public void CalculateTheChanges(double distanceToTravelInKM)
        {
            this.FuelAmount -= distanceToTravelInKM * this.FuelConsumptionPerKm;
            this.TraveledDistance += distanceToTravelInKM;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int carsToTrack = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsToTrack; i++)
            {
                string[] currCarInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = currCarInfo[0];
                double fuelAmount = double.Parse(currCarInfo[1]);
                double fuelConsumptionPerKm = double.Parse(currCarInfo[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKm));
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                // "Drive <CarModel> <amountOfKm>"  ==>  Input

                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                if (cars.Find(c => c.Model == carModel).CanTheCarTravelDistance(amountOfKm))
                {
                    cars.Find(c => c.Model == carModel).CalculateTheChanges(amountOfKm);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                    continue;
                }
                // Continue....
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }   
        }
    }
}
