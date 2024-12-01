using System.Data;
using System.Text;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int numOfCommands = int.Parse(Console.ReadLine());

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

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
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            
        }
    }
}
/*
Car 15 0,3
Truck 100 0,9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10
 */