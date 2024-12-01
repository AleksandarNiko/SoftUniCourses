namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < countOfCars; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = lineToken[0];
                double fuelAmount= double.Parse(lineToken[1]);
                double fuelConsumptionPerKm= double.Parse(lineToken[2]);

                Car car= new Car()
                {
                    Model= model,
                    FuelAmount= fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionPerKm
                };
                cars.Add(car);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info= input.Split();
                string carModel= info[1];
                double distance= double.Parse(info[2]);

                Car carForDriving = cars
                    .Where(x => x.Model == carModel)
                    .ToList()
                    .First();

                carForDriving.CanMoveDistance(carModel, distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
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