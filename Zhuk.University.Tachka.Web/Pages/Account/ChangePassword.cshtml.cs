using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Zhuk.University.Tachka.Web.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        [Required(ErrorMessage = "¬каж≥ть ≥м'€")]
        public string Name { get; set; }
        [Required(ErrorMessage = "¬каж≥ть password")]
        [DataType(DataType.Password)]
        [Display(Name = "ѕароль")]
        [MinLength(6, ErrorMessage = "Password повинен мати довжину б≥льше 6 символ≥в")]
        public string NewPassword { get; set; }

    }
}
