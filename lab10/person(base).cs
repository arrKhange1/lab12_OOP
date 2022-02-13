using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class Number
    {
        public int Num;
        public Number()
        {
            Num = 1;
        }
        public Number(int n)
        {
            Num = n;
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
    public class Person : IExecutable, IComparable, ICloneable, IEquatable<Person>
    {
        public string FirstName { get; set; }
        public Person()
        {
            FirstName = "NoName";
            n = new Number();
        }
        public Person(string fn)
        {
            FirstName = fn;
        }
        public int Num
        {
            get
            {
                return n.Num;
            }
            set
            {
                if (value < 0)
                    n.Num = 1;
                else
                    n.Num = value;
            }
        }
        public Person (string fn, int n)
        {
            FirstName = fn;
            this.n = new Number(n);
        }
        public Person(string fn, Number num)
        {
            FirstName = fn;
            n = num;
        }
        public Number n;//ссылка
        //public void Print() => Console.WriteLine($"Person: {FirstName}"); //non virtual (1st variant of the prog)

        public override string ToString()
        {
            return FirstName;
        }

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
        public virtual void Print() => Console.WriteLine($"Person: {FirstName}");
        public void InterfPrint()
        {
            Console.WriteLine(GetType().Name);
        }
        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            if (p != null)
                return this.FirstName.CompareTo(p.FirstName);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public object Clone()
        {
            return new Person(this.FirstName, this.n.Num); // deep coping
            //return MemberwiseClone();
        }
    }
}
