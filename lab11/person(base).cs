using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class Person : IComparable, ICloneable, IEquatable<Person>
    {
       
        public string FirstName { get; set; }
        public Person(string fn)
        {
            FirstName = fn;
        }

        public override string ToString()
        {
            return FirstName;
        }

        //public void Print() => Console.WriteLine("Person"); //non virtual (1st variant of the prog)
        public virtual void Print() => Console.WriteLine("Person");

        public bool Equals(Person obj)
        {
            if (obj == null) return false;
            if (Person.ReferenceEquals(this, obj)) return true;
            return this.FirstName == obj.FirstName;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            if (p != null)
                return this.FirstName.CompareTo(p.FirstName);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public virtual object Clone()
        {
            return new Person(FirstName);
            
            
        }
    }
}
