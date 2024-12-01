using System.Runtime.Serialization;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Console.ReadLine();
            string fileName = "";
            string fileExt = "";
            int lastSeparatorIndex = file.LastIndexOf('\\');
            int extensionIndex = file.LastIndexOf('.');

            if (lastSeparatorIndex != -1 && extensionIndex != -1 && extensionIndex > lastSeparatorIndex)
            {
                fileName = file.Substring(lastSeparatorIndex + 1, extensionIndex - lastSeparatorIndex - 1);
                fileExt = file.Substring(extensionIndex + 1);
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExt}");

            //Another way:
           // Console.WriteLine($"File name: {Path.GetFileNameWithoutExtension(file)}");
            //Console.WriteLine($"File extension: {Path.GetExtension(file).Replace(".","")}");

        }
    }
}