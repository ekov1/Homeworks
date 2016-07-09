namespace WarMachines.Machines
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tank : Machine, ITank
    {
        private bool defenceMode;

        public Tank(
            string name,
            IPilot pilot, 
            double attackP, 
            double defenceP, 
            bool defenceMode)
            : base(
                  name,
                  pilot, 
                  attackP, 
                  defenceP
                  )
        {
            this.HealthPoints = 100;
            this.DefenseMode = true;
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenceMode;
            }
            private set
            {
                this.defenceMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            if (this.DefenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            var defenceMode = this.DefenseMode ? "ON" : "OFF";
            builder.AppendLine(String.Format(" *Defense: {0}", defenceMode));

            return builder.ToString().Trim();
        }
    }
}
