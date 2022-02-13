using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_OOP
{
    class Administration : Person
    {
        //public void Print() => Console.WriteLine("Admin"); //no override
        public override void Print() => Console.WriteLine("Admin");
    }
}
