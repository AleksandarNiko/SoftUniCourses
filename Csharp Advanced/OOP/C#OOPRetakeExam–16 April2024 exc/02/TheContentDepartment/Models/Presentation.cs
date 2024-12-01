namespace TheContentDepartment.Models
{
    public class Presentation : Resource
    {
        private const int priority = 3;
        public Presentation(string name, string creator) 
            : base(name, creator, priority)
        {
        }
    }
}
