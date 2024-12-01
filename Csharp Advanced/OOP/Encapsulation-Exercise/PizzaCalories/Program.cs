namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();

                string pizzaName = pizzaInfo[1];

                Dough dough = new(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

                Pizza pizza = new(pizzaName, dough);

                while (true)
                {
                    string toppingsInput = Console.ReadLine();

                    if (toppingsInput == "END")
                    {
                        break;
                    }

                    string[] toppingsInfo = toppingsInput.Split();

                    Topping topping = new(toppingsInfo[1], double.Parse(toppingsInfo[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
