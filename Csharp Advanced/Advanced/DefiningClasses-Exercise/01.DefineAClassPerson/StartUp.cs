namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person gosho = new Person();
            gosho.Name = "gosho";
            gosho.Age = 30;

            Console.WriteLine($"{gosho.Name}: {gosho.Age}");
        }
    }
}
