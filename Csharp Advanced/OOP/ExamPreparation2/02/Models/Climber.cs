using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber:IClimber
    {
        private string _name;
        private int stamina;
        private HashSet<string> conqueredPeaks;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value > 10)
                {
                    value= 10;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                stamina = value;
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks
        {
            get
            {
                return conqueredPeaks;
            }
        }

        public void Climb(IPeak peak)
        {
            conqueredPeaks.Add(peak.Name);  

            if (peak.DifficultyLevel == "Extreme")
            {
                 Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                 Stamina-= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                 Stamina -= 2;
            }
        }

        public Climber(string name, int stamina)
        {
            Name=name;
            Stamina = stamina;
            conqueredPeaks=new HashSet<string>();
        }
        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (conqueredPeaks.Count == 0)
            {
                sb.AppendLine($"Peaks conquered: no peaks conquered");
            }
            sb.AppendLine($"Peaks conquered: {conqueredPeaks.Count}");
            return sb.ToString();
        }
    }
}
