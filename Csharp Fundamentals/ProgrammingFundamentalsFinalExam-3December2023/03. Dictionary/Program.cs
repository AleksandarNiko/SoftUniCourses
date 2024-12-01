namespace _03._Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> notebook = new Dictionary<string, List<string>>();


            string[] inputWords = Console.ReadLine().Split(" | ");
            string[] testingWords = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();
            foreach (string inputWord in inputWords)
            {
                string[] wordAndDefinition = inputWord.Split(": ");
                string word = wordAndDefinition[0];
                string definition = wordAndDefinition[1];

                if (notebook.ContainsKey(word))
                {
          
                    notebook[word].Add(definition);
                }
                else
                {
                    List<string> definitions = new List<string>();
                    definitions.Add(definition);
                    notebook.Add(word, definitions);
                }
            }
            

            if (command == "Test")
            {
                foreach (string word in testingWords)
                {
                    if (notebook.ContainsKey(word))
                    {
                        Console.WriteLine(word + ":");
                        foreach (string definition in notebook[word])
                        {
                            Console.WriteLine("-" + definition);
                        }
                    }
                }
            }
            else if (command == "Hand Over")
            {
                Console.WriteLine(string.Join(" ", notebook.Keys));
            }
        }
    }
    }
/*
programmer: an animal, which turns coffee into code | developer: a magician
fish | domino
Hand Over
 */