using System.Reflection.PortableExecutable;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();

        }
    }
}
