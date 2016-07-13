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
                ValidatorCustom.NumberValdation(value, Constants.MinSeats, Constants.MaxSeats,
                    "Seats");

                this.seats = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(base.ToString());
            builder.AppendLine(String.Format("  Seats: {0}", this.Seats));

            return builder.ToString();
        }
    }
}
