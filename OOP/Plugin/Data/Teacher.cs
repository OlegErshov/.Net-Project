using Plugin.QuestionsFabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class Teacher : User
    {
        public List<int> students { get; set; }

        public const string Role = "teacher";

       
    }
}
