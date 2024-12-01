using System.Reflection;

List<Car> cars = new List<Car>();
List<Truck> trucks = new List<Truck>();
string input;
while ((input = Console.ReadLine()) != "end")
{
    string[] lineToken = input.Split("/");
    string type = lineToken[0];
    string brand = lineToken[1];
    string model = lineToken[2];

    if (type == "Car")
    {
        Car car = new Car();
        {
            car.Brand = brand;
            car.Model = model;
            car.HorsePower = int.Parse(lineToken[3]); ;
        }
        cars.Add(car);
    }
    else
    {
        Truck truck = new Truck();
        {
            truck.Brand = brand;
            truck.Model = model;
            truck.Weight = int.Parse(lineToken[3]); ;
        }
        trucks.Add(truck);
    }
}
if (cars.Count > 0)
{
    Console.WriteLine("Cars:");
    foreach (Car car in cars.OrderBy(x => x.Brand).ToList())
    {
        Console.WriteLine($" {car.Brand}: {car.Model} - {car.HorsePower}hp");
    }
}
if (trucks.Count > 0)
{
    Console.WriteLine("Trucks:");
    foreach (Truck truck in trucks.OrderBy(x => x.Brand).ToList())
    {
        Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
    }
}
class Truck
{
    public  string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
}
class Car
{
    public string  Brand { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
}







