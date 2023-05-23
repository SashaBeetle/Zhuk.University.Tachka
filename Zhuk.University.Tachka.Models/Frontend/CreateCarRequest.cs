using System;
using System.ComponentModel.DataAnnotations;


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
