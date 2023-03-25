

namespace Zhuk.University.Tachka.Models.Database
{
    public class User : Dbitem
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // will in HASH
    } 
}
