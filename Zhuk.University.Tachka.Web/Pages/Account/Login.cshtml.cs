using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Zhuk.University.Tachka.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "¬каж≥ть ≥м'€")]
        [MaxLength(30, ErrorMessage = "≤м'€ повинно мати довжину 3-30 символ≥в")]
        [MinLength(3, ErrorMessage = "≤м'€ повинно мати довжину 3-30 символ≥в")]
        public string Name { get; set; }
        [Required(ErrorMessage = "¬каж≥ть Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password повинен мати довжину б≥льше 6 символ≥в")]
        public string Password { get; set; }
    }
}
