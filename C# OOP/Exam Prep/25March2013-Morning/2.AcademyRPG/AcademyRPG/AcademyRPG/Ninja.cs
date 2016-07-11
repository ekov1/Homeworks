namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ninja : Character, IFighter, IGatherer
    {

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.DefensePoints = int.MaxValue;
            this.AttackPoints = 0;
            this.HitPoints = 1;
        }

        public int AttackPoints { get; set; }

        public int DefensePoints { get; set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var targetHighestHitPoints = availableTargets.Max(target => target.HitPoints);

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner
                    && availableTargets[i].HitPoints == targetHighestHitPoints)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += (resource.Quantity * 2);
                return true;
            }

            return false;
        }
    }
}
