using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_opportunities
{
    //Pattern_matching + Deconstruct
    public class Pattern_matching
    {
        //3 вызова через is as try..catch и 2 через паттерны
        public void dlya_vizova()
        {
            One one = new One();
            one = new Two();
            UseOne1(one);
            UseOne2(one);
            UseOne3(one);
            one.Age = 21;
            one.Name = "Name";
            (string name, int age) = one;
            UseOnePatternMathing_As(one);
            UseOnePatternMathing_Switch(one);
        }
        // через is
        void UseOne1(One one)
        {
            if (one is Two)
            {
                Two two = (Two)one;
                if(two.SomeBool == false)
                {
                    two.Display();
                }
            }
            else
            {
                Console.WriteLine("Преобразование не удалось");
            }
        }
        //через as
        void UseOne2(One one)
        {
            Two two = (one as Two);
            if(two != null && two.SomeBool == false)
            {
                two.Display();
            }
            else
            {
                Console.WriteLine("Преобразование не удалось");
            }
        }
        //через try catch
        void UseOne3(One one)
        {
            try
            {
                Two two = (Two)one;
                if(two.SomeBool == false)
                {
                    two.Display();
                }
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Pattern_matching
        void UseOnePatternMathing_As(One one)
        {
            if(one is Two two && two.SomeBool == false)
            {
                two.Display();
            }
            else
            {
                Console.WriteLine("Преобразование не удалось");
            }
        }
        void UseOnePatternMathing_Switch(One one)
        {
            switch (one)
            {
                case Two two when two.SomeBool == false:
                    two.Display();
                    break;
                case null:
                    Console.WriteLine("Объект не задан");
                    break;
                default:
                    Console.WriteLine("Преобразование не удалось");
                    break;
            }
        }
    }
    class One
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual void Display()
        {
            Console.WriteLine("It's One");
        }
        //деконструктор - не путать с деструктором
        //работает минимум с 2 параметрами
        public void Deconstruct(out string name,out int age)
        {
            name = this.Name;
            age = this.Age;
        }
    }
    class Two : One
    {
        public override void Display()
        {
            Console.WriteLine("It's Two");
        }
        public bool SomeBool { get; set; }
    }

}
