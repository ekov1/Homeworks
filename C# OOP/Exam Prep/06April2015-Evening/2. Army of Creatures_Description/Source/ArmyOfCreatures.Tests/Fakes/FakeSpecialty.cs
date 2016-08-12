namespace ArmyOfCreatures.Tests.Fakes
{
    using Logic.Specialties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Battles;

    public class FakeSpecialty : Specialty
    {
        private bool ApplyOnSkipCalled = false;
        public bool ApplyOnSkipIsCalled
        {
            get
            {
                return this.ApplyOnSkipCalled;
            }
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            this.ApplyOnSkipCalled = true;
        }
    }
}
