namespace _04._Raw_Data
{
    public class Car
    {
        public Car(string Mdl, Engine engine, Cargo cargo)
        {
            Model = Mdl;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }

    public class Engine
    {
        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }

    public class Cargo
    {
        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string model = lineToken[0];
                int engineSpeed = int.Parse(lineToken[1]);
                int enginePower = int.Parse(lineToken[2]);
                int cargoWeight = int.Parse(lineToken[3]);
                string cargoType = lineToken[4];
                Engine engine = new Engine()
                {
                    EngineSpeed = engineSpeed,
                    EnginePower = enginePower
                };
                Cargo cargo = new Cargo()
                {
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                };

                Car car = new Car(model, engine, cargo);

                cars.Add(car);
            }

            string command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    foreach (var car in cars.Where(x => x.Cargo.CargoType == "fragile" &&
                                                        x.Cargo.CargoWeight < 1000))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                    break;

                case "flamable":
                    foreach (var car in cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250))
                    {
                        Console.WriteLine($"{car.Model}");
                    }
                    break;
            }
        }
    }
}
