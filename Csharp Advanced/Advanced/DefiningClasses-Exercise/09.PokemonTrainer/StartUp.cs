namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Trainer> trainers = new List<Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                //{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] lineToken = input.Split();
                string trainerName = lineToken[0];
                string pokemonName = lineToken[1];
                string pokemonElement = lineToken[2];
                int pokemonHealth = int.Parse(lineToken[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer currentTrainer = new Trainer();

                bool checkTrainer = trainers.Any(n => n.Name == trainerName);

                if (!checkTrainer)
                {
                    currentTrainer.Name = trainerName;
                    currentTrainer.pokemons.Add(pokemon);
                    trainers.Add(currentTrainer);
                }
                else
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Name == trainerName)
                        {
                            trainer.pokemons.Add(pokemon);
                        }
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Fire")
                {
                    attacking(trainers, command);
                }
                else if (command == "Water")
                {
                    attacking(trainers, command);
                }
                else if (command == "Electricity")
                {
                    attacking(trainers, command);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t=>t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.pokemons.Count}");
            }
             static void attacking(List<Trainer> trainers, string command)
            {
                foreach (var trainer in trainers)
                {
                    bool isTrainerHavingElement = false;
                    foreach (var pokemon in trainer.pokemons)
                    {
                        if (command == pokemon.Element)
                        {
                            trainer.NumberOfBadges++;
                            isTrainerHavingElement = true;
                            break;
                        }
                    }
                    if (isTrainerHavingElement == false)
                    {
                        trainer.pokemons.ForEach(pokemon => pokemon.Health -= 10);
                        trainer.pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                    }
                }

            }
        }
    }
}
/*
Peter Charizard Fire 100
George Squirtle Water 38
Peter Pikachu Electricity 10
Tournament
Fire
Electricity
End
 */