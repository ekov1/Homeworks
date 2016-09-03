namespace CohesionAndCoupling
{
    using System;
    using Models;
    using Utils;

    public class Startup
    {
        public static void Main()
        {
            FileExtensionExamples();

            FigureCalculation2DExamples();

            FigureCalculations3DExamples();
        }

        private static void FileExtensionExamples()
        {
            Console.WriteLine(FileExtensions.GetFileExtension("example"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensions.GetFileNameWithoutExtension("example.new.pdf"));
        }

        private static void FigureCalculation2DExamples()
        {
            var distance = _2DFigureCalculations.CalcDistance2D(1, -2, 3, 4);
            Console.WriteLine("Distance in the 2D space = {0:f2}", distance);

            var figureWidth = 20.3;
            var figureHeight = 10.2;

            var figure2D = new Figure(figureWidth, figureHeight);
            var diagonal = _2DFigureCalculations.CalcDiagonal2D(figure2D);

            Console.WriteLine("Diagonal XY = {0:f2}", diagonal);
        }

        private static void FigureCalculations3DExamples()
        {
            var distance = _3DFigureCalculations.CalculateDistance3D(5, 2, -1, 3, -6, 4);
            Console.WriteLine("Distance in the 3D space = {0:f2}", distance);

            var figureWidth = 20.3;
            var figureHeight = 10.2;
            var figureDepth = 5.6;

            var figure3D = new Figure3D(figureWidth, figureHeight, figureDepth);
            var volume = _3DFigureCalculations.CalculateVolume(figure3D);
            var diagonal = _3DFigureCalculations.CalculateDiagonal3D(figure3D);

            Console.WriteLine("Volume = {0:f2}", volume);
            Console.WriteLine("Diagonal XYZ = {0:f2}", diagonal);
        }
    }
}
