namespace WarMachines.Machines
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Pilot : IPilot
    {
        private IList<IMachine> machines;
        private string name;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

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

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            var machineCount = this.machines.Count;
            if (machineCount == 0)
            {
                builder.AppendLine(String.Format("{0} - no machines", this.Name));
            }
            else if (machineCount == 1)
            {
                builder.AppendLine(String.Format("{0} - {1} machine", this.Name, machineCount));
            }
            else
            {
                builder.AppendLine(String.Format("{0} - {1} machines", this.Name, machineCount));
            }

            var orderedMachines = machines
                .OrderBy(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var machine in orderedMachines)
            {
                builder.AppendLine(machine.ToString());
            }
            return builder.ToString().Trim();
        }
    }
}
