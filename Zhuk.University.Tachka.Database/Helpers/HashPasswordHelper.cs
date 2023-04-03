using System.Text;
using System.Security.Cryptography;

namespace Zhuk.University.Tachka.Database.Helpers
{
    public static class HashPasswordHelper
    {
        public static string HashPassword(string password)
        {
            using(var sha256=SHA256.Create())
            {
                var hashedBytes= sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
