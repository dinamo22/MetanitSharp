using System;
using ClassLibrary_Test;
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
            Users test_users = new Users();
            test_users[0] = new Person("Lava", num: 777, age: 27);
            test_users[1] = new Person("Lave", 49);
            test_users[2] = new Person("Spore", 23);
            test_users[3] = new Person("Qnobo", 14);
            test_users[4] = new Person("Posla", 63);
            for (int i = 0; i < 5; i++)
            {
                test_users[i].GetInfo();
            }
            Person Marat = test_users[4];
            Marat.GetInfo();
            test_users[0, 0] = new Person("Gnome", 42, 654);
            test_users[0, 1] = new Person("Asgorn", 13, 74);
            test_users[0, 2] = new Person("Mporeg", 37, 91);
            for (int i = 0; i < 3; i++)
            {
                test_users[0, i].GetInfo();
            }
            Person Marbet = test_users[0, 1];
            Marbet.GetInfo();
            Console.WriteLine();

            ClassLibrary_Test.Person Jack = new ClassLibrary_Test.Person { Name = "qwe" };
            Jack.Display();
            Jack = new Employee(Name_is: Jack.Name, "Fucking Slave");
            ((Employee)Jack).Display(); //downcasting Person to Employee -восходящие преобразование

            Employee employee = new Employee("Tom", "Slave");
            employee.Display();
            ClassLibrary_Test.Person person = employee; //upcasting Employee to Person - низходящие преобразования
            person.Display();
            ((Employee)person).Display();
            Employee TryDownCasting = person as Employee;
            if (TryDownCasting == null)
            {
                Console.WriteLine("Преобразование не удалось");
            }
            else
            {
                TryDownCasting.Display();
            }
            Employe TryDownCasting2 = person as Employe;
            if (TryDownCasting2 == null)
            {
                Console.WriteLine("Преобразование не удалось");
            }
            else
            {
                TryDownCasting2.Display();
            }
            Jack.New_Employe(ref Jack,"Big Boss"); // как обратиться к методам Employe если он internal?

            ClassLibrary_Test.Person oleg = new ClassLibrary_Test.Person("oleg");
            string oleg_string = (string)oleg; //явное преобразование explicit
            Console.WriteLine(oleg_string);
            ClassLibrary_Test.Person masha = new ClassLibrary_Test.Person();
            masha = oleg_string; // неявное implicit
            masha.Display();
            ClassLibrary_Test.Person virtual_override_test = new ClassLibrary_Test.Person("Virtual");
            virtual_override_test.Display();
            virtual_override_test.New_Employ(ref virtual_override_test,"Microsoft");
            virtual_override_test.Display();
        }
    }
}
