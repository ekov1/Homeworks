namespace Methods.Models
{
    using System;
    using Contracts;
    using Utils;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private string birthdayDate;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name must be provided!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name must be provided!");
                }

                this.lastName = value;
            }
        }

        public string BirthdayDate
        {
            get
            {
                return this.birthdayDate;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Additional info cannot be null or empty!");
                }

                this.birthdayDate = value;
            }
        }

        public void AddBirthdayDate(string birthDate)
        {
            var isBirthDateValid = birthDate.Length != 10 || !char.IsDigit(birthDate[0]);

            if (isBirthDateValid)
            {
                throw new ArgumentException("Birth date is not in the required format (dd/mm/yyyy)!");
            }

            this.BirthdayDate = birthDate;
        }
    }
}
