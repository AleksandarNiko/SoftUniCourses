using System;

namespace OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bookName=Console.ReadLine();
            int counter = 0;
            string nextBook=Console.ReadLine();
            while (nextBook != "No More Books" && nextBook != bookName)
            {
                counter++;
                nextBook = Console.ReadLine();
            }
                 if (nextBook==bookName) {
                    Console.WriteLine($"You checked {counter} books and found it.");
                
                }
                else 
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books."); 
                }
            }
        }
    }

