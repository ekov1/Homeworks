namespace WarMachines.Machines
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Fighter : Machine, IFighter
    {
        private bool stealthMode;

        public Fighter(
            string name,
            IPilot pilot,
            double attackP,
            double defenceP,
            bool stealthMode)
            : base(
                  name,
                  pilot,
                  attackP, 
                  defenceP
                  )
        {
            this.HealthPoints = 200;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
            private set
            {
                this.stealthMode = value;
            }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            var stealthMode = this.StealthMode ? "ON" : "OFF";
            builder.AppendLine(String.Format(" *Stealth: {0}", stealthMode));

            return builder.ToString().Trim();
        }
    }
}
