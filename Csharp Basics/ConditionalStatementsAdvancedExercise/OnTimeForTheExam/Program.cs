using System;
using System.Diagnostics.Tracing;

namespace OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minutesExam = int.Parse(Console.ReadLine());
            int hoursArrival = int.Parse(Console.ReadLine());
            int minutesArrival=int.Parse(Console.ReadLine());
 
            int examTime = hourExam * 60 + minutesExam;
            int arrivalTime = hoursArrival * 60 + minutesArrival;
            int diff = examTime - arrivalTime;
            string keyword = "";
            string verdict = "";
            if (diff < 0)
            {
                verdict = "Late";
                keyword = "after";
            }
            else
            {
                keyword = "before";
                if (diff <= 30) { verdict = "On time"; }
                else { verdict = "Early"; }
            }
            string formattedtime = "";
            int absoluteDiff = Math.Abs(diff);
            if (absoluteDiff < 60)
            {
                formattedtime = $"{absoluteDiff} minutes";
            }
            else
            {
                int diffHours = absoluteDiff / 60;
                int diffMinutes = absoluteDiff % 60;
                if (diffMinutes < 10)
                {
                    formattedtime = $"{diffHours}:0{diffMinutes} hours";
                }
                else
                {
                    formattedtime = $"{diffHours}:{diffMinutes} hours";
                }
            }
            Console.WriteLine(verdict);
            if (diff != 0)
            {
                Console.WriteLine($"{formattedtime} {keyword} the start");
            
            }
        }
    }
}
