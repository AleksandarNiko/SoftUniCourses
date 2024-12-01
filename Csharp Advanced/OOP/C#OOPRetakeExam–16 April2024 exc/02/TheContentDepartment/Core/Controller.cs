using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private IRepository<IResource> resources;
        private IRepository<ITeamMember> members;

        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(m => m.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }

            if (members.Models.Any(m => m.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember member;

            if (memberType == nameof(TeamLead))
            {
                member = new TeamLead(memberName, path);
            }
            else
            {
                member = new ContentMember(memberName, path);
            }

            members.Add(member);

            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != nameof(Exam) && resourceType != nameof(Workshop) && resourceType != nameof(Presentation))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            ITeamMember teamMember = members.Models.FirstOrDefault(m => m.Path == path);

            if (teamMember == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }
            if (teamMember.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource resource;

            if (resourceType == nameof(Exam))
            {
                resource = new Exam(resourceName, teamMember.Name);
            }
            else if (resourceType == nameof(Workshop))
            {
                resource = new Workshop(resourceName, teamMember.Name);
            }
            else
            {
                resource = new Presentation(resourceName, teamMember.Name);
            }

            resources.Add(resource);
            teamMember.WorkOnTask(resourceName);

            return string.Format(OutputMessages.ResourceCreatedSuccessfully, teamMember.Name, resource.GetType().Name, resourceName);
        }

        public string LogTesting(string memberName)
        {
            ITeamMember member = members.TakeOne(memberName);

            if (member == null)
            {
                return string.Format(OutputMessages.WrongMemberName);
            }

            IResource resource = resources.Models
                .Where(m => m.Creator == member.Name).Where(m => m.IsTested == false)
                .OrderBy(m => m.Priority).FirstOrDefault();

            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            ITeamMember teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            resource!.Test();

            member.FinishTask(resource.Name);
            teamLead!.WorkOnTask(resource.Name);

            return string.Format(OutputMessages.ResourceTested, resource.Name);
        }

        public string ApproveResource(string resourceName, bool isApprovedNyTeamLead)
        {
            IResource resource = resources.TakeOne(resourceName);

            if (resource.IsTested == false)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            ITeamMember teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == nameof(TeamLead));

            if (isApprovedNyTeamLead)
            {
                resource.Approve();
                teamLead!.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resource.Name);
            }
            else
            {
                resource.Test();
                return string.Format(OutputMessages.ResourceReturned, teamLead!.Name, resource.Name);
            }
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Finished Tasks:");

            foreach (var item in resources.Models.Where(m => m.IsApproved))
            {
                sb.AppendLine($"--{item.ToString()}");
            }

            sb.AppendLine($"Team Report:");

            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == nameof(TeamLead));

            sb.AppendLine($"--{teamLead!.ToString()}");

            foreach (var item in members.Models.Where(m => m.GetType().Name != nameof(TeamLead)))
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
