namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    class Call
    {
        private string date;
        private string time;
        private string phoneNumber;
        private int duration; //in seconds

        public Call(string date, string time, string phoneNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("No such date!");
                }
                this.date = value;
            }
        }
        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("No such time!");
                }
                this.time = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("This phone number could not be a valid phone number!");
                }
                this.phoneNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Negative values are not allowed!");
                }
                this.duration = value;
            }
        }

        

        public override string ToString()
        {
            return $"{this.Date} {this.Time} - {this.PhoneNumber} - {this.Duration}";
        }
    }
}
