namespace Methods.Utils
{
    using System;
    using System.Collections.Generic;

    public class Calculations
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            double halfPerimeter = (a + b + c) / 2;
            double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return triangleArea;
        }

        public static string ConvertNumberToStringDigit(int number)
        {
            var avaliableDigits = new Dictionary<int, string>()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" }
            };

            if (avaliableDigits[number] is string)
            {
                var parsedNumber = avaliableDigits[number];
                return parsedNumber;
            }
            else
            {
                throw new ArgumentException("There is no such digit");
            }
        }

        public static int GetMaxValue(params int[] elementsArray)
        {
            if (elementsArray == null || elementsArray.Length == 0)
            {
                throw new ArgumentException("Elements array not provided!");
            }

            var currentBiggest = elementsArray[0];

            for (int i = 1; i < elementsArray.Length; i++)
            {
                if (elementsArray[i] > currentBiggest)
                {
                    currentBiggest = elementsArray[i];
                }
            }

            return currentBiggest;
        }

        public static double CalcDistance(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            double distancePowerX = (secondPointX - firstPointX) * (secondPointX - firstPointX);
            double distancePowerY = (secondPointY - firstPointY) * (secondPointY - firstPointY);

            double distanceBetweenPoints = Math.Sqrt(distancePowerX + distancePowerY);

            return distanceBetweenPoints;
        }

        private static void ValidateTriangleSides(double a, double b, double c)
        {
            var areSideValuesNegative = a <= 0 || b <= 0 || c <= 0;
            var isTriangleValid = a + b > c && a + c > b && c + b > a;

            if (!areSideValuesNegative || !isTriangleValid)
            {
                throw new ArgumentException($"Triangle with input values a:{a} b:{b} and c:{c} cannot exist!");
            }
        }
    }
}
