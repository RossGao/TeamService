using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TeamService.Models;

namespace TeamService.LocationClient
{
    public class LocationClientService : ILocationClient
    {
        private readonly Uri url;

        public LocationClientService(Uri locationServiceUrl)
        {
            url = locationServiceUrl;
        }

        public async Task<LocationRecord> GetLatestLocationAsync(Guid memberID)
        {
            var record = new LocationRecord();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(new Uri($"locations/{memberID}/latest"));
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    record = JsonConvert.DeserializeObject<LocationRecord>(jsonContent);
                }
            }

            return record;
        }
    }
}
