namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private decimal initHeight;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.initHeight = height;
        }
        public bool IsConverted { get; set; }

        public void Convert()
        {

            if (this.IsConverted == false)
            {
                this.Height = 0.10m;
                this.IsConverted = true;
            }
            else
            {
                this.Height = initHeight;
                this.IsConverted = false;
            }
        }

        public override string ToString()
        {
            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price > 0 ? this.Price : 0, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal").Trim();
        }
    }
}
