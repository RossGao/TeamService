using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamService.Models;

namespace TeamService.BusinessLogic
{
    public interface ITeamLogic
    {
        Team AddTeam(Team team);
        Team GetTeam(Guid teamID);
        ICollection<Team> FindAllTeams();
        Member AddMember(Guid teamID, Member member);
        Task<Member> GetMemberAsync(Guid teamID, Guid memberID);
    }
}
