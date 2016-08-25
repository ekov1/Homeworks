namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    class Battery
    {
        private string model;
        private int hrsIdle;
        private int hrsTalk;
        private BatteryType batType;

        public Battery()
        {

        }

        public Battery(string model)
        {
            this.Model = model;
        }

        public Battery(string model, int hrsIdle, int hrsTalk, BatteryType batType) : this(model)
        {
            this.IdleHours = hrsIdle;
            this.TalkingHours = hrsTalk;
            this.BatteryTypes = batType;
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
                    throw new ArgumentException("No such brand of phone!");
                }
                this.model = value;
            }
        }

        public int IdleHours
        {
            get
            {
                return this.hrsIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Idle time can not be a negative number!");
                }
                this.hrsIdle = value;
            }
        }

        public int TalkingHours
        {
            get
            {
                return this.hrsTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Talking hours can not be a negative number!");
                }
                this.hrsTalk = value;
            }
        }

        public BatteryType BatteryTypes
        {
            get
            {
                return this.batType;
            }
            set
            {
                this.batType = value;
            }
        }
    }
}
