namespace Cosmetics.Products
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;

    public abstract class Product : IProduct
    {
        private decimal price;
        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string form = String.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10);
                Validator.CheckIfStringLengthIsValid(value, 10, 3, form);
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                string form = String.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10);
                Validator.CheckIfStringLengthIsValid(value, 10, 2, form);
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }

        public GenderType Gender { get; set; }

        public virtual string Print()
        {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            builder.AppendLine(string.Format("  * Price: ${0}", this.Price));
            builder.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return builder.ToString().Trim();
        }
    }
}
