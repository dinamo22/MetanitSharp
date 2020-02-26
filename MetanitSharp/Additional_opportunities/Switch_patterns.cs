using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_opportunities
{
    public class Switch_patterns
    {
        //тут паттерны для switch
        public void dlya_vizova()
        {
            Switches switches = new Switches();
            int a = switches.SelectOp(2, 2, 3);
            Console.WriteLine(a);
            a = switches.PatternSelectOp1(3, 2, 3);
            Console.WriteLine(a);
            a = switches.PatternSelectOp2(4, 2, 3);
            Console.WriteLine(a);
        }
        //тут паттерн для свойств через switch
        public void dlya_vizova2()
        {
            Person_for_pattern person = new Person_for_pattern(21);
            Person_for_pattern person1 = new Person_for_pattern("Dima");
            Person_for_pattern person2 = new Person_for_pattern();
            Property_pattern property_Pattern = new Property_pattern();
            var strings = new[]
            {
                new{ stroka = property_Pattern.GetMessage(person)},
                new{ stroka = property_Pattern.GetMessage(person1)},
                new{ stroka = property_Pattern.GetMessage(person2)}
            };
            foreach (var s in strings)
            {
                Console.WriteLine(s.stroka);
            }
        }
    }
    public class Switches
    {
        public int SelectOp(int op, int x, int y)
        {
            switch (op)
            {
                case 1:
                    return x + y;
                case 2:
                    return x - y;
                case 3:
                    return x * y;
                default:
                    throw new Exception("Neudacha");
            }
        }
        public int PatternSelectOp1(int op, int x, int y)
        {
            return op switch
            {
                1 => x + y,
                2 => x - y,
                3 => x * y,
                _ => throw new Exception("Neudacha")
            };
        }
        public int PatternSelectOp2(int op, int x, int y) => op switch
        {
            1 => x + y,
            2 => x - y,
            3 => x * y,
            _ => throw new Exception("Neudacha")
        };
    }

    //класс данных для теста
    public class Person_for_pattern
    {
        public Person_for_pattern() : this("Who knows?") { }
        public Person_for_pattern(int age) : this(age, "Who knows?") { }
        public Person_for_pattern(string firstname) : this(firstname, "Not me!") { }
        public Person_for_pattern(int age, string firstname) : this(age, firstname, "Not me!") { }
        public Person_for_pattern(string firstname, string lastname) : this(8, firstname, lastname) { }
        public Person_for_pattern(int age, string firstname, string lastname)
        {
            Age = age;
            FirstName = firstname;
            LastName = lastname;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    //сам паттерн
    public class Property_pattern
    {
        public string GetMessage(Person_for_pattern person) => person switch
        {
        { Age: 21 } => "21",
        { FirstName: "Dima" } => "Dima",
        { Age: var age, FirstName: var firstname, LastName: var lastname } => $"{firstname} {lastname} {age}",
        //{ } => "Net sovpadenii",
        null => "null",
        };
    }

    //так же существуют паттерны кортежей
    //их я рассматривать не буду, но кусочки кода оставлю
    public class Cortej_pattern
    {
        //можно просто оставлять прочерки. Обязательно передавать 3 элемента
        public string GetWelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Здрасьть"
        };
    }

    //класс с обязательным деконструктором
    public class GetSomeInfo
    {
        public string Language { get; set; } //язык
        public string DataTime { get; set; } //время
        public string Status { get; set; } //статус

        public void Deconstruct(out string language, out string datatime, out string status)
        {
            language = Language;
            datatime = DataTime;
            status = Status;
        }
    }
    //паттерн для деконструктора
    public class Deconstruct_pattern
    {
        public string GetWelcome(GetSomeInfo info) => info switch
        {
            ("rus", "morning", _) => "Доброе утро!",
            ("eng", "evening", _) => "Good evening!",
            { Language: "rus" } => "Нехватает данных!",
            { Language: "eng" } => "Not enough data",
            _ => "Some error in data",
        };
    }
}
