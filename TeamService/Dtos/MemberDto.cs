using System;
using TeamService.Models;

namespace TeamService.Dtos
{
    public class MemberDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LocationRecord LastLocation { get; set; }
    }
}
