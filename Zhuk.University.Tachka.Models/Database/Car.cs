using System;

namespace Zhuk.University.Tachka.Models.Database
{
    public class Car : Dbitem
    {
        public string? Name { get; set; }
        public string? Model { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PlacementTime { get; set; }
    }
}
