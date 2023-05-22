using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Plugin.Authorization
{
    public class User : IdentityUser<string>
    {
        

        public string Login { get; set; }

        [AutoIncrement]
        public int Id { get; set; }

        public string Email { get; set; }   

        public string Password { get; set; }
    }
}
