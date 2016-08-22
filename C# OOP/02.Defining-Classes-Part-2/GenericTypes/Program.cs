namespace GenericTypes
{
    using System;

    class Program
    {
        static void Main()
        {
            var list = new GenericList<int>(5);
            list.AddElement(1);
            list.AddElement(2);
            list.AddElement(-7);
            list.AddElement(4);
            list.AddElement(5);
            list.AddElement(100);

            Console.WriteLine(list);
           
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
        }
    }
}
