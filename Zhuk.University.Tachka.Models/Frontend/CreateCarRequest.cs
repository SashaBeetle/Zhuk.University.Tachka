using System;
using System.ComponentModel.DataAnnotations;
using Zhuk.University.Tachka.Models.Database;


namespace Zhuk.University.Tachka.Models.Frontend
{
    
    public class CreateCarRequest
    {
        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        [StringLength(256, MinimumLength = 10, ErrorMessage = "Довжина повинна бути від 5 до 256 символів.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Це поле є обов'язковим.")]
        [Range(1990, 9999, ErrorMessage = $"Значення повинно бути 1990 - Поточний рік")]
        public string? Year { get; set; }

        [Url(ErrorMessage = "Неправильний формат URL-покликання.")]
        public string? Photo { get; set; }
    }
}
