namespace CarManufacturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string make=Console.ReadLine();
            string model=Console .ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity=int.Parse(Console.ReadLine());
            double fuelConsumption=int.Parse(Console.ReadLine());
            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            Console.WriteLine(secondCar);
        }
    }
}
