using Plugin.QuestionsFabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class Admin : User
    {
        List<Student> students { get; set; }

       
    }
}
