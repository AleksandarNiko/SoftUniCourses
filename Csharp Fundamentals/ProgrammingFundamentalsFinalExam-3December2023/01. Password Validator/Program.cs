using System;
using System.Text.RegularExpressions;

namespace _01._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input ;
            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] lineToken = input.Split();
                string command = lineToken[0];

                if (command == "Make")
                {
                    string caseType = lineToken[1];
                    int index = int.Parse(lineToken[2]);

                    if (caseType == "Upper")
                    {
                        password = ReplaceCharAtIndex(password, index, char.ToUpper(password[index]));
                    }
                    else if (caseType == "Lower")
                    {
                        password = ReplaceCharAtIndex(password, index, char.ToLower(password[index]));
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(lineToken[1]);
                    char character = char.Parse(lineToken[2]);

                    if (index >= 0 && index <= password.Length)
                    {
                        password = password.Insert(index, character.ToString());
                    }
                }
                else if (command == "Replace")
                {
                    char oldChar = char.Parse(lineToken[1]);
                    int value = int.Parse(lineToken[2]);

                    if (password.Contains(oldChar.ToString()))
                    {
                        char newChar = (char)(oldChar + value);
                        password = password.Replace(oldChar, newChar);
                    }
                }
                else if (command == "Validation")
                {
                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }
                    else if (!IsAlphaNumericUnderscore(password))
                    {
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }
                    else if (!HasUppercaseLetter(password))
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }
                    else if (!HasLowercaseLetter(password))
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }
                    else if (!HasDigit(password))
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }
            }

            Console.WriteLine(password);
        }

        static string ReplaceCharAtIndex(string str, int index, char newChar)
        {
            char[] charArray = str.ToCharArray();
            charArray[index] = newChar;
            return new string(charArray);
        }

        static bool IsAlphaNumericUnderscore(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    return false;
                }
            }
            return true;
        }

        static bool HasUppercaseLetter(string str)
        {
            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        static bool HasLowercaseLetter(string str)
        {
            foreach (char c in str)
            {
                if (char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        static bool HasDigit(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
    }


/*
123456789
Insert 3 R
Replace 5 15
Validation
Make Lower 3
Complete
 */