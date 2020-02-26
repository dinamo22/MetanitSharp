using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_Test
{
    interface ITest
    {
        static int age = 21;
        const string name = "igor";
        static int GetAge() { return age-10; }
        static int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }

    interface ITest_Interface
    {
        
        void Display() { }
        public string Name { get; set; }
        int Age { get; }
    }
    interface ITest_Interface2
    {
        void Display();
        string Name { get; set; }
        int Age { set; }
    }
    public class Interface_Class : ITest_Interface
    {
        public void Display()
        {
        }
        public string Name { get; set; }
        public int Age { get; }
    }
    public class Interface_Class_2 : ITest_Interface
    {
        void ITest_Interface.Display() { }
        string ITest_Interface.Name { get; set; }
        int ITest_Interface.Age { get; }
        public void smth()
        {
            Console.WriteLine("smth");
        }
        public virtual void smth2()
        {
            Console.WriteLine("smth2");
        }
    }
    public class Interface_Class_3 : Interface_Class_2
    {
        public void aport()
        {

        }
        public new void smth()
        {
            Console.WriteLine("smth3");
        }
        public override void smth2()
        {
            Console.WriteLine("smth4");
        }
    }

    interface IMove
    {
        void Move()
        {
            Console.WriteLine("I move");
        }
    }
    class Car : IMove
    {
        public void Move()
        {
            Console.WriteLine("Car move");
        }
    }
    class Personw : IMove
    {

    }
    
    public class Work_With_Interfaces
    {
        public void Dlya_vizova()
        {
            Console.WriteLine(ITest.age);
            Console.WriteLine(ITest.name);
            int age = ITest.GetAge();
            Console.WriteLine(age);
            ITest.Age = 44;
            age = ITest.Age;
            Console.WriteLine(age);
        }
        public void Dlya_vizova2()
        {
            Interface_Class interface_Class = new Interface_Class();
            Console.WriteLine(interface_Class.Age);
            Console.WriteLine(interface_Class.Name);
        }
        static void ActionMove(IMove move) 
        { 
            move.Move();
        }
        public static void Dlya_vizova3()
        {
            Interface_Class_2 class_2 = new Interface_Class_2();
            class_2.smth();
            class_2.smth2();
            class_2 = new Interface_Class_3();
            class_2.smth();
            class_2.smth2();
            Interface_Class_3 class_3 = new Interface_Class_3();
            class_3.smth();
            class_3.smth2();
            class_3 = (Interface_Class_3)class_2;
            class_3.smth();
            class_3.smth2();
            
            Interface_Class_2 class_4 = new Interface_Class_3();
            class_4.smth();
            class_4.smth2();
            
            Car car = new Car();
            Personw person = new Personw();
            ActionMove(car);
            ActionMove(person);
            IFuncDisplay fun = new IFuncDisplay();
            (fun as IFunc).Display(); 
            (fun as IFunc2).Display();
        }
    }

    interface IFunc
    {
        void Display()
        {
            Console.WriteLine("IFunc");
        }
    }
    interface IFunc2
    {
        void Display()
        {
            Console.WriteLine("IFunc2");
        }
    }
    public class IFuncDisplay : IFunc,IFunc2
    {
        
    }


    class InterfaceObobsheniya
    {
        interface IFace
        {
            int Eyes();
        }
        interface IHands
        {
            int Colvo { get; }
            int Dlina { get; }
        }
        public class Chelovek : IFace, IHands
        {
            public int Eyes()
            {
                return 0;
            }
            public int Colvo { get; }
            public int Dlina { get; }
        }
        class Nedochelovek<T> where T : IFace, IHands, ICloneable
        {
            public int Eyes()
            {
                return 0;
            }
            public int Colvo { get; }
            public int Dlina { get; }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }
        interface IOne<T>
        {
            T TFunc { get; }
        }
        class One<T> : IOne<T>
        {
            public T TFunc { get; set; }
        }
    }

    public class ForICloneable
    {
        public class SomeClass1 : ICloneable
        {
            public SomeClass1()
            {
                Name = "Dima";
                Age = 21;
                SomeClass2_obj = new SomeClass2 { Lenght = 175 };
            }
            public SomeClass1(string name) : this(name, age: 21)
            {
               
            }
            public SomeClass1(string name, int age) : this(name,age,175)
            {
              
            }
            public SomeClass1(string name, int age, int lenght)
            {
                this.Name = name;
                this.Age = age;
                this.SomeClass2_obj = new SomeClass2 { Lenght = lenght };
            }

            public string Name { get; set; }
            public int Age { get; set; }
            public SomeClass2 SomeClass2_obj { get; set; }
            public object Clone()
            {
                SomeClass2 someClass2_obj_copy = new SomeClass2 { Lenght = this.SomeClass2_obj.Lenght };
                return new SomeClass1 { Name = this.Name, Age = this.Age, SomeClass2_obj = someClass2_obj_copy };
            }
            public void Display()
            {
                Console.WriteLine($"{Name} is {Age} old and her/him lenght is {SomeClass2_obj.Lenght} cm");
            }
        }       
        public class SomeClass2
        {
            public int Lenght { get; set; }
        }
    }

    public class ForICompareTo
    {
        public class SomeClass1 : IComparable
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public void Display()
            {
                Console.WriteLine($"{Name} is {Age}");
            }
            public int CompareTo(object o)
            {
                SomeClass1 sc = o as SomeClass1;
                if(sc != null)
                {
                    return this.Name.CompareTo(sc.Name);
                }
                else
                {
                    throw new Exception("Не получается сравнить два класса");
                }
            }
            public int CompareTo(object o,int nothing)
            {
                SomeClass1 sc = o as SomeClass1;
                try
                {
                    return this.Name.CompareTo(sc.Name);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return -1337;
            }
        }
        public class SomeClass2 : IComparable<SomeClass2>
        {
            public int Age { get; set; }
            public void Display()
            {
                Console.WriteLine($"Age is {Age}");
            }
            public int CompareTo(SomeClass2 sc)
            {
                return this.Age.CompareTo(sc.Age);
            }
        }

        public class SomeClass3 : IComparable, IComparer <SomeClass3>
        {
            private int age;
            public int Age
            {
                get => age;
                set => age = value;
            }
            public void Display()
            {
                Console.WriteLine($"{Age}");
            }
            public int CompareTo(object o)
            {
                return 0;
            }
            public int Compare(SomeClass3 first, SomeClass3 second)
            {
                return first.age.CompareTo(second.age); // а так можно? - da
                
            }
        }
    }
}
