using System.Text;
using System.Threading.Channels;

namespace _03._TakeSkip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            List<string> decryptedMessage=new List<string>();
            List<int> numbers=new List<int>();
            List<string> nonNumbers = new List<string>();
            List<int>takeList=new List<int>();
            List<int> skipList =new List<int>();
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (char.IsDigit(encryptedMessage[i]))
                {
                    numbers.Add(int.Parse(encryptedMessage[i].ToString()));
                }
                else
                {
                    nonNumbers.Add(encryptedMessage[i].ToString());
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i %2==0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }
            int indexForSkip = 0;
            StringBuilder result = new StringBuilder(); 
            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumbers);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                result.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
            

        }
    }
}