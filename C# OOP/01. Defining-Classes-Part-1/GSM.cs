namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    class GSM
    {
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery;
        private Display display;


        public static GSM iphone4s = new GSM("Iphone4S", "Apple")
        {
            Price = 150,
            Owner = "Steve Jobs",
            BatteryModel = "someModel",
            BatteryIdleTime = 10,
            BatteryTalkingHours = 10,

            DisplaySize = 14,
            DisplayColor = 500000
        };
        public GSM()
        {

        }
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.manufacturer = manufacturer;

            this.battery = new Battery();
            this.display = new Display();
        }

        public GSM(string model, string manufacturer, double price, string owner,
             string batModel, int hrsIdle, int hrsTalk, BatteryType batType,
             int displaySize, int colorsNum)
            : this(model, manufacturer)
        {
            this.price = price;
            this.owner = owner;

            this.BatteryModel = batModel;
            this.BatteryIdleTime = hrsIdle;
            this.BatteryTalkingHours = hrsTalk;
            this.BatteryType = batType;

            this.DisplaySize = displaySize;
            this.DisplayColor = colorsNum;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("There is no such model of a phone!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("There is no such manufacturer of phones!");
                }
                this.manufacturer = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price cannot be a negative number!");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value.Length < 2 || value.Length > 1000)
                {
                    throw new ArgumentException("Owner name too long for a real name to exist");
                }
                this.owner = value;
            }
        }
        public string BatteryModel
        {
            get
            {
                return this.battery.Model;
            }
            set
            {
                this.battery.Model = value;
            }
        }
        public int BatteryIdleTime
        {
            get
            {
                return this.battery.IdleHours;
            }
            set
            {
                this.battery.IdleHours = value;
            }
        }

        public int BatteryTalkingHours
        {
            get
            {
                return this.battery.TalkingHours;
            }
            set
            {
                this.battery.TalkingHours = value;
            }
        }

        public int DisplaySize
        {
            get
            {
                return this.display.Size;
            }
            set
            {
                this.display.Size = value;
            }
        }

        public int DisplayColor
        {
            get
            {
                return this.display.ColorsNumber;
            }
            set
            {
                this.display.ColorsNumber = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.battery.BatteryTypes;
            }
            set
            {
                this.battery.BatteryTypes = value;
            }
        }

        public List<Call> CallHistory { get; set; }

        public static void DisplayCallHistory(List<Call> calls)
        {
            Console.WriteLine("Call History");
            Console.WriteLine(new string('=', 60));
            for (int i = 0; i < calls.Count; i++)
            {
                Console.WriteLine(string.Join(" ", calls[i]));
            }
        }

        public void AddCall(string date, string time, string number, int duration)
        {
            this.CallHistory.Add(new Call(date, time, number, duration));
        }

        public List<Call> RemoveCall(Call call)
        {
            this.CallHistory.Remove(call);
            return new List<Call>(CallHistory);
        }

        public List<Call> ClearCallHistory()
        {
            this.CallHistory.Clear();
            return new List<Call>(this.CallHistory);
        }

        public static double CallsPrice(List<Call> calls, double price)
        {
            int duration = 0;
            for (int i = 0; i < calls.Count; i++)
            {
                duration += calls[i].Duration;
            }
            double totalPrice = duration * price;
            return totalPrice;
        }

        public override string ToString()
        {
            return $"Model: --> {this.Model} \nManufacturer: --> {this.Manufacturer}\nPrice: --> {this.Price}\nOwner --> {this.Owner}\nBattery model: --> {this.BatteryModel}\nBattery idle time: --> {this.BatteryIdleTime}\nBattery talking hours: --> {this.BatteryTalkingHours}\nBattery type: --> {this.BatteryType}\nDisplay size: --> {this.DisplaySize}\nDisplay color: --> {this.DisplayColor}\n";
        }
    }
}
