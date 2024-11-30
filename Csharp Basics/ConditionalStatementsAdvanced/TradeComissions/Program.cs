using System;

namespace TradeComissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city=Console.ReadLine();
            double sales=double.Parse(Console.ReadLine());
            double comission = 0.0;
            if (sales>=0 && sales <= 500)
            {
                switch (city)
                {
                    case "Sofia": comission = 0.05; break;
                        case "Varna": comission=0.045; break;
                        case "Plovdiv":comission = 0.055;break;
              
                }
            }
            if (sales >500 && sales <= 1000)
            {
                switch (city)
                {
                    case "Sofia": comission = 0.07; break;
                    case "Varna": comission = 0.075; break;
                    case "Plovdiv": comission = 0.08; break;
       
                }
            }
            if (sales > 1000 && sales <= 10000)
            {
                switch (city)
                {
                    case "Sofia": comission = 0.08; break;
                    case "Varna": comission = 0.1; break;
                    case "Plovdiv": comission = 0.12; break;
      
                }
            }
            if (sales >10000)
            {
                switch (city)
                {
                    case "Sofia": comission = 0.12; break;
                    case "Varna": comission = 0.13; break;
                    case "Plovdiv": comission = 0.145; break;

                    default:Console.WriteLine("error");
                        break;
                }
            }
            double result = comission * sales;
            if (city !="Sofia"&&city!="Varna"&&city!="Plovdiv") { Console.WriteLine("error"); }
            else if (sales <0){ Console.WriteLine("error"); }
     
            else { Console.WriteLine($"{result:F2}"); }
           
        }
    }
}
