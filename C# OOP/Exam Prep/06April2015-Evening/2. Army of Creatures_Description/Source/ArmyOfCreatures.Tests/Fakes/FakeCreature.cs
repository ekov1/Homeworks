namespace ArmyOfCreatures.Tests.Fakes
{
    using Logic.Creatures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FakeCreature : Creature
    {
        private const int FakeAttack = 40;

        private const int FakeDefence = 50;

        private const int FakeHealthPoints = 400;

        private const decimal FakeDamage = 4.0m;

        public FakeCreature()
            :base(FakeAttack, FakeDefence, FakeHealthPoints, FakeDamage)
        {
        }
    }
}
