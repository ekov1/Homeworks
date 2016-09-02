namespace _04.Batman
{
    using System;

    public class Startup
    {
        /// <summary>
        /// Creates a Batman sign with size and character or the sign
        /// </summary>
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char drawChar = char.Parse(Console.ReadLine());
            int wingHeight = size - ((size + 3) / 2);

            DrawWings(size, drawChar, wingHeight);

            DrawEars(size, drawChar, wingHeight);

            DrawMiddlePart(size, wingHeight, drawChar);

            DrawLowerPartTriangle(size, drawChar);
        }

        public static void DrawWings(int size, char drawChar, int wingHeight)
        {
            var middleGap = MakeEmptyString(size);

            for (int i = 0; i < wingHeight; i++)
            {
                var wings = MakeString(drawChar, size - i);
                var gapBefore = MakeEmptyString(i);

                Console.WriteLine("{0}{1}{2}{1}", gapBefore, wings, middleGap, wings);
            }
        }

        public static void DrawEars(int size, char drawChar, int wingHeight)
        {
            string gapBefore = MakeEmptyString(wingHeight);
            string batEars = MakeString(drawChar, 1) + MakeEmptyString(1) + MakeString(drawChar, 1);
            string emptySpaceAroundEars = MakeEmptyString((size - 3) / 2);
            string wingsAroundEars = MakeString(drawChar, size - wingHeight);

            Console.WriteLine("{0}{1}{2}{3}{2}{1}", gapBefore, wingsAroundEars, emptySpaceAroundEars, batEars);
        }

        public static void DrawMiddlePart(int size, int wingHeight, char drawChar)
        {
            string gapBefore = MakeEmptyString(wingHeight + 1);
            int middlePartHeight = size / 3;
            string middlePart = MakeString(drawChar, (2 * size) + 1);

            for (int i = 0; i < middlePartHeight; i++)
            {
                Console.WriteLine(gapBefore + middlePart);
            }
        }

        public static void DrawLowerPartTriangle(int size, char drawChar)
        {
            int whiteSpaceBefore = size + 1;
            int triangleLength = size - 2;

            while (triangleLength > 0)
            {
                var gapBefore = MakeEmptyString(whiteSpaceBefore);
                var trianglePart = MakeString(drawChar, triangleLength);

                Console.WriteLine(gapBefore + trianglePart);

                whiteSpaceBefore++;
                triangleLength -= 2;
            }
        }

        public static string MakeString(char drawChar, int repeatCount)
        {
            return new string(drawChar, repeatCount);
        }

        public static string MakeEmptyString(int repeatCount)
        {
            return new string(' ', repeatCount);
        }
    }
}
