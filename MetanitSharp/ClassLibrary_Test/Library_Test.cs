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

    //Изначально для тестов с наследованием, позже для понимания работы
    //implicite explicite virtual override new base: this.
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
            primer = new Employe(Name, Boss_is);
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
        public Employee(string Name_is, string Rang_is) : base(Name_is)
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
        public override void Display()
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

    //для теста абстрактных классом(метотов и тд)
    //Позже добавлены обобщенные типы
    abstract public class Footbolist<Info_param>
    {
        public Footbolist(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        abstract public string Name { get; set; }
        abstract public int Age { get; set; }
        abstract public Info_param Info { get; set; }
        abstract public void Display_PlayerInfo();
    }
    public class Footbolist_checks<Info_param> : Footbolist<Info_param>
    {
        public Footbolist_checks(string Name, int Age) : base(Name, Age)
        {

        }
        private string name;
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    Console.WriteLine("Error, name lenght must be < 3 and > 20");
                    name = "Noname";
                }
                else name = value;
            }
        }
        private int age;
        public override int Age
        {
            get => age;
            set
            {
                if (value < 14)
                {
                    Console.WriteLine("Не моложе 14");
                    age = 0;
                }
                else age = value;
            }
        }
        public override void Display_PlayerInfo()
        {
        }
        public override Info_param Info { get; set; }
    }
    public class Goolkeeper : Footbolist_checks<int>
    {
        private int info;
        public override int Info
        {
            get => info;
            set
            {
                if (value < 0) Console.WriteLine("Ошибка, вы ввели отрицательное число");
                else info = value;
            }
        }
        public Goolkeeper(string Name, int Age) : base(Name, Age)
        {
            Info = default;
        }
        public Goolkeeper(string Name, int Age, int Info) : base(Name, Age)
        {
            this.Info = Info;
        }
        public override void Display_PlayerInfo()
        {
            Console.WriteLine($"Вратарь {Name} сыграл в {Info} матчах в возрасте {Age} лет.");
        }
    }
    public class Forward<Info_param> : Footbolist_checks<Info_param>
    {
        private int goals;
        public int Goals { get => goals; set => goals = value; }
        public override Info_param Info { get; set; } = default;
        public Forward(string Name, int Age) : this(Name, Age, default)
        {

        }
        public Forward(string Name, int Age, Info_param Info) : this(Name, Age, Info, 2)
        {

        }
        public Forward(string Name, int Age, Info_param Info, int Goals) : base(Name, Age)
        {
            this.Info = Info;
            this.Goals = Goals;
        }
        public override void Display_PlayerInfo()
        {
            Console.WriteLine($"Нападающий {Name} сыграл в {Info} матчах и забил {Goals} мячей в возрасте {Age}. ");
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    //тесты с делегатами
    public class Delegate_function 
    {
        public delegate void Void_Massiv_function(int numb);
        public delegate bool Bool_Massiv_function(int numb);
        public static void Massiv_func_delegate(int[] massiv,Void_Massiv_function function )
        {
            for(int i = 0; i < massiv.Length; i++)
            {
                function(massiv[i]);
            }
        }
        public static void Massiv_func_delegate(int[] massiv,Bool_Massiv_function function)
        {
            for(int i = 0; i < massiv.Length; i++)
            {
                if (function(massiv[i]))
                {
                    Console.WriteLine(massiv[i]);
                }
            }
        }
        public static void WriteNumber(int numb)
        {
            Console.Write($"{numb} ");
        }
    }

    //тесты с событиями
    public class Bank
    {
        public delegate void BankHandled(string message);
        public event BankHandled Notify;
        public Bank(int sum)
        {
            Sum = sum;
        }
        public int Sum { get; private set; }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет положено {sum} , сумма {Sum}");
        }
        public void Take(int sum)
        {
            if (Sum > sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято {sum}, оставшаяся сумма {Sum}");
            }
            else
            {
                Notify?.Invoke($"Невозможно выполнить операцию, на балансе недостаточно средств");
            }
        }
        //for notify
        public void NotifyConsoleOut(string message)
        {
            Console.WriteLine(message);
        }
        public void NotifyConsoleOutRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    //тест класс данных для события
    public class Bank_Account
    {
        public delegate void BankHandled(object sender,Bank_AccountEvengArgs e);
        public event BankHandled Notify;
        
        public Bank_Account(int sum)
        {
            Sum = sum;
        }
        public int Sum { get; private set; }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke(this, new Bank_AccountEvengArgs(sum,$"На счет положено {sum} , сумма {Sum}"));
        }
        public void Take(int sum)
        {
            if (Sum > sum)
            {
                Sum -= sum;
                Notify?.Invoke(this, new Bank_AccountEvengArgs(sum,$"Со счета снято {sum}, оставшаяся сумма {Sum}"));
            }
            else
            {
                Notify?.Invoke(this,new Bank_AccountEvengArgs(sum,$"Невозможно выполнить операцию, на балансе недостаточно средств"));
            }
        }
        //for notify
        public void NotifyConsoleOut(object sender,Bank_AccountEvengArgs e)
        {
            Console.WriteLine(e.Message);
        }
        public override string ToString()
        {
            return "Bank_Account";
        }
        public void NotifyConsoleOutRed(object sender,Bank_AccountEvengArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Sum);
            Console.WriteLine(sender.ToString());
            Console.ResetColor();
        }
    }
    //тут хранятся данные события
    public class Bank_AccountEvengArgs
    {
        public int Sum { get; }
        public string Message { get; }
        public Bank_AccountEvengArgs(int sum, string message)
        {
            Sum = sum;
            Message = message;
        }
    }
    public class delegati_musor
    {
        public static void Dlya_vizova()
        {
            Adam Eva = new Adam { Name = "Eva" };
            Action<int, int> function = Adam.Function_bolshe_menshe;
            Eva.Adam_func(5, 7, function);
            Eva.Adam_func(7, 5, Adam.Function_bolshe_menshe);
            Predicate<int> predicate = delegate (int x) { return x > 0; };
            bool da = Guts.Age_menshe(6, predicate);
            Func<int> func = Zero_move;
            Func<int, int> func1 = First_move;
            Func<int, int, string> func2 = Second_move;
            ValueTuple<int, int> smth = Third_move(2, 5);
            Console.WriteLine();
        }
        public static int Zero_move()
        {
            return 666;
        }
        public static int First_move(int x)
        {
            return x + 1;
        }
        public static string Second_move(int x, int y)
        {
            return ($"x+y={x + y}, x-y={x - y}");
        }
        public static (int, int) Third_move(int x, int y)
        {
            return (1, 2);
        }
        class Adam
        {
            public string Name { get; set; }
            public void Adam_func(int x, int y, Action<int, int> func)
            {
                func(x, y);
            }
            public static void Function_bolshe_menshe(int x, int y)
            {
                if (x > y) Console.WriteLine($"{x} > {y}");
                else Console.WriteLine($"{x} < {y}");
            }
        }
        class Guts
        {
            public int Age { get; set; }
            public static bool Age_menshe(int x, Predicate<int> func)
            {
                return func(x);
            }
        }
        class Griffith
        {
            public int Age { get; set; }

        }
    }

    public class Somebody
    {
        public Somebody()
        {
            Me me = new Me();
            me.Fortrashfunc();
        }
        delegate R DelegateReturn<out R>();
        delegate void DelegateTake<in T>(T item);
        public class Ones
        {
            public virtual void Display()
            {
                Console.WriteLine("It's \"Ones\"");
            }
        }
        public class Told : Ones
        {
            public override void Display()
            {
                Console.WriteLine("It's \"Told\"");
            }
        }
        public class Me
        {
            public void Fortrashfunc()
            {
                DelegateReturn<Ones> delegateOnesReturn = OnesReturn;
                DelegateReturn<Ones> delegateOnesReturn1 = ToldReturn;
                DelegateReturn<Told> delegateToldReturn = ToldReturn;
                Ones ones = delegateOnesReturn();
                Ones ones1 = delegateOnesReturn1();
                Told ones2 = delegateToldReturn();
                ones.Display();
                ones1.Display();
                ones2.Display();
                DelegateTake<Ones> delegateOnesDisplay = OnesDisplay;
                DelegateTake<Told> delegateOnesDisplay1 = OnesDisplay;
                DelegateTake<Told> delegateToldDisplay = ToldDisplay;
                
            }
            public Ones OnesReturn() => new Ones();
            public Told ToldReturn() => new Told();
            public void OnesDisplay(Ones ones) => ones.Display();
            public void ToldDisplay(Told told) => told.Display();
        }
    }
    public class QuickSorts
    {
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        private static int Partition(int[] massiv, int first, int last)
        {
            int i = first - 1;
            int key = massiv[last];
            for(int j = first; j < last; j++)
            {
                if (massiv[j] <= key) Swap(ref massiv[++i], ref massiv[j]);
            }
            Swap(ref massiv[++i], ref massiv[last]);
            return i; //next key
        }
        /// <summary>
        /// first - 0 , last - Massiv.Lenght -1
        /// </summary>
        public static void QuickSorting(int[] massiv, int first, int last)
        {
            if(first < last)
            {
                int key = Partition(massiv, first, last);
                QuickSorting(massiv, first, key - 1);
                QuickSorting(massiv, key + 1, last);
            }
        }
        /// <summary>
        /// first - 0 , last - Massiv.Lenght -1
        /// </summary>
        public static void LeftRightQuickSort(int[] massiv, int first, int last)
        {
            int middle = massiv[(first + last) / 2];
            int b = first, e = last;
            do
            {
                while (massiv[b] < middle) b++;
                while (massiv[e] > middle) e--;
                if (b <= e)
                {
                    int temp = massiv[e];
                    massiv[e] = massiv[b];
                    massiv[b] = temp;
                    b++;
                    e--;
                }
            } while (b <= e);
            if (e > first) LeftRightQuickSort(massiv, first, e);
            if (b < last) LeftRightQuickSort(massiv, b, last);
        }
        /// <summary>
        /// first - 0 , last - Massiv.Lenght -1
        /// </summary>
        public static void ChangeRandomQuickSort(int[] massiv, int first, int last)
        {
            Random rand = new Random();
            int middle = massiv[rand.Next(first, last)];
            int b = first, e = last;
            do
            {
                while (massiv[b] < middle) b++;
                while (massiv[e] > middle) e--;
                if (b <= e)
                {
                    int temp = massiv[e];
                    massiv[e] = massiv[b];
                    massiv[b] = temp;
                    b++;
                    e--;
                }
            } while (b <= e);
            if (e > first) ChangeRandomQuickSort(massiv, first, e);
            if (b < last) ChangeRandomQuickSort(massiv, b, last);
        }
        public static void BubbleSort(int[] massiv)
        {
            for(int i = massiv.Length-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (massiv[j] < massiv[j + 1])
                    {
                        int temp = massiv[j];
                        massiv[j] = massiv[j + 1];
                        massiv[j + 1] = temp;
                    }
                }
            }
        }

        ///<summary>
        /// first - 0 , last - massiv.Lenght - 1;
        ///</summary>
        public static void MergeSort(int[] massiv, int first, int last)
        {
            mergeSort(massiv, first, last);
            static void merge(int[] arr, int l, int m, int r)
            {
                int i, j, k;
                int n1 = m - l + 1;
                int n2 = r - m;

                /* create temp arrays */
                int[] L = new int[n1];
                int[] R = new int[n2];

                /* Copy data to temp arrays L[] and R[] */
                for (i = 0; i < n1; i++)
                    L[i] = arr[l + i];
                for (j = 0; j < n2; j++)
                    R[j] = arr[m + 1 + j];

                /* Merge the temp arrays back into arr[l..r]*/
                i = 0; // Initial index of first subarray 
                j = 0; // Initial index of second subarray 
                k = l; // Initial index of merged subarray 
                while (i < n1 && j < n2)
                {
                    if (L[i] <= R[j])
                    {
                        arr[k] = L[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = R[j];
                        j++;
                    }
                    k++;
                }

                /* Copy the remaining elements of L[], if there 
                   are any */
                while (i < n1)
                {
                    arr[k] = L[i];
                    i++;
                    k++;
                }

                /* Copy the remaining elements of R[], if there 
                   are any */
                while (j < n2)
                {
                    arr[k] = R[j];
                    j++;
                    k++;
                }
            }
            static void mergeSort(int[] arr, int l, int r)
            {
                if (l < r)
                {
                    // Same as (l+r)/2, but avoids overflow for 
                    // large l and r
                    int m = l + (r - l) / 2;

                    // Sort first and second halves 
                    mergeSort(arr, l, m);
                    mergeSort(arr, m + 1, r);
                    merge(arr, l, m, r);
                }
            }
        }
        ///<summary>
        /// first - 0 , last - massiv.Lenght - 1;
        ///</summary>
        public static void MergeSorting(int[] massiv,int first, int last)
        {
            mergeSorting(massiv, first, last);
            static void mergeSorting(int[]massiv,int l, int r)
            {
                if(l < r)
                {
                    int m = l + (r - l) / 2; // (l + r) / 2
                    mergeSorting(massiv, l, m);
                    mergeSorting(massiv, m + 1, r);
                    merge(massiv, l, m, r);
                }
            }

            static void merge(int[] massiv, int l, int m, int r)
            {
                int i, j, k;
                int n1 = m - l + 1;
                int n2 = r - m;
                int[] L = new int[n1];
                int[] R = new int[n2];
                // перезаписываем массивы
                for (i = 0; i < n1; i++) 
                    L[i] = massiv[l + i];
                for (j = 0; j < n2; j++)
                    R[j] = massiv[m + 1 + j];

                i = 0;
                j = 0;
                k = l;
                
                //записывыаем меньшие, пока один из массивов не закончится
                while(i < n1 && j < n2)
                {
                    if(L[i] < R[j])
                    {
                        massiv[k] = L[i];
                        i++;
                    }
                    else
                    {
                        massiv[k] = R[j];
                        j++;
                    }
                    k++;
                }

                //докидываем остатки с одного из массивов 
                while( i < n1)
                {
                    massiv[k] = L[i];
                    i++;
                    k++;
                }
                while(j< n2)
                {
                    massiv[k] = R[j];
                    j++;
                    k++;
                }
            }
        }
    }
}
