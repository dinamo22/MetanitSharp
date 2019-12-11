using System;
using ClassLibrary_Test;
using ForExceptions;

namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LittleBitch Spark = new LittleBitch("pat");
            }
            catch(BitchException2 ex)
            {
                Console.WriteLine(ex.Message);
            }
            int[] massiv = new int[10];
            Test_Massiv.Test_Delegate(massiv);
            Console.WriteLine("for_test");
        }
    }
}
