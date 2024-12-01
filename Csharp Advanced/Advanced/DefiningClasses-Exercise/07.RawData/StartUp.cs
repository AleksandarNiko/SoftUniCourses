namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < numOfCars; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model=lineToken[0];
                int speed = int.Parse(lineToken[1]);
                int power = int.Parse(lineToken[2]);
                int weight = int.Parse(lineToken[3]);
                string type=lineToken[4];
                double tire1Pressure = double.Parse(lineToken[5]);
                int tire1Age = int.Parse(lineToken[6]);
                double tire2Pressure = double.Parse(lineToken[7]);
                int tire2Age = int.Parse(lineToken[8]);
                double tire3Pressure = double.Parse(lineToken[9]);
                int tire3Age = int.Parse(lineToken[10]);
                double tire4Pressure = double.Parse(lineToken[11]);
                int tire4Age = int.Parse(lineToken[12]);

                Car car = new Car(model, speed, power, weight, type, tire1Pressure, tire1Age, tire2Pressure, tire2Age,
                    tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                cars.Add(car);
            }

            string command=Console.ReadLine();
            List<string> filteredCars=new List<string>();
            if (command == "fragile")
            {
                filteredCars = cars.Where(c => c.Cargo.Type == "fragile" &&
                                               c.Tires.Any(t => t.Pressure < 1))
                    .Select(c => c.Model).ToList();

                Console.WriteLine(string.Join("\n", filteredCars));
            }
            else if (command == "flammable")
            {
                filteredCars= cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .Select(c => c.Model) .ToList();

                Console.WriteLine(string.Join("\n", filteredCars));
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
/*
2
ChevroletAstro 200 180 1000 fragile 1,3 1 1,5 2 1,4 2 1,7 4
Citroen2CV 190 165 1200 fragile 0,9 3 0,85 2 0,95 2 1,1 1
fragile
 */
