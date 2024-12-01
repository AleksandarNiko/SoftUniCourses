namespace _05._Courses
{
    class Cours
    {
        public Cours(string coursName) 
        {
            Name = coursName;
            Students = new List<string>();
        }

        public  string Name { get; set; }
        public  List <string> Students { get; set; }
        public override string ToString()
        {
            string result = $"{Name}: {Students.Count}\n";

            for (int i = 0; i < Students.Count; i++)
            {
                result += $"-- {Students[i]}\n";
            }

            return result.Trim();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Cours> cours = new Dictionary<string,Cours>();
            string input;
            while ((input = Console.ReadLine())!="end")
            {
                string[] lineToken = input.Split(" : ");
                string coursName = lineToken[0];
                string studentName = lineToken[1];
                
                if(!cours.ContainsKey( coursName ))
                {
                    Cours newCours = new Cours(coursName);
                    cours.Add(newCours.Name,newCours);
                }
                cours[coursName].Students.Add(studentName); 

            }
            foreach (var cour in cours)
            {
                
                Console.WriteLine(cour.Value);
            }
        }
    }
}
/*
Programming Fundamentals : John Smith
Programming Fundamentals : Linda Johnson
JS Core : Will Wilson
Java Advanced : Harrison White
end
*/