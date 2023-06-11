using System;
using System.ComponentModel.DataAnnotations;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Models.Frontend
{
    public class CreateOrderRequest
    {
        [Required]
        public int CarId { get; set; }
        [Required]
        public virtual Car Car { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
