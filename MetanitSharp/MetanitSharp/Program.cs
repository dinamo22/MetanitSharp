using System;

namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Tom = new Person("tom", 21);
            Person Bob = new Person("bob");
            Person Noname = new Person();
            Person Pat = new Person(44);
            Tom.GetInfo();
            Bob.GetInfo();
            Noname.GetInfo();
            Pat.GetInfo();
            Console.WriteLine();
            Hell Lord = new Hell();
            Hell Admin = new Hell("Admin");
            Hell Dvor = new Hell(21);
            Hell Nobody = new Hell(44, "nobody");
            Lord.GetInfo();
            Admin.GetInfo();
            Dvor.GetInfo();
            Nobody.GetInfo();
        }
       
    }
}
