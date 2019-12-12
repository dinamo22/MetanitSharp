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
            catch (BitchException2 ex)
            {
                Console.WriteLine(ex.Message);
            }
            int[] massiv = new int[10];
            Test_Massiv.Test_Delegate(massiv);
            Console.WriteLine("for_test");
            Delegate_function.Massiv_func_delegate(massiv, Delegate_function.WriteNumber); //можно передать любую функцию, подходящую под делегат
            Console.WriteLine();
            Delegate_function.Massiv_func_delegate(massiv, x => x > 5); //использование лямбда-выражений
            Console.WriteLine();
            Console.WriteLine();
            Bank_Account Tinkoffe = new Bank_Account(200);
            Tinkoffe.Notify += Tinkoffe.NotifyConsoleOut;
            Tinkoffe.Notify += Tinkoffe.NotifyConsoleOutRed;
            Tinkoffe.Put(150);
            Tinkoffe.Notify -= Tinkoffe.NotifyConsoleOutRed;
            Tinkoffe.Take(300);
            Tinkoffe.Take(100);
            delegati_musor.dlya_vizova();
        }       
    } 
}
