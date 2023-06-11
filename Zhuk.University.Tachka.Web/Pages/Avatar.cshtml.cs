using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Zhuk.University.Tachka.Database.Interfaces;
using Zhuk.University.Tachka.Models.Database;
using Zhuk.University.Tachka.Models.Frontend;

namespace Zhuk.University.Tachka.Web.Pages
{
    public class AvatarModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AvatarModel(UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public IFormFile AvatarFile { get; set; }

        public async Task<IActionResult> OnPostUploadAvatarAsync()
        {
            // Отримуємо ідентифікатор поточного користувача
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                try
                {
                    // Генеруємо унікальне ім'я для файлу
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + AvatarFile.FileName;

                    // Отримуємо шлях для збереження аватара
                    var avatarPath = Path.Combine(_hostingEnvironment.WebRootPath, "avatars", uniqueFileName);

                    // Зберігаємо файл аватара на сервері
                    using (var stream = new FileStream(avatarPath, FileMode.Create))
                    {
                        await AvatarFile.CopyToAsync(stream);
                    }

                    // Отримуємо об'єкт користувача з бази даних
                    var user = await _userManager.FindByIdAsync(userId);

                    // Присвоюємо полю AvatarPath шлях до аватара
                    user.AvatarPath = "/avatars/" + uniqueFileName;

                    // Оновлюємо дані користувача в базі даних
                    await _userManager.UpdateAsync(user);

                    return RedirectToPage("Profile");
                }
                catch (Exception ex)
                {
                    // Обробка помилок
                    ModelState.AddModelError(string.Empty, "Помилка під час завантаження аватара: " + ex.Message);
                }
            }

            return RedirectToPage("Profile");
        }
    }
}
