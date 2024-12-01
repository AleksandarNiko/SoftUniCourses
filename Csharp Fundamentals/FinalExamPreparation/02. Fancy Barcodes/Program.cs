using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodeCount = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z][a-zA-Z\d]{4,}[A-Z]@#+";
            for (int i = 0; i < barcodeCount; i++)
            {
                string barcode=Console.ReadLine();
                Match matches= Regex.Match(barcode, pattern);
                if (matches.Success)
                {
                    char[] digits = barcode.Where(x => char.IsDigit(x)).ToArray();

                    if (digits.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {string.Join("", digits)}");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
                }
            }
        }
  }
/*
3
@#FreshFisH@#
@###Brea0D@###
@##Che4s6E@##
*/