using LocationService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationService.BusinessLogic
{
    public interface ILocationHandler
    {
        LocationRecord AddLocation(LocationRecord record);
        LocationRecord FindLatestLocation(Guid memberID);
        Task<LocationRecord> DeleteLocationAsync(Guid memberID, Guid locationID);
        LocationRecord UpdateLocation(LocationRecord record);
        ICollection<LocationRecord> GetAll(Guid memberID);
    }
}
