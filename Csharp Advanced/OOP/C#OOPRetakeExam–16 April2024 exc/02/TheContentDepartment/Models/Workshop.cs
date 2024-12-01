namespace TheContentDepartment.Models
{
    public class Workshop : Resource
    {
        private const int priority = 2;
        public Workshop(string name, string creator) 
            : base(name, creator, priority)
        {
        }
    }
}
