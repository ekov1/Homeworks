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
    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int expRounds)
        {
            if (expRounds <= 0 || expRounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }

            this.rounds = expRounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
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
                return currentDamage;
            }

            this.rounds--;
            return currentDamage *= 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", this.GetType().Name, this.rounds);
        }
    }
}
