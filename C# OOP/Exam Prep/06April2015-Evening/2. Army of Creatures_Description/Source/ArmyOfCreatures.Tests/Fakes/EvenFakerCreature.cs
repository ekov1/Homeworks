namespace ArmyOfCreatures.Tests.Fakes
{
    using Logic.Creatures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EvenFakerCreature : Creature
    {
        private const int FakeAttack = 60;

        private const int FakeDefence = 60;

        private const int FakeHealthPoints = 120;

        private const decimal FakeDamage = 20.0m;

        public EvenFakerCreature()
            :base(FakeAttack, FakeDefence, FakeHealthPoints, FakeDamage)
        {
            this.AddSpecialty(new FakeSpecialty());
            this.AddSpecialty(new FakeSpecialty());
            this.AddSpecialty(new FakeSpecialty());
        }
    }
}
