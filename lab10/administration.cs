using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    class Administration : Person
    {
        public void Print() => Console.WriteLine($"Admin: {FirstName}"); //no override
        //public override void Print() => Console.WriteLine($"Admin: {FirstName}");
    }
}
