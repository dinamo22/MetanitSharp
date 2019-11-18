using System;

namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] Massiv = new int[100000];
            For_Time.Timer_ON();
            Safe_Massive_Sort.Solo_Bubble_Sort(Massiv);
            For_Time.Timer_OFF();
            
        }
    }
}
