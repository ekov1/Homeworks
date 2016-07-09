namespace FurnitureManufacturer.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.MaterialType = materialType;
            this.Price = price;
            this.Height = height;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value < 0.00m)
                {
                    throw new ArgumentException("Height cannot be less than 0!");
                }
                this.height = value;
            }
        }

        public string Material
        {
            get
            {
                return this.MaterialType.ToString();
            }
            private set
            {
                this.material = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Cannot be null or empty!");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0.00m)
                {
                    throw new ArgumentException("Price cannot be less than 0!");
                }
                this.price = value;
            }
        }

        public MaterialType MaterialType { get; set; }
    }
}
