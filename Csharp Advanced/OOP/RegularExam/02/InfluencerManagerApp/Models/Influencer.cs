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
        private List<string> participations;

        public Influencer(string username, int followers, double engagementRate)
        {
            Username = username;
            Followers = followers;
            EngagementRate = engagementRate;
            Income = 0;
            participations = new List<string>();
        }


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

        public double EngagementRate { get; private set; }

        public double Income
        {
            get;
            private set;
        }

        public IReadOnlyCollection<string> Participations => participations.AsReadOnly();

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
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
