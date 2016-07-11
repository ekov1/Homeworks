namespace Dealership.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Common.Enums;
    using Common;

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
                Validator.ValidateDecimalRange(value, Constants.MinPrice,
                    Constants.MaxPrice, String.Format(Constants.NumberMustBeBetweenMinAndMax,
                    "Price", Constants.MinPrice
                    , Constants.MaxPrice));

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

        
    }
}
