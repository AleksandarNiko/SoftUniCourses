using System.Collections.Generic;

namespace _03._Speed_Racing
{
    class Car
    {
        public Car(string model, decimal fuel, decimal fuelPerKm)
        {
            Model = model;
            Fuel = fuel;
            FuelPerKm = fuelPerKm;
            Distance = 0m;
        }

        public string Model { get; set; }
        public decimal Fuel { get; set; }
        public decimal FuelPerKm { get; set; }
        public decimal Distance { get; set; }

        public override string ToString()
        {
            return $"{Model} {Fuel:f2} {Distance}";
        }

        public void Move(decimal km)
        {
            if (FuelPerKm * km <= Fuel)
            {
                Fuel -= FuelPerKm * km;
                Distance += km;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string model = lineToken[0];
                decimal fuelAmount = decimal.Parse(lineToken[1]);
                decimal fuelPerKm = decimal.Parse(lineToken[2]);
                cars.Add(new Car(model, fuelAmount, fuelPerKm));
            }


            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] lineToken = input.Split();
                string command = lineToken[0];
                string model = lineToken[1];
                decimal distance = decimal.Parse(lineToken[2]);
                cars.Find(x => x.Model == model).Move(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
            
        }

    }
}


/*
2
AudiA4 23 0,3
BMW-M2 45 0,42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End
 */