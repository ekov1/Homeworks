namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Knight : Character, IFighter
    {

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 100;
            this.DefensePoints = 100;
            this.AttackPoints = 100;
        }

        public int AttackPoints { get; set; }

        public int DefensePoints { get; set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 &&
                    this.Owner != availableTargets[i].Owner)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
