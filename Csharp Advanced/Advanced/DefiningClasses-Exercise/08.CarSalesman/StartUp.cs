namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < numOfEngines; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (lineToken.Length == 2)
                {
                    string model = lineToken[0];
                    int power = int.Parse(lineToken[1]);
                    Engine newEngine = new Engine(model, power);
                    engines.Add(newEngine);
                }

                else if (lineToken.Length == 3)
                {
                    string model = lineToken[0];
                    int power = int.Parse(lineToken[1]);
                    string thirdParam = lineToken[2]; //displacement or efficiency
                    if (int.TryParse(thirdParam, out int displacement))
                    {
                        Engine newEngine = new Engine(model, power, displacement);
                        engines.Add(newEngine);
                    }

                    else
                    {
                        string efficiency = lineToken[2];
                        Engine newEngine = new Engine(model, power, efficiency);
                        engines.Add(newEngine);
                    }
                }

                else if (lineToken.Length == 4)
                {
                    string model = lineToken[0];
                    int power = int.Parse(lineToken[1]);
                    int displacement = int.Parse(lineToken[2]);
                    string efficiency = lineToken[3];
                    Engine newEngine = new Engine(model, power, displacement, efficiency);
                    engines.Add(newEngine);
                }
            }

            int numOfCars=int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (carInfo.Length == 2)
                {
                    string model = carInfo[0];
                    string engineModel = carInfo[1];
                    if ( engines.Exists(e => e.Model == engineModel))
                    {
                        Engine findEngine =  engines.Where(e => e.Model == engineModel).First();
                        Car newCar = new Car(model, findEngine);
                        cars.Add(newCar);
                    }
                }

                else if (carInfo.Length == 3)
                {
                    string model = carInfo[0];
                    string engineModel = carInfo[1];
                    string thirdParam = carInfo[2]; // weight or color
                    if ( engines.Any(e => e.Model == engineModel))
                    {
                        Engine findedEngine =  engines.Where(e => e.Model == engineModel).First();
                        if (int.TryParse(thirdParam, out int weight))
                        {
                            var newCar = new Car(model, findedEngine, weight);
                            cars.Add(newCar);
                        }

                        else
                        {
                            string color = carInfo[2];
                            var newCar = new Car(model, findedEngine, color);
                            cars.Add(newCar);
                        }
                    }
                }

                else if (carInfo.Length == 4)
                {
                    string model = carInfo[0];
                    string engineModel = carInfo[1];
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    if ( engines.Any(e => e.Model == engineModel))
                    {
                        Engine findedEngine =  engines.Where(e => e.Model == engineModel).First();
                        var newCar = new Car(model, findedEngine, weight, color);
                        cars.Add(newCar);
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
/*
4
DSL-10 280 B
V7-55 200 35
DSL-13 305 55 A+
V7-54 190 30 D
4
FordMondeo DSL-13 Purple
VolkswagenPolo V7-54 1200 Yellow
VolkswagenPassat DSL-10 1375 Blue
FordFusion DSL-13
 */
