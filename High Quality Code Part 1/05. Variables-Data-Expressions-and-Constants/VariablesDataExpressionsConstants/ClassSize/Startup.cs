namespace ClassSize
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            double initialSizeWidth = 54.5;
            double initialSizeHeight = 20.3;

            var initialSize = new Size(initialSizeWidth, initialSizeHeight);
            Console.WriteLine(initialSize);

            var rotationAngle = 30;
            var rotatedSize = Size.GetRotatedSize(initialSize, rotationAngle);
            Console.WriteLine(rotatedSize);
        }
    }
}
