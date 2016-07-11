namespace Dealership.Models
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Car : Vehicle, ICar
    {
        private int seats;
        private const int carWheels = 4;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            this.Wheels = carWheels;
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            protected set
            {
                Validator.ValidateDecimalRange(value, Constants.MinSeats,
                   Constants.MaxSeats, String.Format(Constants.NumberMustBeBetweenMinAndMax,
                  "Seats", Constants.MinSeats
                   , Constants.MaxSeats));

                this.seats = value;
            }
        }
    }
}
