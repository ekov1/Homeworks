namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Giant : Character, IFighter, IGatherer
    {
        private bool incrPoints = false;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.DefensePoints = 80;
        }

        public int AttackPoints { get; set; }

        public int DefensePoints { get; set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!incrPoints)
                {
                    this.AttackPoints += 100;
                    incrPoints = true;
                }
                return true;
            }

            return false;
        }
    }
}
