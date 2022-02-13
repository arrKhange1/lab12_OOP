using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class Worker : Person, IEquatable<Worker>
    {
        public Worker(string fn, string factory, string posName) : base (fn)
        {
            FirstName = fn;
            factoryName = factory;
            positionName = posName;
        }
        public string factoryName { get; set; }
        public string positionName { get; set; }

        public Person BasePerson
        {
            get
            {
                return new Person (FirstName);
            }
        }

        public bool Equals(Worker obj)
        {
            if (obj == null) return false;
            if (Worker.ReferenceEquals(this, obj)) return true;
            return this.FirstName == obj.FirstName && this.factoryName == obj.factoryName && this.positionName == obj.positionName;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode();
        }

        //public void Print() => Console.WriteLine("Worker"); //no override
        public override void Print() => Console.WriteLine("Worker");
        public override object Clone()
        {
            return new Worker(FirstName, factoryName, positionName);
            

        }
    }
}
