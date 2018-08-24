using System;

namespace TeamService.Models
{
    public class LocationRecord
    {
        public Guid ID { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float TimeStamp { get; set; }
        public Guid MemberID { get; set; }
    }
}
