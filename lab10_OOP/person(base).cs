using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_OOP
{
    class Number
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
    class Person : IExecutable, IComparable, ICloneable
    {
        public string FirstName { get; set; }
        public Person()
        {
            FirstName = "NoName";
            n = new Number();
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
        //public void Print() => Console.WriteLine("Person"); //non virtual (1st variant of the prog)
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
            //return new Person(this.FirstName, this.n.Num); // deep coping
            return MemberwiseClone();
        }
    }
}
