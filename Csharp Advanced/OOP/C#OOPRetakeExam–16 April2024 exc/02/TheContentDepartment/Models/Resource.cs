using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;
        private string creator;
        private readonly int priority;
        private bool isTested;
        private bool isApproved;

        public Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator = creator;
            isTested = false;
            isApproved = false;
            this.priority = priority;
        }

        public string Name 
        { 
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            } 
        }

        public string Creator 
        { 
            get => creator; 
            private set
            {
                creator = value;
            }
        }
        public int Priority => priority;

        public bool IsTested => isTested;
        public bool IsApproved => isApproved;

        public void Test()
        {
            isTested = !isTested;
        }

        public void Approve()
        {
            isApproved = true;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}), Created By: {Creator}";
        }
    }
}
