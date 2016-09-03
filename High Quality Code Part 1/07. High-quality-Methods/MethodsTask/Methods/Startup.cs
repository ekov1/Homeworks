namespace Methods
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Utils;

    public class Startup
    {
        public static void Main()
        {
            MathCalculations();

            StringFormatting();

            StudentAgeOperation();
        }

        private static void StudentAgeOperation()
        {
            var maleBirthDate = "17.03.1992";
            var femaleBirthDate = "03.11.1993";

            Student maleStudent = new Student("Peter", "Ivanov");
            maleStudent.AddBirthdayDate(maleBirthDate);

            Student femaleStudent = new Student("Stella", "Markova");
            femaleStudent.AddBirthdayDate(femaleBirthDate);

            var olderStudent = StudentOperations.GetOlderStudent(maleStudent, femaleStudent);

            ConsoleWriter.Write($"The older from {maleStudent.FirstName} and {femaleStudent.FirstName} is {olderStudent.FirstName}");
        }

        private static void StringFormatting()
        {
            var formatTypes = new char[] { 'f', '%', 'r' };
            var numbers = new double[] { 1.3, 0.75, 2.30 };

            ConsoleWriter.FormatPrintNumber("Format type 'f' -> " + 1.3, 'f');
            ConsoleWriter.FormatPrintNumber("Format type '%' -> " + 0.75, '%');
            ConsoleWriter.FormatPrintNumber("Format type 'r' -> " + 2.30, 'r');
        }

        private static void MathCalculations()
        {
            var triangleArea = Calculations.CalculateTriangleArea(3, 4, 5);
            ConsoleWriter.Write("Triangle area -> " + triangleArea);

            var wordDigit = Calculations.ConvertNumberToStringDigit(5);
            ConsoleWriter.Write("Digit as word -> " + wordDigit);

            var numberArray = new int[] { 5, -1, 3, 2, 14, 2, 3 };
            var maxValue = Calculations.GetMaxValue(numberArray);
            ConsoleWriter.Write("Max array value -> " + maxValue);

            var distance = Calculations.CalcDistance(3, -1, 3, 2.5);
            ConsoleWriter.Write("Distance between points -> " + distance);
        }
    }
}
