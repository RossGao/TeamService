using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using TeamService.BusinessLogic;
using TeamService.Controllers;
using TeamService.Dtos;
using TeamService.LocationClient;
using TeamService.Models;
using Xunit;

namespace Test
{
    // Test the controller logic only, not including business logic, database access or framework(routing, filter etc)
    public class TeamControllerTest
    {
        static Mock<ITeamLogic> logic = new Mock<ITeamLogic>();
        static Mock<ILocationClient> locationClient = new Mock<ILocationClient>();
        TeamController controller = new TeamController(logic.Object, locationClient.Object);

        [Fact]
        public void AddNewTeamReturnNewTeam()
        {
            // Arrange
            var team = new Team("Test Team");
            logic.Setup(l => l.AddTeam(team)).Returns(AddMockTeam(team));

            // Act
            var result = controller.AddTeam(team);

            // Assert
            Assert.IsType<CreatedResult>(result);
            var created = (CreatedResult)result;
            new Guid(created.Location);
            Assert.Equal("Test Team", team.ToString());
        }

        [Fact]
        public void GetMemberWithLocation()
        {
            var teamID = Guid.NewGuid();
            var memberID = Guid.NewGuid();
            logic.Setup(l => l.GetMemberAsync(teamID, memberID)).Returns(GetMember(teamID, memberID));
            locationClient.Setup(c => c.GetLatestLocationAsync(memberID)).Returns(Task.FromResult(GetLocation(memberID)));

            var result = controller.GetMember(teamID, memberID);

            Assert.IsType<OkObjectResult>(result.Result);
            var successResult = (OkObjectResult)result.Result;
            Assert.IsType<MemberDto>(successResult.Value);
            var member = (MemberDto)successResult.Value;
            Assert.True(member.LastLocation != null);
            Assert.True(member.LastLocation.City == "shenzhen");
        }

        private Team AddMockTeam(Team team)
        {
            return new Team()
            {
                ID = Guid.NewGuid(),
                Name = team.Name,
            };
        }

        private LocationRecord GetLocation(Guid memberID)
        {
            return new LocationRecord()
            {
                ID = Guid.NewGuid(),
                MemberID = memberID,
                Latitude = 35.78F,
                Longitude = 128.6F,
                TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
            };
        }

        private Task<Member> GetMember(Guid teamID, Guid memberID)
        {
            return Task.FromResult(new Member()
            {
                ID = memberID,
                FirstName = "Test",
                LastName = "Member"
            });
        }
    }
}
