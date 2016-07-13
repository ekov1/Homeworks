namespace Dealership.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Common.Enums;
    using Common;
    using System.Text;
    public abstract class Vehicle : IVehicle
    {
        private string make;
        private string model;
        private int wheels;
        private decimal price;
        private IList<IComment> comments;

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Make"));

                ValidatorCustom.StringValidation(value, Constants.MinMakeLength, Constants.MaxMakeLength
                    , "Make");

                this.make = value;
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
                Validator.ValidateNull(value,
                                    String.Format("{0} cannot be null or empty!", "Model"));

                ValidatorCustom.StringValidation(value, Constants.MinModelLength, Constants.MaxModelLength
                    , "Model");

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                ValidatorCustom.DecimalNumberValidation(value, Constants.MinPrice, Constants.MaxPrice,
                    "Price");

                this.price = value;
            }
        }

        public VehicleType Type { get; protected set; }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {
                ValidatorCustom.NumberValdation(value, Constants.MinWheels, Constants.MaxWheels, "Wheels");

                this.wheels = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(String.Format("  Make: {0}", this.Make));
            builder.AppendLine(String.Format("  Model: {0}", this.Model));
            builder.AppendLine(String.Format("  Wheels: {0}", this.Wheels));

            if (this.Price > 0.0m)
            {
                builder.AppendLine(String.Format("  Price: ${0}", this.Price));
            }
            else
            {
                builder.AppendLine("  Price: $0");
            }

            return builder.ToString();
        }
    }
}
