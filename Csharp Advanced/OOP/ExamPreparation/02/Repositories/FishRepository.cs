namespace NauticalCatchChallenge.Repositories
{
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories.Contracts;
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> fish;

        public FishRepository()
        {
            fish = new List<IFish>();
        }
        public IReadOnlyCollection<IFish> Models => fish;

        public void AddModel(IFish model)
        {
            this.fish.Add(model);
        }

        public IFish GetModel(string name) => this.Models.FirstOrDefault(x => x.Name == name);
    }
}
