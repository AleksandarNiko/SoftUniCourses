namespace TheContentDepartment.Models
{
    public class Exam : Resource
    {
        private const int priority = 1;

        public Exam(string name, string creator) 
            : base(name, creator, priority)
        {           

        }
    }
}
