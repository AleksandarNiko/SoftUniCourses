using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieName=Console.ReadLine();
            int totalTicketCount = 0;
            int studentTicketCount = 0;
            int standardTicketCount = 0;
            int kidsTicketCount = 0;

            while (movieName!="Finish")
            {
                int capacity=int.Parse(Console.ReadLine());
                int soldTickets = 0;
                string ticketType=Console.ReadLine();
                while (ticketType != "End")
                {
                    if (ticketType == "student")
                    {
                        studentTicketCount++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTicketCount++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidsTicketCount++;
                    }
                    soldTickets++;
                    if (soldTickets == capacity)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }
                totalTicketCount += soldTickets;
                double fillPercentage=100.0*soldTickets/capacity;
                Console.WriteLine($"{movieName} - {fillPercentage:f2}% full.");

                movieName = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTicketCount}");
            Console.WriteLine($"{100.0*studentTicketCount/totalTicketCount:f2}% student tickets.");
            Console.WriteLine($"{100.0*standardTicketCount/totalTicketCount:f2}% standard tickets.");
            Console.WriteLine($"{100.0*kidsTicketCount/totalTicketCount:f2}% kids tickets.");
        }
    }
}
