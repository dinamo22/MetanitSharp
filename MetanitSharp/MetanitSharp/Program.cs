using System;
using ClassLibrary_Test;
namespace MetanitSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Goolkeeper Nastya = new Goolkeeper("Nastya", 21);
            Nastya.Display_PlayerInfo();
            Forward<int> Sasha = new Forward<int>("Sanya", 21, Goals: 777, Info: 500);
            Sasha.Display_PlayerInfo();
            Forward<string> Marian = new Forward<string>("Marian", 25,"first");
            Marian.Display_PlayerInfo();
        }
    }
}
