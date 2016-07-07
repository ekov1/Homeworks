namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Specialties;
    using Logic.Battles;
    using System.Globalization;
    public class AddAttackWhenSkip : Specialty 
    {
        private readonly int attackToAdd;

        public AddAttackWhenSkip(int attackAddition)
        {
            if (attackAddition < 1 || attackAddition > 10)
            {
                throw new ArgumentOutOfRangeException("attackAddition", "attackAddition should be between 1 and 10, inclusive");
            }

            this.attackToAdd = attackAddition;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.attackToAdd;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", this.GetType().Name, this.attackToAdd);
        }
    }
}
