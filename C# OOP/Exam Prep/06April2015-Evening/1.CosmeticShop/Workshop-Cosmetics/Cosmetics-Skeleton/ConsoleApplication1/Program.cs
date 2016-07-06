using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = 0.00M;
            Console.WriteLine(a);
            string moneyValue = String.Format("{0:C}", a);

        }
    }
}
