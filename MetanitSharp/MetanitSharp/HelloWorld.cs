using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MetanitSharp
{
    class HelloWorld
    {   
       public static void Hello()
        {
            Console.WriteLine("Hello World!");
        }
    }
    class MyName
    {
        static string name = "Noname"; //private
        public static void Himynameis()
        {
            Console.Write("What is your name: ");
            name = Console.ReadLine();
        }
        public static void Mynameis()
        {
            Console.WriteLine(name);
        }
        public static string RetName()
        {
            return name;
        }
    }
    class Test_Massiv
    {
        static int[] Massiv;
        static int[][] DoubleMassiv = new int[3][];
        static readonly int[] Massiv10 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        static Random Rand = new Random();
        public static void Output_massiv10()
        {
            foreach(int i in Massiv10)
            {
                Console.WriteLine(i);
            }
        }
        public static void Numbers_in_massiv(int Numb)
        {
            if (Numb > 0 && Numb < 25)
            {
                Massiv = new int[Numb];
            }
            else
            {
                Console.WriteLine("Длина не больше 25 и не меньше 0");
            }
        }
        public static void Numbers_in_DoubleMassiv(int Numb)
        {
            DoubleMassiv[0] = new int[Numb];
            for (int i = 0; i < 3; i++)
            {
                DoubleMassiv[i] = new int[Numb];
                for(int j = 0; j < Numb; j++)
                {
                    DoubleMassiv[i][j] = Rand.Next(10);
                }
            }
        }
        public static void Output_DoubleMassiv()
        {
            foreach(int[] i in DoubleMassiv)
            {
                foreach(int j in i)
                {
                    Console.Write(j);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
    class Safe_Massive_Sort
    {
        static int[] Solo_Massiv;
        public static int[] Solo_Bubble_Sort_Return(int[] Massiv)
        {
            int temp = 0;
            Solo_Massiv = new int[Massiv.Length];
            Solo_Massiv = Massiv;
            for (int i = 0; i < Solo_Massiv.Length - 1; i++) 
            {
                for(int j = i + 1; j < Solo_Massiv.Length; j++)
                {
                    if (Solo_Massiv[i] > Solo_Massiv[j])
                    {
                        temp = Solo_Massiv[j];
                        Solo_Massiv[j] = Solo_Massiv[i];
                        Solo_Massiv[i] = temp;
                    }
                }
            }
            return Solo_Massiv;
        }
        public static void Solo_Bubble_Sort(int[] Massiv)
        {
            int temp = 0;
            for (int i = 0; i < Massiv.Length - 1; i++)
            {
                for (int j = i; j < Massiv.Length; j++)
                {
                    if (Massiv[i] > Massiv[j])
                    {
                        temp = Massiv[j];
                        Massiv[j] = Massiv[i];
                        Massiv[i] = temp;
                    }
                }
            }
        }
        public static void Solo_Selection_Sort(int[] Massiv)
        {
            int tmp = 0;
            int j = 0;
            for(int i = 0; i < Massiv.Length; i++)
            {
                j = i;
                for(int k = i; k < Massiv.Length; k++)
                {
                    if (Massiv[j] > Massiv[k])
                        j = k;
                }
                tmp = Massiv[i];
                Massiv[i] = Massiv[j];
                Massiv[j] = tmp;
            }
        }
        public static void Solo_Quick_Sort(int[] Massiv, int first, int last)
        {
            int Pivot = (Massiv[(first+last)/2]);
            int b = first, e = last; // те самые прыгающие элементы
            do
            {
                while (Massiv[b] < Pivot) b++; // поиск ближайшего элемента, большего, чем разрешающий
                while (Massiv[e] > Pivot) e--; // меньшего
                if (b <= e)
                {
                    int Temp = Massiv[b];
                    Massiv[b] = Massiv[e];
                    Massiv[e] = Temp;
                    b++;
                    e--;
                }
            } while (b <= e);
            if (e > first) Solo_Quick_Sort(Massiv, first, e);
            if (b < last) Solo_Quick_Sort(Massiv, b, last);
        }
    }
    class For_Time
    {
        private static System.Timers.Timer aTimer;
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time: {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
        public static void Timer_ON()
        {
            SetTimer();
            Console.WriteLine("Timer started at {0:HH:mm:ss.fff}", DateTime.Now);
        }
        public static void Timer_OFF()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}
