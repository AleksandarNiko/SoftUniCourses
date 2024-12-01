namespace CarManufacturer
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "Audi";
            car.Model = "A90";
            car.Year = 1999;
            car.FuelQuantity = 200;
            car.FuelConsumption = 100;
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
