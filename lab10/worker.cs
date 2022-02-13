using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class Worker : Person, IEquatable<Worker>
    {

        public Worker(string fn, string fac, string pos) : base(fn)
        {
            FirstName = fn;
            factoryName = fac;
            positionName = pos;
        }

        public Worker (string fn) : base(fn)
        {
            FirstName = fn;
        }
        public string factoryName { get; set; }
        public string positionName { get; set; }
        //public void Print() => Console.WriteLine($"Worker: {FirstName}"); //no override
        public override void Print() => Console.WriteLine($"Worker: {FirstName}");

        public override string ToString()
        {
            if (factoryName == null || positionName == null) return FirstName;
            return $"{FirstName} - {factoryName}, {positionName}";
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
    }
}
