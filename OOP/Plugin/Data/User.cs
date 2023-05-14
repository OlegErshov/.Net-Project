using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class User
    {
        

        public string Login { get; set; }

        public int Id { get; set; }

        public string Email { get; set; }   

        public string Password { get; set; }
    }
}
