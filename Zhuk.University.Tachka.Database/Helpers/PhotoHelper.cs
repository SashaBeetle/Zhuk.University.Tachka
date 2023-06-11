using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public static class PhotoHelper
    {
        public static async Task<int> UploadPhoto(IFormFile photo, TachkaDbContext dbContext)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                var fileExtension = Path.GetExtension(fileName);

                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);

                    var newPhoto = new Photo
                    {
                        FileName = fileName,
                        ImageData = memoryStream.ToArray()
                    };

                    dbContext.Photos.Add(newPhoto);
                    await dbContext.SaveChangesAsync();

                    return newPhoto.Id;
                }
            }

            return -1; // Повертаємо -1, якщо фото не було завантажено
        }
    }

}
