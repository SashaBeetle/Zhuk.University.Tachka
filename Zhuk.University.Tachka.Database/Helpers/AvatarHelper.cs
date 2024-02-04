using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Database.Interfaces;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public class AvatarHelper
    {
        private  readonly HttpClient _httpClient = new HttpClient();

        public  async Task<string> GetRandomAvatar()
        {
            string apiUrl = "https://avatars.dicebear.com/api/male/"; // Змініть стать (male або female) за потребою

            // Генеруємо випадковий ідентифікатор
            string randomId = Guid.NewGuid().ToString();

            // Формуємо URL для отримання аватари
            string avatarUrl = apiUrl + randomId + ".svg";

            try
            {
                // Виконуємо запит до API та отримуємо відповідь
                HttpResponseMessage response = await _httpClient.GetAsync(avatarUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Повертаємо URL аватари
                    return avatarUrl;
                }
            }
            catch (Exception ex)
            {
                // Обробка помилок
                Console.WriteLine("Помилка при отриманні аватари: " + ex.Message);
            }

            // У випадку помилки повертаємо порожній рядок
            return string.Empty;
        }

    }
}
