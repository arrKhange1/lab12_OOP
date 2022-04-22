using System;
using System.Collections.Generic;
using System.Text;
using lab11;

namespace lab14
{
    public class Ceh
    {
        public Dictionary<Person, Worker> CehElem { get; set; }
        public string Name { get; set; }

        public Ceh(string name)
        {
            CehElem = new Dictionary<Person, Worker>();
            Name = name;
        }

    }
}
