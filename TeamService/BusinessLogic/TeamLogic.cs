using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamService.LocationClient;
using TeamService.Models;

namespace TeamService.BusinessLogic
{
    // Generally speaking this is where we handler the poco instance in local memory.
    public class TeamLogic : ITeamLogic
    {
        private ITeamRepository repository;
        private ILocationClient locationClient;

        public TeamLogic(ITeamRepository theRepository, ILocationClient client)
        {
            repository = theRepository;
            locationClient = client;
        }

        public Team GetTeam(Guid teamID)
        {
            return repository.GetTeam(teamID);
        }

        public Member AddMember(Guid teamID, Member member)
        {
            return repository.AddMember(teamID, member);
        }

        public Team AddTeam(Team team)
        {
            return repository.AddTeam(team);
        }

        public ICollection<Team> FindAllTeams()
        {
            return repository.GetAllTeams();
        }

        public async Task<Member> GetMemberAsync(Guid teamID, Guid memberID)
        {
            var team = repository.GetTeam(teamID);
            if (team != null)
            {
                await repository.GetMembersAsync(team);
                var member = team.Members.FirstOrDefault(m => m.ID == memberID);
                return member;
            }

            return null;
        }
    }
}
