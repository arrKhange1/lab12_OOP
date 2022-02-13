using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    public class Engineer : Worker
    {
        public Engineer (string fn, string fac, string pos) : base (fn, fac,pos)
        {
            FirstName = fn;
            factoryName = fac;
            positionName = pos;
        }
        public void Print() => Console.WriteLine($"Engineer: {FirstName}"); //no override
        //public override void Print() => Console.WriteLine($"Engineer: {FirstName}");
    }
}
