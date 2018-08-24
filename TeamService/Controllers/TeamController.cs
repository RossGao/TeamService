using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TeamService.BusinessLogic;
using TeamService.Dtos;
using TeamService.LocationClient;
using TeamService.Models;

namespace TeamService.Controllers
{
    // Receive request parameters and composite the Dto object.
    [Route("team")]
    public class TeamController : Controller
    {
        private ITeamLogic logicHandler;
        private ILocationClient locationClient;

        public TeamController(ITeamLogic hanlder, ILocationClient client)
        {
            logicHandler = hanlder;
            locationClient = client;
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            logicHandler.AddTeam(team);
            return Created($"{team.ID}", team);
        }

        [HttpPost]
        [Route("{teamID}")]
        public IActionResult AddMember(Guid teamID, Member member)
        {
            logicHandler.AddMember(teamID, member);
            return Created($"{member.ID}", member);
        }

        [HttpGet]
        [Route("{teamID}/{memberID}")]
        public async Task<IActionResult> GetMember(Guid teamID, Guid memberID)
        {
            var member = await logicHandler.GetMemberAsync(teamID, memberID);
            if(member!=null)
            {
                var location = await locationClient.GetLatestLocationAsync(memberID);
                location.City = "shenzhen";

                return Ok(new MemberDto()
                {
                    ID = memberID,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    LastLocation = location
                });
            }

            return NotFound();
        }
    }
}
