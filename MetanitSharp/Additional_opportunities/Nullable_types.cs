using System;
using System.Collections.Generic;
using System.Text;

namespace Additional_opportunities
{
    //в кратце - значение null могут принимать только ссылочные типы
    //однако бывает удобно, когда значимые типы принимают null, например в БД
    //для этого существует структура Nullable
    class Nullable_types
    {
        public void dlya_vizova()
        {
            int? Something1 = null;
            bool? enable1 = null;

            Nullable<int> Something2 = null;
            Nullable<bool> enable2 = null;
            if (Something1.HasValue) Console.WriteLine(Something1.Value);
            if (Something2.HasValue) Console.WriteLine(Something2.Value);
            if (enable1.HasValue) enable2 = enable1;

            //вот пример для структуры
            SomeStructForNullable? someStruct = new SomeStructForNullable { Name = "Asya" };
            if (someStruct.HasValue) Console.WriteLine(someStruct.Value.Name);

            //преобразования стандартно
            int? x1 = 5;
            int x2 = (int)x1;
            int y1 = 4;
            int? y2 = y1;
            int? z1 = 2;
            double? z2 = z1;
            double w1 = 3;
            int? w2 = (int?)w1;
        }
    }
    public struct SomeStructForNullable
    {
        public string Name { get; set; }
    }
}
