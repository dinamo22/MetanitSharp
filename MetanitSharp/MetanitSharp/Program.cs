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
            for(int i = 0; i < 3; i++)
            {
                test_users[0, i].GetInfo();
            }
            Person Marbet = test_users[0, 1];
            Marbet.GetInfo();
        }
    }
}
