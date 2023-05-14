using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class User
    {
        public string Role { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }   

        public string Password { get; set; }
    }
}
