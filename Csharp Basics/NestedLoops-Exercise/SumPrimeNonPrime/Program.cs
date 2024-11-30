using System;
using System.Diagnostics.SymbolStore;

namespace SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int primeSum = 0;
            int nonPrimeSum = 0;
            while (input != "stop")
            {
                int n = int.Parse(input);
                if (n < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    bool isPrime = true;
                    double sqrt = Math.Sqrt(n);
                    for (int i = 2; i <= sqrt; i++)
                    {
                        if (n % i == 0)
                        {
                            isPrime = false; break;
                        }
                    }
                    if (isPrime)
                    {
                        primeSum += n; 
                    }
                    else
                    {
                        nonPrimeSum += n;
                    }
                }
                    input = Console.ReadLine();
                }
                Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
                Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
            }
        }
    }

