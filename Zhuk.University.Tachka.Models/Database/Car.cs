using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Car : Dbitem
    {
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? Year { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        //[Column(TypeName = "Date")]
        public string? PlacementTime { get; set; }
        public string? PlacementCity { get; set; }
        public float? Rating { get; set; }
        // Зв'язок один до багатьох з таблицею "Фотографії"
        public virtual ICollection<Photo> Photos { get; set; }
        public string UserId { get; set; }

    }
}
