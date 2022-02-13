using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.FirstName.CompareTo(p2.FirstName) > 0)
                return 1;
            else if (p1.FirstName.CompareTo(p2.FirstName) < 0)
                return -1;
            else
                return 1;
        }
    }
}
