using System.Xml.Linq;

namespace _04._Snowwhite
{
    class Dwarf
    {
        public  string DwarfName { get; set; }
        public string DwarfHatColor { get; set;}
        public  int DwarfPhysics { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();
            string input;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                var lineToken = input.Split(" <:> ");
                string dwarfName = lineToken[0];
                string dwarfHatColor = lineToken[1];
                int dwarfPhysics = int.Parse(lineToken[2]);
                Dwarf dwarf = new Dwarf
                {
                    DwarfName = dwarfName,
                    DwarfHatColor = dwarfHatColor,
                    DwarfPhysics = dwarfPhysics
                };
                dwarfs.Add(dwarf);

            }
            List<Dwarf> sortedDwarfs = dwarfs
            .OrderByDescending(d => d.DwarfPhysics)
            .ThenByDescending(d => dwarfs.Count(dw => dw.DwarfHatColor == d.DwarfHatColor))
            .ToList();

            foreach (Dwarf dwarf in sortedDwarfs)
            {
                Console.WriteLine($"({dwarf.DwarfHatColor}) {dwarf.DwarfName} <-> {dwarf.DwarfPhysics}");
            }
        }
    }
}
/*
Peter <:> Red <:> 2000
Tony <:> Blue <:> 1000
George <:> Green <:> 1000
Sam <:> Yellow <:> 4500
John <:> Black <:> 1000
Once upon a time
*/
