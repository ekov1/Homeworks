namespace Dealership.Models
{
    using Common;
    using Contracts;
    using System;

    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;
        private const int motorWheels = 2;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Wheels = motorWheels;
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            protected set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Category"));

                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength,
                    Constants.MaxCategoryLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, "Category",
                     Constants.MinCategoryLength
                    , Constants.MaxCategoryLength));

                this.category = value;
            }
        }
    }
}
