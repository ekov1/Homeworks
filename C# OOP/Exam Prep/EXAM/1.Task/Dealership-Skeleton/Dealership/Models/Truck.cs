namespace Dealership.Models
{
    using Common;
    using Contracts;
    using System;

    public class Truck : Vehicle, ITruck
    {
        private int weightLimit;
        private const int truckWheels = 8;

        public Truck(string make, string model, decimal price, int weightLimit)
            : base(make, model, price)
        {
            this.Wheels = truckWheels;
            this.WeightCapacity = weightLimit;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightLimit;
            }
            protected set
            {
                ValidatorCustom.NumberValdation(value, Constants.MinCapacity, Constants.MaxCapacity, "Weight capacity");

                this.weightLimit = value;
            }
        }
    }
}
