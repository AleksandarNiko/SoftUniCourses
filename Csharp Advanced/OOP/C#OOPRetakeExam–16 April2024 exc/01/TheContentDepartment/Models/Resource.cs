using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;
        private bool isTested=false;
        private bool isApproved=false;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhiteSpace));
                }
                name = value;
            }
        }

        public string Creator {  get; private set; }

        public int Priority {  get; private set; }

        public bool IsTested { get => isTested; private set => isTested = value; }

        public bool IsApproved { get => isApproved; private set => isApproved = value; }

        public void Approve()
        {
            IsApproved = true;
        }

        public void Test()
        {
            IsTested = true;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}), Created By: {Creator}";
        }

        public Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator=creator; 
            Priority=priority;
        }
    }
}
