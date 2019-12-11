using System;

namespace ForExceptions
{
    public class TestWithExceptions
    {
        public static double Delenie(int first,int second)
        {

            try
            {                
            return first / second;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"Возникло исключение! {ex.Message} ");
                Console.WriteLine($"1. {ex.Data}");
                Console.WriteLine($"2. {ex.HelpLink}");
                Console.WriteLine($"3. {ex.InnerException}");
                Console.WriteLine($"4. {ex.Source}");
                Console.WriteLine($"5. {ex.StackTrace}");
                Console.WriteLine($"6. {ex.TargetSite}");
            }
            finally
            {
            
            }
            return 0;
        }
    }
    public class LittleBitch
    {
        public LittleBitch(string Name)
        {
            this.Name = Name;
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 4)
                {
                    throw new BitchException2("Длина имени не может быть короче 4 символов!");
                }
                else name = value;
            }
        }
    }
    public class BitchException : Exception
    {
        public BitchException(string message) : base(message)
        {

        }
    }
    public class BitchException2 : Exception
    {
        public BitchException2(string message) : base(message)
        {

        }
    }
}
