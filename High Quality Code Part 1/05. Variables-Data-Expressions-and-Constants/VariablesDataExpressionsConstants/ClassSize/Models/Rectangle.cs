namespace ClassSize.Models
{
    using System;
    using Contracts;

    public class Rectangle : ISize
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be equal or less than zero!");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be equal or less than zero!");
                }
                this.height = value;
            }
        }

        /// <summary>
        /// Rotates a size by a rotation angle
        /// </summary>
        /// <param name="size">The initial size</param>
        /// <param name="rotationAngle">The rotation angle, which rotates the size</param>
        /// <returns>Returns the rotated size</returns>
        public static Rectangle GetRotatedSize(ISize size, double rotationAngle)
        {
            double rotationAngleSinus = Math.Abs(Math.Sin(rotationAngle));
            double rotationAngleCosinus = Math.Abs(Math.Cos(rotationAngle));

            double widthAfterRotation = rotationAngleCosinus * size.Width + rotationAngleSinus * size.Height;
            double heightAfterRotation = rotationAngleSinus * size.Width + rotationAngleCosinus * size.Height;

            var newSize = new Rectangle(widthAfterRotation, heightAfterRotation);
            return newSize;
        }

        public override string ToString()
        {
            var width = this.Width.ToString("0.00");
            var height = this.Height.ToString("0.00");

            var toString = String.Format($"The size has width {width} and height {height} !");

            return toString;
        }
    }
}
