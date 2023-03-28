using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Zhuk.University.Tachka.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [Required(ErrorMessage = "Вкажіть ім'я")]
        [MaxLength(30,ErrorMessage = "Ім'я повинно мати довжину 3-30 символів")]
        [MinLength(3, ErrorMessage = "Ім'я повинно мати довжину 3-30 символів")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Вкажіть Password")]
        [MinLength(6, ErrorMessage = "Password повинен мати довжину більше 6 символів")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Підтвердіть Password")]
        [Compare("Password", ErrorMessage = "Passwords не співпадають")]
        public string ConfirmPassword { get; set;}
    }
}
