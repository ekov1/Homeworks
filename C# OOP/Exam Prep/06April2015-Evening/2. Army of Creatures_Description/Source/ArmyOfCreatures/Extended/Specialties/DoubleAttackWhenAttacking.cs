namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Battles;
    using Logic.Specialties;
    using System.Globalization;
    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int expRounds)
        {
            if (expRounds <= 0)
            {
                throw new ArgumentException("rounds", "The number of rounds should be greater than 0");
            }
            this.rounds = expRounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("attacker");
            }

            if (this.rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", this.GetType().Name, this.rounds);
        }
    }
}
