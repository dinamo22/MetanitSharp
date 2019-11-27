using System;
namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassLibrary_Test.Library_Test.Test_Command();
            Person Tom = new Person("tom", 220);
            Tom = new Person("tom", 49);
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
            Hell Dvor = new Hell(210);
            Hell Nobody = new Hell(44, "nobody");
            Lord.GetInfo();
            Admin.GetInfo();
            Dvor.GetInfo();
            Nobody.GetInfo();
        }
    }
}
