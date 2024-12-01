using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path)
            : base(name, path)
        {
            if (path != "Python" && path != "CSharp" && path != "Java" && path != "JavaScript")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
        }
    }
}
