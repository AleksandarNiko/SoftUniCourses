using System.IO;
namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader= new StreamReader(inputFilePath))
            {
                int count = 0;

                string line=reader.ReadLine();

                using (StreamWriter writer=new StreamWriter(outputFilePath))
                {
                    while (line != null)
                    {
                        if (count % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        count++;
                        line= reader.ReadLine();
                    }
                }
            }
        }
    }
}
