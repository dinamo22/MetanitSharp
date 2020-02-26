using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_opportunities
{
    class AnonymousType
    {
        void NewAnonymousTypes()
        {
            var user = new { Name = "Dmitry", Age = 21 };
            var user2 = new { Name = "Smth2", Age = 55 };
            var user3 = new { Lulw = 22 };
            Console.WriteLine(user.GetType());  // anonymous type 0
            Console.WriteLine(user2.GetType()); // anonymous type 0
            Console.WriteLine(user3.GetType()); // anonymous type 1
            var user4 = user;
            Console.WriteLine(user4.GetType()); // anonymous type 0
        }
        //иницилизаторы с проекцией
        void Projection_initializers()
        {
            For_Projection_initializers Tom = new For_Projection_initializers { Name = "Tom" };
            int age = 21;
            var user = new { Tom.Name, age };
            Console.WriteLine(user.Name, user.age);
        }
        //массив анонимых типов
        void Anonymous_massiv()
        {
            var peoples = new[]
            {
                new { Name = "Tom" },
                new { Name = "Bob" }
            };
            foreach (var p in peoples)
            {
                Console.WriteLine(p.Name);
            }
        }
    }

    public class For_Projection_initializers
    {
        public string Name { get; set; }
    }
}
