using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class User : IdentityUser<int>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
