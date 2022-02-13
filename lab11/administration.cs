using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    public class Administration : Person
    {
        public Administration(string fn) : base(fn)
        {
            FirstName = fn;
        }
        //public void Print() => Console.WriteLine("Admin"); //no override
        public override void Print() => Console.WriteLine("Admin");
        public override object Clone()
        {
            return new Administration(FirstName);
            

        }
    }
}
