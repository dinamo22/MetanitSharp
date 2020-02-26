using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_opportunities
{
    //частичный класс
    public partial class Partial_class_1
    {
        public void Move()
        {
            Console.WriteLine("Move");
        }
        partial void DoSomethingElse(); // частичные методы всегда приватные
        public void DoSomething()
        {
            Console.WriteLine("Do");
            DoSomethingElse();
            Console.WriteLine("Else");
        }
    }
}
