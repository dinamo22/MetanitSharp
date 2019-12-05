using System;

namespace ClassLibrary_Test
{
    // тест подключение библиотеки
    public class Library_Test
    {
        public static void Test_Command()
        {
            Console.WriteLine("Test command in ClassLibrary_Test");
        }
    }
    public class Person
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }
        public Person()
        {
            Name = "Random_name";
        }
        public Person(string Name_is)
        {
            Name = Name_is;
        }
        public void New_Employe(ref Person primer, string Boss_is) //для internal
        {
            primer = new Employe(Name,Boss_is);
        }
        public void New_Employ(ref Person primer, string Company_is) //для internal 
        {
            primer = new Employ(Name, Company_is);
        }
        virtual public void Display() // виртуальный метод, возможно переопределение в дочерных классах
        {
            Console.WriteLine(Name);
        }
        public static implicit operator Person(string name) // неявное преобразование типов
        {
            return new Person(name);
        }
        public static explicit operator string(Person person) // явное п.т.
        {
            return person.Name;
        }
    }
    public class Employee : Person
    {
        public string Rang { get; set; }
        public Employee(string Rang_is) : base()
        {
            Name = base.Name;
            Rang = Rang_is;
        }
        public Employee(string Name_is,string Rang_is) :base(Name_is)
        {
            Rang = Rang_is;
        }
        public new void Display() //сокрытие, читай - переопределение
        {
            Console.WriteLine($"{Name} is employee, rang : {Rang}");
        }
    }
    public class Employe : Person //internal не имеет смысла, тк не обратиться к методам класса Employe
    {
        public string Boss { get; set; }
        public Employe(string Name_is, string Boss_is) : base(Name_is)
        {
            Boss = Boss_is;
        }
        public Employe(string Boss_is) : base()
        {
            Name = base.Name;
            Boss = Boss_is;
        }
        public void Display()
        {
            Console.WriteLine($"{Name} is Boss, rang : {Boss}");
        }
    }
    internal class Employ : Person
    {
        public string Company { get; set; }
        public Employ(string Company_is) : base()
        {
            Company = Company_is;
        }
        public Employ(string Name_is, string Company_is) : base(Name_is)
        {
            Company = Company_is;
        }
        override public void Display() //переопределение виртуального метода
        {
            Console.WriteLine($"{Name} work in {Company}");
        }
    }
}
