using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer:IInfluencer
    {
        private string name;
        private int followers;
        private double income;
        private List<string> participations;
        public string Username
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }
                name = value;
            }
        }

        public int Followers
        {
            get => followers;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }
                followers = value;
            }
        }

        public double EngagementRate { get; }

        public double Income
        {
            get => income;
            private set
            {
                value = 0;
                income = value;
            }
        }

        public IReadOnlyCollection<string> Participations { get=>participations.AsReadOnly(); }

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }

        public Influencer(string username, int followers, double engagementRate)
        {
            Username = username ;
            Followers = followers ;
            EngagementRate = engagementRate ;
            participations = new List<string>() ;
        }
        public void EarnFee(double amount)
        {
            Income += amount;
        }

        public void EnrollCampaign(string brand)
        {
            participations.Add(brand);
        }

        public void EndParticipation(string brand)
        {
            participations.Remove(brand);
        }

        public abstract int CalculateCampaignPrice();
    }
}
