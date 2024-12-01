namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {

            this.NumberOfBadges = 0;
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }

        public List<Pokemon> pokemons = new List<Pokemon>();
    }
}
