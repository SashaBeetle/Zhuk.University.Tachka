using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Interfaces;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public class AvatarHelper : IAvatarHelper
    {
        private  readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> GetRandomAvatar()
        {
            string apiUrl = "https://avatars.dicebear.com/api/male/"; // (male or female)

            string randomId = Guid.NewGuid().ToString();

            string avatarUrl = apiUrl + randomId + ".svg";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(avatarUrl);

                if (response.IsSuccessStatusCode)
                {
                    return avatarUrl;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при отриманні аватари: " + ex.Message);
            }

            return string.Empty;
        }

    }
}
