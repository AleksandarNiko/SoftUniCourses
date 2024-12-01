namespace NauticalCatchChallenge.Repositories
{
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories.Contracts;
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> divers;

        public DiverRepository()
        {
            divers = new List<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models => divers;

        public void AddModel(IDiver model)
        {
            this.divers.Add(model);
        }

        public IDiver GetModel(string name) => Models.FirstOrDefault(x => x.Name == name);
    }
}
