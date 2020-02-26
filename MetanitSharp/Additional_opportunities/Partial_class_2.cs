using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_opportunities
{
   
    public partial class Partial_class_1
    {
        public void Eat()
        {
            Console.WriteLine("Eat");
        }
        partial void DoSomethingElse()
        {
            Console.WriteLine("Something");
        }
    }
}
