using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationService.Models
{
    public class LocationRecordRepository : ILocationRecordRepository
    {
        private readonly LocationContext context;

        public LocationRecordRepository(LocationContext locationContext)
        {
            context = locationContext;
        }

        public LocationRecord Add(LocationRecord record)
        {
            context.Add(record);
            context.SaveChanges();
            return record;
        }

        public LocationRecord Update(LocationRecord record)
        {
            context.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return record;
        }

        public LocationRecord Delete(Guid memberID, Guid recordID)
        {
            var record = GetLocation(memberID, recordID);
            context.Remove(record);
            context.SaveChanges();
            return record;
        }

        public LocationRecord GetLocation(Guid memberID, Guid recordID)
        {
            return context.LocationRecords.Single(r => r.MemberID == memberID && r.ID == recordID);
        }

        public ICollection<LocationRecord> GetAllRecords(Guid memberID)
        {
            return context.LocationRecords.Where(r => r.MemberID == memberID).OrderBy(r => r.TimeStamp).ToList();
        }

        public LocationRecord GetLatest(Guid memberID)
        {
            return context.LocationRecords.Where(r => r.MemberID == memberID).OrderBy(r => r.TimeStamp).Last();
        }
    }
}
