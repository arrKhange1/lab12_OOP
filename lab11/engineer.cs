using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class Engineer : Worker
    {
        public Engineer(string fn, string fac, string pos) : base (fn, fac, pos)
        {
            FirstName = fn;
            factoryName = fac;
            positionName = pos;
        }
        //public void Print() => Console.WriteLine("Engineer"); //no override
        public override void Print() => Console.WriteLine("Engineer");
        public override object Clone()
        {
            return new Engineer(FirstName, factoryName, positionName);
            

        }
    }
}
