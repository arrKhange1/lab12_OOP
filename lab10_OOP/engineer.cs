using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_OOP
{
    class Engineer : Worker
    {
        //public void Print() => Console.WriteLine("Engineer"); //no override
        public override void Print() => Console.WriteLine("Engineer");
    }
}
