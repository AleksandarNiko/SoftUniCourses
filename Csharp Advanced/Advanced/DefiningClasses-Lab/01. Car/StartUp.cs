namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car =new Car();
            car.Make = "Audi";
            car.Model = "A90";
            car.Year = 1999;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year} ");
        }
    }

}
