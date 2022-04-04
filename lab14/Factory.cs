using System;
using System.Collections.Generic;
using System.Text;
using lab11;

namespace lab14
{
    public class Factory
    {
        public Stack<Ceh> stack { get; set; }

        public Factory()
        {
            stack = new Stack<Ceh>();
        }
    }
}
