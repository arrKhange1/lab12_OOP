using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_OOP
{
    class Worker : Person
    {
        public string factoryName { get; set; }
        public string positionName { get; set; }
        //public void Print() => Console.WriteLine("Worker"); //no override
        public override void Print() => Console.WriteLine("Worker");
    }
}
