using System.ComponentModel;

namespace VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int numOfCommands=int.Parse(Console.ReadLine());

            Car car = new Car(double.Parse(carInfo[1]),
                double.Parse(carInfo[2]),
                double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]),
                double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));
            Bus bus=new Bus(double.Parse(busInfo[1]),
                double.Parse(busInfo[2]),
                double.Parse(busInfo[3]));

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = lineToken[0];
                string type = lineToken[1];

                try
                {
                    switch (command)
                    {
                        case "Drive":
                            double distance = double.Parse(lineToken[2]);
                            if (type == "Car")
                            {
                                car.Drive(distance);
                            }
                            else if (type == "Truck")
                            {
                                truck.Drive(distance);
                            }
                            else if (type == "Bus")
                            {
                                bus.Drive(distance);
                            }
                            break;
                        case "Refuel":
                            double liters = double.Parse(lineToken[2]);
                            if (type == "Car")
                            {
                                car.Refuel(liters);
                            }
                            else if (type == "Truck")
                            {
                                truck.Refuel(liters);
                            }
                            else if (type == "Bus")
                            {
                                bus.Refuel(liters);
                            }
                            break;
                        case "DriveEmpty":
                            double busDistance = double.Parse(lineToken[2]);
                            bus.DriveEmpty(busDistance);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
/*
Car 30 0,04 70
Truck 100 0,5 300
Bus 40 0,3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
 */