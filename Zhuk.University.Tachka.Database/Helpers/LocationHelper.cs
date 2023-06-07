using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public class LocationHelper
    {
        private readonly HttpClient _httpClient;
        public LocationHelper() 
        {
            _httpClient = new HttpClient() 
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }
        private async Task<string> GetIpAdress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
            if(ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }
            return "";
        }
        public async Task<string> GetGeoInfo()
        {
            //I have already created this function under GeoInfoProvider class.
            var ipAddress = await GetIpAdress();
            // When geting ipaddress, call this function and pass ipaddress as given below
            var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress + "?access_key=5a9a3922db20492da1788046f9dd8fa2");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            return null;
        }
    }
}
