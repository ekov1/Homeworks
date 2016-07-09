namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    public class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackP;
        private double defenceP;
        private IList<string> targets;

        public Machine(
            string name, IPilot pilot, double attackP, double defenceP)
        {
            this.Name = name;
            this.Pilot = pilot;
            this.AttackPoints = attackP;
            this.DefensePoints = defenceP;
            this.targets = new List<string>();
        }

        public double AttackPoints
        {
            get
            {
                return this.attackP;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Points cannot be zero or less!");
                }
                this.attackP = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defenceP;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Defence points cannotv be under or zero!");
                }
                this.defenceP = value;
            }
        }

        public double HealthPoints { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be left empty!");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(String.Format("- {0}", this.Name));
            builder.AppendLine(String.Format(" *Type: {0}", this.GetType().Name));
            builder.AppendLine(String.Format(" *Health: {0}", this.HealthPoints));
            builder.AppendLine(String.Format(" *Attack: {0}", this.AttackPoints));
            builder.AppendLine(String.Format(" *Defense: {0}", this.DefensePoints));
            var targets = this.Targets.Count > 0 ? String.Join(", ", this.Targets) : "None";
            builder.AppendLine(String.Format(" *Targets: {0}", targets));

            return builder.ToString().Trim();
        }
    }
}
