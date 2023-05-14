using Plugin.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class HomeWork
    {
        public List<GrammaTask>? _GrammaList = new List<GrammaTask>();
        public List<InsertTask>? _InsertList = new List<InsertTask>();
        public List<SentenceTask>? _SentenceList = new List<SentenceTask>();
        public List<VocabluaryTask>? _VocabluaryList = new List<VocabluaryTask>();
    }
}
