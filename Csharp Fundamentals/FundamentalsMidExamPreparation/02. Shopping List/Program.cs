namespace _02._Shopping_List
{
    internal class Program
    {/*Milk!Pepper!Salt!Water!Banana
Urgent Salt
Unnecessary Grapes 
Correct Pepper Onion
Rearrange Grapes
Correct Tomatoes Potatoes
Go Shopping!
*/
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("!").ToList();
            string input = "";

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] lineToken = input.Split(" ");
                string command = lineToken[0];
                switch (command)
                {
                    case "Urgent":
                        string item = lineToken[1];
                        if (!list.Contains(item))
                        {
                            list.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        string unnecenssaryItem = lineToken[1];
                        if (list.Contains(unnecenssaryItem))
                        {
                            list.Remove(unnecenssaryItem);
                        }
                        break;
                    case "Correct":
                        string oldItem = lineToken[1];
                        string newItem = lineToken[2];
                        if (list.Contains(oldItem))
                        {
                            int index = list.IndexOf(oldItem);
                            list.Insert(index, newItem);
                            list.Remove(oldItem);
                        }
                        break;
                    case "Rearrange":
                        string rearrangeItem = lineToken[1];
                        if (list.Contains(rearrangeItem))
                        {
                            list.Remove(rearrangeItem);
                            list.Add(rearrangeItem);
                        }
                        break;
                }
            }
                Console.WriteLine(string.Join(", ", list));
            

        }
    }
}