namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenlightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> carsToPass = new Queue<string>();
            Stack<string> passedCars = new Stack<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    carsToPass.Enqueue(input);
                }
                else
                {
                    int greenLight = greenlightDuration;
                    int freePass = freeWindowDuration;

                    int counter = carsToPass.Count;

                    for (int i = 0; i < counter; i++)
                    {
                        if (greenLight >= carsToPass.Peek().Length && carsToPass.Any())
                        {
                            greenLight -= carsToPass.Peek().Length;
                            passedCars.Push(carsToPass.Dequeue());
                        }
                        else if (greenLight < carsToPass.Peek().Length && carsToPass.Any())
                        {
                            int timeLeft = greenLight + freePass;

                            if (greenLight <= 0)
                            {
                                continue;
                            }
                            else if (timeLeft > 0 && timeLeft >= carsToPass.Peek().Length)
                            {
                                string car = carsToPass.Peek();
                                timeLeft -= car.Length;
                                passedCars.Push(carsToPass.Dequeue());
                                greenLight = 0;
                                freePass = 0;
                            }
                            else if (timeLeft > 0 && timeLeft < carsToPass.Peek().Length)
                            {
                                string car = carsToPass.Peek();

                                Console.WriteLine("A crash happened!");
                                int hit = timeLeft;
                                Console.WriteLine($"{car} was hit at {car[hit]}.");
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars.Count} total cars passed the crossroads.");
        }
    }
}
