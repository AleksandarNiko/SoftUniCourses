namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isInclusive = CheckLength(password);
            bool isLettersAndDigits = CheckContain(password);
            bool twoDigits = CheckDigits(password);

            static bool CheckLength(string password)
            {
                if (password.Length >= 6 && password.Length <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            static bool CheckContain(string password)
            {
                foreach (char symbol in password)
                {
                    if (symbol >= 65 && symbol <= 90 ||
                    symbol >= 97 && symbol <= 122 ||
                    symbol >= 48 && symbol <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool CheckDigits(string password)
            {
                int counter = 0;

                foreach (char symbol in password)
                {
                    if (symbol >= 48 && symbol <= 57)
                    {
                        counter++;
                    }
                }

                if (counter >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (!isInclusive)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isLettersAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!twoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isInclusive && isLettersAndDigits && twoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
