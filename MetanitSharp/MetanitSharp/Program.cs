using System;
using ClassLibrary_Test;
using ForExceptions;
using Additional_opportunities;

namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massiv = new int[10000];
            Test_Massiv.Randomize_Massiv(massiv, 0, 10000);
            massiv.QuickSort(0, 9999);
            Bank_employee Peter = new Bank_employee("Peter");
            Peter.DoShit?.DoSomeShit();
            Peter.DoShit = new DoWork();
            Peter.DoShit?.DoSomeShit();
            Peter.DoShit = new DoWash();
            Peter.DoShit?.DoSomeShit();
            
        }
    }
    public static class QuickSortTry
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static int Partition(int[] massiv, int first, int last)
        {
            int i = first - 1;
            int key = massiv[last];
            for (int j = first; j < last; j++)
            {
                if (massiv[j] <= key) Swap(ref massiv[++i], ref massiv[j]);
            }
            Swap(ref massiv[++i], ref massiv[last]);
            return i;
        }
        public static void QuickSort(this int[] massiv, int first, int last)
        {
            if (first < last)
            {
                int key = Partition(massiv, first, last);
                QuickSort(massiv, first, key - 1);
                QuickSort(massiv, key + 1, last);
            }
        }
        public static void LeftRightQuickSort(this int[] massiv, int first, int last)
        {
            int middle = massiv[first + (last - first) / 2];
            int b = first, e = last;
            do
            {
                while (massiv[b] < middle) b++;
                while (massiv[e] > middle) e--;
                if (b <= e)
                {
                    int temp = massiv[b];
                    massiv[b] = massiv[e];
                    massiv[e] = temp;
                    b++;
                    e--;
                }
            } while (b <= e);
            if (e > first) LeftRightQuickSort(massiv, first, e);
            if (b < last) LeftRightQuickSort(massiv, b, last);
        }
    }

    public interface IDoSomeShit
    {
        void DoSomeShit();
    }
    public class DoWork : IDoSomeShit
    {
        public void DoSomeShit()
        {
            Console.WriteLine("I do work");
        }
    }
    public class DoWash : IDoSomeShit
    {
        public void DoSomeShit()
        {
            Console.WriteLine("I wash, do you see that?");
        }
    }

    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
    }
    public class Bank_employee : IPerson
    {
        public Bank_employee() : this("NoName", 999) { }
        public Bank_employee(int age) : this("NoName", age) { }
        public Bank_employee(string name) : this(name, 999) { }
        public Bank_employee(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public IDoSomeShit DoShit;
        public string Name { get; private set; }
        public int Age { get; private set; }

    }
}