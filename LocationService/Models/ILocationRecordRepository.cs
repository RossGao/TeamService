using System;
using System.Collections.Generic;

namespace LocationService.Models
{
    public interface ILocationRecordRepository
    {
        LocationRecord Add(LocationRecord record);
        LocationRecord Update(LocationRecord record);
        LocationRecord GetLocation(Guid memberID, Guid recordID);
        LocationRecord Delete(Guid memberID, Guid recordID);

        LocationRecord GetLatest(Guid memberID);
        ICollection<LocationRecord> GetAllRecords(Guid memberID);
    }
}
