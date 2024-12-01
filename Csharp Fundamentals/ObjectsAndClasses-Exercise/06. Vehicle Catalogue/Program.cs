using System.Security.Principal;
using System.Xml.Linq;

namespace _06._Vehicle_Catalogue
{
   enum Type
    {
        Car,Truck
    }
    class Vehicle
    {
        public  Type  Type { get; set; }
        public  string  Model { get; set; }
        public  string Color { get; set; }
        public  decimal Horsepower { get; set; }
        public Vehicle(string type, string model, string color, decimal horsepower)
        {
            Type = type == "car" ? Type.Car : Type.Truck;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
        public override string ToString()
        {
            return $"Type: {Type}\n" +
                   $"Model: {Model}\n" +
                   $"Color: {Color}\n" +
                   $"Horsepower: {Horsepower}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Vehicle> vehicles = new List<Vehicle>();
            string input;
            while((input=Console.ReadLine())!="End") 
            {
                string[] lineToken = input.Split();
                string typeVehicle = lineToken[0];
                string model = lineToken[1];
                string color = lineToken[2];
                decimal horsepower = decimal.Parse(lineToken[3]);
                Vehicle vehicle = new Vehicle(typeVehicle, model, color, horsepower);
                vehicles.Add(vehicle);
            }
           while((input=Console.ReadLine())!= "Close the Catalogue")
            {
                string vehModel=input;
                Vehicle findVehicle=vehicles.FirstOrDefault(v=> v.Model == vehModel);
                if(findVehicle!=null)
                {
                    Console.WriteLine(findVehicle);
                }
            }
            decimal averageHP = vehicles
            .Where(vehicle => vehicle.Type == Type.Car)
            .Select(vehicle => vehicle.Horsepower)
            .DefaultIfEmpty()
            .Average();
            Console.WriteLine($"Cars have average horsepower of: {averageHP:f2}.");

            averageHP = vehicles
            .Where(vehicle => vehicle.Type == Type.Truck)
            .Select(vehicle => vehicle.Horsepower)
            .DefaultIfEmpty()
            .Average();
            Console.WriteLine($"Trucks have average horsepower of: {averageHP:f2}.");
        }
    }
}
/*
truck Man red 200
truck Mercedes blue 300
car Ford green 120
car Ferrari red 550
car Lamborghini orange 570
End
Ferrari
Ford
Man
Close the Catalogue
*/