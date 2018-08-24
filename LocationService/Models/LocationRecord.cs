using System;

namespace LocationService.Models
{
    public class LocationRecord
    {
        public Guid ID { get; set; } 
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
        public long TimeStamp { get; set; }
        public Guid MemberID { get; set; }
    }
}
