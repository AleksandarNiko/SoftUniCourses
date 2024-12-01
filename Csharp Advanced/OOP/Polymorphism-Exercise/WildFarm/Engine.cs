using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Engine:IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<IAnimal> AnimalsList;
        private FoodCreator foodCreator;

        private Engine()
        {
            this.AnimalsList = new List<IAnimal>();
            this.foodCreator = new FoodCreator();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] lineToken = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = null;
                string type = lineToken[0];
                if (type == "Owl")
                {
                    animal = new Owl(lineToken[1], double.Parse(lineToken[2]), double.Parse(lineToken[3]));
                }

                else if (type == "Hen")
                {
                    animal = new Hen(lineToken[1], double.Parse(lineToken[2]), double.Parse(lineToken[3]));
                }

                else if (type == "Mouse")
                {
                    animal = new Mouse(lineToken[1], double.Parse(lineToken[2]), lineToken[3]);
                }

                else if (type == "Cat")
                {
                    animal = new Cat(lineToken[1], double.Parse(lineToken[2]), lineToken[3], lineToken[4]);
                }

                else if (type == "Dog")
                {
                    animal = new Dog(lineToken[1], double.Parse(lineToken[2]), lineToken[3]);
                }

                else if (type == "Tiger")
                {
                    animal = new Tiger(lineToken[1], double.Parse(lineToken[2]), lineToken[3], lineToken[4]);
                }

                this.writer.WriteLine(animal.ProduceSound());
                try
                {
                    this.AnimalsList.Add(animal);
                    string[] foodArguments = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string foodType = foodArguments[0];
                    int quantity = int.Parse(foodArguments[1]);
                    Food food = foodCreator.Create(foodType, quantity);
                    animal.FeedIt(food);
                }

                catch (ArgumentException exception)
                {
                    this.writer.WriteLine(exception.Message);
                }
            }

            foreach (var animal in AnimalsList)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
