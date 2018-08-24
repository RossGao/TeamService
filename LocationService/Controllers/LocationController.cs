using LocationService.BusinessLogic;
using LocationService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService
{
    [Route("locations/{memberID}")]
    public class LocationController : Controller
    {
        private ILocationHandler handler;

        public LocationController(ILocationHandler theHandler)
        {
            handler = theHandler;
        }

        [HttpPost]
        public IActionResult AddLocation(Guid memberID, LocationRecord newRecord)
        {
            handler.AddLocation(newRecord);
            return Created($"locations/{memberID}/{newRecord.ID}", newRecord);
        }

        [HttpGet]
        public IActionResult GetAllLocations(Guid memberID)
        {
            return Ok(handler.GetAll(memberID));
        }

        [HttpGet("latest")]
        public IActionResult GetLatestLocation(Guid memberID)
        {
            return Ok(handler.FindLatestLocation(memberID));
        }

        [HttpDelete("{locationID}")]
        public async Task<IActionResult> DeleteLocaiton(Guid memberID, Guid locationID)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var result = await handler.DeleteLocationAsync(memberID, locationID).ConfigureAwait(false);
            
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            return Ok(result);
        }

        [HttpPut("{locationID}")]
        public IActionResult UpdateLocation(LocationRecord record)
        {
            return Ok(handler.UpdateLocation(record));
        }
    }
}
