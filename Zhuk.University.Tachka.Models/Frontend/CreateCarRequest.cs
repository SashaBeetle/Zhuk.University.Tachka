using System;
using System.ComponentModel.DataAnnotations;
using Zhuk.University.Tachka.Models.Database;

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
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Year { get; set; }
        [Required]
        public virtual ICollection<Photo> Photos { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
