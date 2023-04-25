using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOP.Authorization;

namespace OOP.Data
{
    public class DataStorage
    {
        public List<User>? users { get; set; }
        public Hashtable? words { get;set; }

        void AddWordInTable(string eng, string rus)
        {
            words?.Add(eng,rus);
        }
    }
}