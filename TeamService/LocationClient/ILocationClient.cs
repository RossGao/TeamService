using System;
using System.Threading.Tasks;
using TeamService.Models;

namespace TeamService.LocationClient
{
    public interface ILocationClient
    {
        Task<LocationRecord> GetLatestLocationAsync(Guid memberID);
    }
}
