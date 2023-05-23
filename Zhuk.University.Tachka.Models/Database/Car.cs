using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Car : Dbitem
    {
        public string? Name { get; set; }
        public string? Model { get; set; }
        public decimal? Price { get; set; }
       // [Column(TypeName = "Date")]
        public string? PlacementTime { get; set; }
    }
}
