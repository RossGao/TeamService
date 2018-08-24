 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamService.Models
{
    // Handle database request.
    public class TeamRepository : ITeamRepository
    {
        private TeamContext dbContext;

        public TeamRepository(TeamContext theContext)
        {
            dbContext = theContext;
        }

        public Member AddMember(Guid teamID, Member member)
        {
            dbContext.Add(member);
            dbContext.Teams.Find(teamID).Members.Add(member);
            dbContext.SaveChanges();
            return member;
        }

        public Team AddTeam(Team team)
        {
            dbContext.Add(team);
            dbContext.SaveChanges();
            return team;
        }

        public Team GetTeam(Guid teamID)
        {
            return dbContext.Teams.Find(teamID);
        }

        public ICollection<Team> GetAllTeams()
        {
            return dbContext.Teams.ToList();
        }

        public Team updateTeam(Team team)
        {
            dbContext.Entry(team).State = EntityState.Modified;
            dbContext.SaveChanges();
            return team;
        }

        public async Task GetMembersAsync(Team team)
        {
            await dbContext.Entry(team).Collection(t => t.Members).LoadAsync();
        }
    }
}
