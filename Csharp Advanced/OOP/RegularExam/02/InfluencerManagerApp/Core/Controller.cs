using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller:IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != "BusinessInfluencer" && typeName != "FashionInfluencer" && typeName != "BloggerInfluencer")
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }
            if (influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username,nameof(InfluencerRepository));
            }

            IInfluencer influencer = null;
            switch (typeName)
            {
                case "BusinessInfluencer":
                    influencer = new BusinessInfluencer(username, followers);
                    break;
                case "FashionInfluencer":
                    influencer = new FashionInfluencer(username, followers);
                    break;
                case "BloggerInfluencer":
                    influencer = new BloggerInfluencer(username, followers);
                    break;
            }

            influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != "ProductCampaign" && typeName != "ServiceCampaign")
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }
            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign newCampaign = null;
            switch (typeName)
            {
                case "ProductCampaign":
                    newCampaign = new ProductCampaign(brand);
                    break;
                case "ServiceCampaign":
                    newCampaign = new ServiceCampaign(brand);
                    break;
            }

            campaigns.AddModel(newCampaign);

            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand,typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, typeof(InfluencerRepository).Name, username);
            }

            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }


            if (influencer.Participations.Contains(brand))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign is ProductCampaign)
            {
                if (!(influencer is BusinessInfluencer || influencer is FashionInfluencer))
                {
                    
                    return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
                }
            }
            else if (campaign is ServiceCampaign)
            {
                if (!(influencer is BusinessInfluencer || influencer is BloggerInfluencer))
                {
                    return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);

                }
            }

            if (campaign.Budget <= influencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            campaign.Gain(amount);

            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);

            }
            if (campaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var contributor in campaign.Contributors)
            {
                IInfluencer influencer = influencers.FindByName(contributor);
                influencer.EarnFee(2000);
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);

            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            IInfluencer currentInfluencer = influencers.FindByName(username);
            if (currentInfluencer.Participations.Count > 0)
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(currentInfluencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            var sortedInfluencers = influencers.Models
                .OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers);
            foreach (var influencer in sortedInfluencers)
            {
                sb.AppendLine(influencer.ToString());
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campBrand in influencer.Participations.OrderBy(p => p))
                    {
                        ICampaign campaign = campaigns.FindByName(campBrand);
                        sb.Append("--");
                        sb.Append(campaign.ToString());
                        sb.AppendLine();
                    }

                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
