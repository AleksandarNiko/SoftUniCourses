using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EvenLines 
{ 
    using System; 
    public class EvenLines 
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] charsArray = new char[] { '-', ',', '.', '!', '?' };
            int lines = 0;
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line=reader.ReadLine();
                    if (lines % 2 == 0)
                    {
                        foreach (char c in line)
                        {
                            if (charsArray.Contains(c))
                            {
                                line = line.Replace(c, '@');
                            }
                        }

                        var temp = line.Split().Reverse().ToArray();
                        sb.AppendLine(string.Join(" ",temp));
                    }

                    lines++;
                }
            }
            

            return sb.ToString();
        }
    }
}
