using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
