using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationService.Models;

namespace LocationService.BusinessLogic
{
    public class LocationHandler : ILocationHandler
    {
        private ILocationRecordRepository repository;

        public LocationHandler(ILocationRecordRepository theRepository)
        {
            repository = theRepository;
        }

        public LocationRecord AddLocation(LocationRecord record)
        {
            return repository.Add(record);
        }

        public LocationRecord FindLatestLocation(Guid memberID)
        {
            return repository.GetLatest(memberID);
        }

        public Task<LocationRecord> DeleteLocationAsync(Guid memberID, Guid locationID)
        {
            return Task.FromResult(repository.Delete(memberID, locationID));
        }

        public LocationRecord UpdateLocation(LocationRecord record)
        {
            return repository.Update(record);
        }

        public ICollection<LocationRecord> GetAll(Guid memberID)
        {
            return repository.GetAllRecords(memberID);
        }
    }
}
