using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamService.Models
{
    public interface ITeamRepository
    {
        Team AddTeam(Team team);
        Team updateTeam(Team team);
        Team GetTeam(Guid teamID);
        ICollection<Team> GetAllTeams();
        Member AddMember(Guid teamID, Member member);
        Task GetMembersAsync(Team team);
    }
}
