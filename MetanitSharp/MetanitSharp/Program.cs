using System;
using ClassLibrary_Test;
using ForExceptions;

namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //delegati_musor.Dlya_vizova();
            Bank_Account bank = new Bank_Account(400);
            bank.Notify += bank.NotifyConsoleOut;
            bank.Notify += bank.NotifyConsoleOutRed;
            bank.Put(20);
            bank.Notify -= bank.NotifyConsoleOutRed;
            bank.Take(410);

            Work_With_Interfaces.Dlya_vizova3();
            Somebody somebody = new Somebody();
            ForICloneable.SomeClass1 clon = new ForICloneable.SomeClass1 { Age = 21, Name = "Dima", SomeClass2_obj = new ForICloneable.SomeClass2 { Lenght = 175 } };
            clon.Display();
            ForICloneable.SomeClass1 clon2 = (ForICloneable.SomeClass1)clon.Clone();
            clon2.Display();
            clon2.Age = 22;
            clon.Display();
            clon2.Display();
            ForICloneable.SomeClass1 smth1 = new ForICloneable.SomeClass1(name: "spirit", lenght: 590, age: 66);
            ForICloneable.SomeClass1 smth2 = new ForICloneable.SomeClass1("SomeB", 44);
            smth1.Display();
            smth2.Display();
            ForICloneable.SomeClass1 smth3 = new ForICloneable.SomeClass1 { Age = 77 };
            smth3.Display();
            ForICloneable.SomeClass1[] nuts = { smth1, smth2, smth3 };
            //Array.Sort(nuts);
            foreach (ForICloneable.SomeClass1 nut in nuts)
            {
                nut.Display();
            }
            Console.WriteLine();
            ForICompareTo.SomeClass1 compareto1 = new ForICompareTo.SomeClass1 { Name = "Oleg", Age = 1 };
            ForICompareTo.SomeClass1 compareto2 = new ForICompareTo.SomeClass1 { Name = "Maria", Age = 2 };
            ForICompareTo.SomeClass1 compareto3 = new ForICompareTo.SomeClass1 { Name = "Sasha", Age = 3 };
            ForICompareTo.SomeClass1 compareto4 = new ForICompareTo.SomeClass1 { Name = "Kolya", Age = 4 };
            ForICompareTo.SomeClass1 compareto5 = new ForICompareTo.SomeClass1 { Name = "Natasha", Age = 5 };
            ForICompareTo.SomeClass1[] peoples = { compareto1, compareto2, compareto3, compareto4, compareto5 };
            foreach (ForICompareTo.SomeClass1 people in peoples)
            {
                people.Display();
            }
            Console.WriteLine();
            Array.Sort(peoples);
            foreach (ForICompareTo.SomeClass1 people in peoples)
            {
                people.Display();
            }
            int c = compareto1.CompareTo(smth1, 0);
            Console.WriteLine(c);
            Console.WriteLine();
            ForICompareTo.SomeClass2 apex1 = new ForICompareTo.SomeClass2 { Age = 3 };
            ForICompareTo.SomeClass2 apex2 = new ForICompareTo.SomeClass2 { Age = 1 };
            ForICompareTo.SomeClass2 apex3 = new ForICompareTo.SomeClass2 { Age = 2 };
            ForICompareTo.SomeClass2[] apex = { apex1, apex2, apex3 };
            foreach (ForICompareTo.SomeClass2 ap in apex)
            {
                ap.Display();
            }
            Array.Sort(apex);
            foreach (ForICompareTo.SomeClass2 ap in apex)
            {
                ap.Display();
            }
            Console.WriteLine();

            ForICompareTo.SomeClass3 look = new ForICompareTo.SomeClass3 { Age = 3 };
            ForICompareTo.SomeClass3 at = new ForICompareTo.SomeClass3 { Age = 1 };
            ForICompareTo.SomeClass3 me = new ForICompareTo.SomeClass3 { Age = 2 };
            ForICompareTo.SomeClass3[] what = { look, at, me };
            foreach (ForICompareTo.SomeClass3 who in what)
            {
                who.Display();
            }
            Array.Sort(what,new ForICompareTo.SomeClass3());
            foreach (ForICompareTo.SomeClass3 who in what)
            {
                who.Display();
            }
        }
    } 
}
