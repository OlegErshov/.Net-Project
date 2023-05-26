using Microsoft.AspNetCore.Identity;
using Plugin.QuestionsFabrics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class Teacher : IdentityUser
    {
        public IdentityRole role = new IdentityRole("Teacher");
        public List<Student> students { get; set; }

        public const string Role = "teacher";

       
    }
}
