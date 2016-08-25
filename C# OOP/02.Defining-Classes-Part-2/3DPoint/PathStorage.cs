namespace _3DPoint
{
    using System;
    using System.IO;
    using System.Linq;

    public class PathStorage
    {
        private static string pathStorage = Directory.GetCurrentDirectory() + "\\text.txt";

        static PathStorage()
        {
            pathStorage = Directory.GetCurrentDirectory() + "\\text.txt";
        }

        private static void SavePath()
        {
            var writer = new StreamWriter(pathStorage, false);
            Random randomGen = new Random();

            if (!File.Exists(pathStorage))
            {
                File.CreateText(pathStorage);
            }

            using (writer)
            {
                for (int i = 0; i < 20; i++)
                {
                    int xCoord = randomGen.Next(-100, 100);
                    int yCoord = randomGen.Next(-100, 100);
                    int zCoord = randomGen.Next(-100, 100);

                    writer.WriteLine("{{{0}, {1}, {2}}}", xCoord, yCoord, zCoord);
                }
            }
        }

        public static void LoadPath()
        {
            PathStorage.SavePath();

            StreamReader reader = new StreamReader(pathStorage);
            string line;

            using (reader)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var separators = new char[] { ' ', ',', '{', '}', '(', ')' };
                    var pointArray = line.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToArray();

                    double X = pointArray[0];
                    double Y = pointArray[1];
                    double Z = pointArray[2];

                    Path.AddPoint(new Point3D(X, Y, Z));
                }
            }
        }
    }
}