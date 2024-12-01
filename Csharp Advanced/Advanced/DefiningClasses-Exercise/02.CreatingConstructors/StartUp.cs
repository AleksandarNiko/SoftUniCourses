namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name=Console.ReadLine();
            int age=int.Parse(Console.ReadLine());
            Person thridPerson=new Person( name,  age);
            Console.WriteLine($"{thridPerson.Name}: {thridPerson.Age}");
        }
    }
}
