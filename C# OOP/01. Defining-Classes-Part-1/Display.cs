namespace MobileDevice
{
    using System;

    class Display
    {
        private int displaySize;
        private int colorsNum;

        public Display()
        {

        }
        public Display(int displaySize, int colorsNum) : this(displaySize)
        {
            this.ColorsNumber = colorsNum;
        }
        public Display(int displaySize)
        {
            this.Size = displaySize;
        }

        public int Size
        {
            get
            {
                return this.displaySize;
            }
            set
            {
                if (value <= 0 || value > 1000)
                {
                    throw new ArgumentException("No such size number of phone");
                }
                this.displaySize = value;
            }
        }

        public int ColorsNumber
        {
            get
            {
                return this.colorsNum;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of colors on the phone cannot be a negative number");
                }
                this.colorsNum = value;
            }
        }
    }
}
