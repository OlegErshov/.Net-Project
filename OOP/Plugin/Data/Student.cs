using Plugin.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class Student : User
    {
        public const string Role = "student";

        public Student(string email, string login, string password)
        {
            Email = email;
            Login = login;
            Password = password;
            
        }
        
       
        public Student(string email, string login, string password, int id)
        {
            Email = email;
            Login = login;
            Password = password;
            Id = id;
        }

        public Student() { }

        public List<GrammaTask>? _GrammaList { get; set; } = new List<GrammaTask>();
        public List<InsertTask>? _InsertList { get; set; } = new List<InsertTask>();
        public List<SentenceTask>? _SentenceList { get; set; } = new List<SentenceTask>();
        public List<VocabluaryTask>? _VocabluaryList { get; set; } = new List<VocabluaryTask>();

    }
}
