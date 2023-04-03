using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zhuk.University.Tachka.Models.Database;

namespace Zhuk.University.Tachka.Models.Frontend
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string Token { get; set;}
        public AuthenticateResponse(User user, string token)
        {
            
                Id = user.Id;
                Name = user.Name;
                Password = user.Password;
                Email = user.Email;
                Token = token;
            
        }
       
    }
}
