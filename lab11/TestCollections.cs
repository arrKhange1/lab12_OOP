using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class TestCollections
    {
        public TestCollections(int n)
        {
            StackString = new Stack<string>(n);
            StackPerson = new Stack<Person>(n);
            DictPerson = new Dictionary<Person, Worker>(n);
            DictString = new Dictionary<string, Worker>(n);
        }

        public Stack<Person> StackPerson { get; set; }
        
        public Stack<string> StackString { get; set; }
        
        public Dictionary<Person, Worker> DictPerson { get; set; }
        
        public Dictionary<string, Worker> DictString { get; set; }
        
    }
}
