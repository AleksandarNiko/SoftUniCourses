using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;
        private List<string> members;

        public string Name 
        { 
            get => name; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format (ExceptionMessages.NameNullOrWhiteSpace));
                }
                name = value;
            }
         }

        public string Path {  get; protected set; }

        public IReadOnlyCollection<string> InProgress { get => members; private set => members.AsReadOnly(); }

        public void FinishTask(string resourceName)
        {
            members.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            members.Add(resourceName);
        }

        public TeamMember (string name, string path)
        {
            Name=name;
            Path=path;
        }
    }
}
