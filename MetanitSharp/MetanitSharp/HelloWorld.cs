﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.IO;


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
        public static void Write_Massiv(params int[] Input_Massiv)
        {
            foreach (int i in Input_Massiv)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        public static void Write_Massiv(params int[][] Input_Massiv)
        {
            foreach (int[] i in Input_Massiv)
            {
                foreach (int j in i)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Randomize massiv :)
        /// </summary>
        public static void Randomize_Massiv(int[] Input_Massiv)
        {
            Random Rand = new Random();
            for (int i = 0; i < Input_Massiv.Length; i++)
            {
                Input_Massiv[i] = Rand.Next(10);
            }
        }
        public static void Randomize_Massiv(int[] Input_Massiv, int Max)
        {
            Random Rand = new Random();
            for (int i = 0; i < Input_Massiv.Length; i++)
            {
                Input_Massiv[i] = Rand.Next(Max);
            }
        }
        public static void Randomize_Massiv(int[] Input_Massiv, int Min, int Max)
        {
            if (Min > Max)
            {
                Console.WriteLine("Error,Min > Max");
                return;
            }
            Random Rand = new Random();
            for (int i = 0; i < Input_Massiv.Length; i++)
            {
                Input_Massiv[i] = Rand.Next(Min, Max);
            }
        }
        public static void Randomize_Massiv(int[][] Input_Massiv)
        {
            Random Rand = new Random();
            for (int i = 0; i < Input_Massiv.Length; i++)
            {
                for (int j = 0; j < Input_Massiv[i].Length; j++)
                {
                    Input_Massiv[i][j] = Rand.Next(10);
                }
            }
        }
        public static void Randomize_Massiv(int[][] Input_Massiv, int Max)
        {
            Random Rand = new Random();
            for (int i = 0; i < Input_Massiv.Length; i++)
            {
                for (int j = 0; j < Input_Massiv[i].Length; j++)
                {
                    Input_Massiv[i][j] = Rand.Next(Max);
                }
            }
        }
        public static void Randomize_Massiv(int[][] Input_Massiv, int Min, int Max)
        {
            if (Min > Max)
            {
                Console.WriteLine("Error,Min > Max");
                return;
            }
            Random Rand = new Random();
            for (int i = 0; i < Input_Massiv.Length; i++)
            {
                for (int j = 0; j < Input_Massiv[i].Length; j++)
                {
                    Input_Massiv[i][j] = Rand.Next(Min, Max);
                }
            }
        }
        /// <summary>
        /// просто пример использования кортежа
        /// </summary>
        public static (int, int) Turple_Exem()
        {
            var test = (one: 4, two: 7);
            return (test.one, test.two);
        }
    }
    class Safe_Massive_Sort
    {
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
            for (int i = 0; i < Massiv.Length; i++)
            {
                j = i;
                for (int k = i; k < Massiv.Length; k++)
                {
                    if (Massiv[j] > Massiv[k])
                        j = k;
                }
                tmp = Massiv[i];
                Massiv[i] = Massiv[j];
                Massiv[j] = tmp;
            }
        }
        /// <summary>
        /// first - 0 , last - Massiv.Lenght -1
        /// </summary>
        public static void Solo_Quick_Sort(int[] Massiv, int first, int last)
        {
            int Pivot = (Massiv[(first + last) / 2]);
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
    class Person
    {
        private string name;
        private int age;
        private int num;
        public Person() : this("Noname")
        {
        }
        public Person(string name) : this(name,21)
        {
        }
        public Person(int age) : this("Noname", age)
        {
        }
        public Person(string name,int age) : this(name, age, 666)
        {
        }
        public Person(string name, int age,int num)
        {
            this.name = name;
            this.age = age;
            this.num = num;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}  Num: {num}");
        }
    }
    class Hell
    {
        private int num;
        private string name;
        public Hell() { num = 21; name = "lost"; }
        public Hell(int lol) { num = lol; name = "lost"; }
        public Hell(string er) { num = 21; name = er; }
        public Hell(int lol, string er) { num = lol;name = er;}
        public void GetInfo()
        {
            Console.WriteLine($"Name: {name}  Num: {num}");
        }
    }
}
