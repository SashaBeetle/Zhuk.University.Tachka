using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Models.Frontend
{
    public class CreateCarRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}
