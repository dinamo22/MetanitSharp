using System;

namespace Additional_opportunities
{
    public class Extension_methods
    {
        string s = "Hello world";
        public int Smth()
        {
            int shit = s.someshit();
            return shit;
        }
    }
    // для работы метода расширения класс и метод должны быть статичны
    // а в качестве параметра принимать конструкцию (this имя_типа название параметра)
    public static class Someshit
    {
        public static int someshit(this String str)
        {
            int i = 0;
            foreach(char c in str)
            {
                if (c == 'l') i++;
            }
            return i;
        }
    }
}
