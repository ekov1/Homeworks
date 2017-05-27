using System;

namespace _12.StackImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var stack = new CustomStack<string>();

            stack.Push("test 1");
            stack.Push("test 2");
            stack.Push("test 3");
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
