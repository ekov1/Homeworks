namespace Dealership.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Common.Enums;
    using Common;

    public class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private IList<IVehicle> vehicles;
        private Role role;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.vehicles = new List<IVehicle>();

            Role enums = (Role)Enum.Parse(typeof(Role), role);
            this.Role = enums;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Firstname"));

                ValidatorCustom.StringValidation(value, Constants.MinNameLength, Constants.MaxNameLength,
                    "Firstname");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Lastname"));

                ValidatorCustom.StringValidation(value, Constants.MinNameLength, Constants.MaxNameLength,
                    "Lastname");

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Password"));

                Validator.ValidateSymbols(value, Constants.PasswordPattern,
                    String.Format(Constants.InvalidSymbols, "Password"));

                ValidatorCustom.StringValidation(value, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                    "Password");

                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Username"));

                Validator.ValidateSymbols(value, Constants.UsernamePattern,
                    String.Format(Constants.InvalidSymbols, "Username"));

                ValidatorCustom.StringValidation(value, Constants.MinNameLength, Constants.MaxNameLength,
                    "Username");

                this.username = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);

            commentToAdd.Author = this.Username;
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role != Role.Admin)
            {
                if (this.Role != Role.VIP)
                {
                    if (this.Vehicles.Count < Constants.MaxVehiclesToAdd)
                    {
                        this.Vehicles.Add(vehicle);
                    }
                    else
                    {
                        throw new ArgumentException(String.Format(Constants.NotAnVipUserVehiclesAdd, this.Vehicles.Count));
                    }
                }
                else if (this.Role == Role.VIP)
                {
                    this.vehicles.Add(vehicle);
                }
            }
            else
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }
        }

        public string PrintVehicles()
        {
            StringBuilder builer = new StringBuilder();
            var counter = 0;
            builer.AppendLine(String.Format("--USER {0}--", this.Username));

            if (this.Vehicles.Count > 0)
            {
                foreach (var vehicle in this.Vehicles)
                {
                    builer.AppendLine(String.Format("{0}. {1}:", ++counter, vehicle.GetType().Name));
                    builer.AppendLine(String.Format("  Make: {0}", vehicle.Make));
                    builer.AppendLine(String.Format("  Model: {0}", vehicle.Model));
                    builer.AppendLine(String.Format("  Wheels: {0}", vehicle.Wheels));

                    if (vehicle.Price > 0.0m)
                    {
                        builer.AppendLine(String.Format("  Price: ${0}", vehicle.Price));
                    }
                    else
                    {
                        builer.AppendLine("  Price: $0");
                    }

                    if (vehicle.GetType().Name == "Car")
                    {
                        var car = vehicle as Car;
                        builer.AppendLine(String.Format("  Seats: {0}", car.Seats));
                    }
                    else if (vehicle.GetType().Name == "Truck")
                    {
                        var truck = vehicle as Truck;
                        builer.AppendLine(String.Format("  Weight Capacity: {0}t", truck.WeightCapacity));
                    }
                    else if (vehicle.GetType().Name == "Motorcycle")
                    {
                        var motor = vehicle as Motorcycle;
                        builer.AppendLine(String.Format("  Category: {0}", motor.Category));
                    }

                    if (vehicle.Comments.Count > 0)
                    {
                        builer.AppendLine("    --COMMENTS--");
                        foreach (var comment in vehicle.Comments)
                        {
                            builer.AppendLine("    ----------");
                            builer.AppendLine(String.Format("    {0}", comment.Content));
                            builer.AppendLine(String.Format("      User: {0}", comment.Author));
                            builer.AppendLine("    ----------");
                        }
                        builer.AppendLine("    --COMMENTS--");
                    }
                    else
                    {
                        builer.AppendLine("    --NO COMMENTS--");
                    }
                }
            }
            else
            {
                builer.AppendLine("--NO VEHICLES--");
            }

            return builer.ToString().Trim();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author == this.Username)
            {
                vehicleToRemoveComment.Comments.Remove(commentToRemove);
            }
            else
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            return String.Format(Constants.UserToString + ", Role: {3}",
                this.Username, this.FirstName, this.LastName, this.Role).Trim();
        }
    }
}
