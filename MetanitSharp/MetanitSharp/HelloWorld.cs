using System;
using System.Collections.Generic;
using System.Text;

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
}
