namespace ArmyOfCreatures.Tests.Battles
{
    using Fakes;
    using Logic.Battles;
    using MStest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void DealDamage_ShouldThrowArgumentNullException_WhenPassedNullDefender()
        {
            // Arrange
            var fakeCreature = new FakeCreature();
            var countOfFakeCreatures = 10;
            var creaturesInBattle = new CreaturesInBattle(fakeCreature, countOfFakeCreatures);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => creaturesInBattle.DealDamage(null));
        }

        [Test]
        public void DealDamage_ShouldReturnExpectedResult_WhenPassedValidAttackerAndDefender()
        {
            // Arrange
            var fakeCreature = new FakeCreature();
            var defenderFakeCreature = new FakeCreature();
            var countOfFakeCreatures = 10;
            var attackerCreaturesInBattle = new CreaturesInBattle(fakeCreature, countOfFakeCreatures);
            var defenderCreaturesInBattle = new CreaturesInBattle(defenderFakeCreature, countOfFakeCreatures);
            var privateAttacker = new MStest.PrivateObject(attackerCreaturesInBattle);

            // Act
            attackerCreaturesInBattle.DealDamage(defenderCreaturesInBattle);

            var expectedHitPointsAfterDamage = (defenderCreaturesInBattle.Creature.HealthPoints * countOfFakeCreatures)
                - (decimal)privateAttacker.GetField("lastDamage");
           
            // Assert 
            Assert.AreEqual(expectedHitPointsAfterDamage, defenderCreaturesInBattle.TotalHitPoints);
        }

        [Test]
        public void Skip_ShouldCallApplyOnSkipNumberOfSpecialtyOfCreatureTimes()
        {
            var fakeCreature = new EvenFakerCreature();
            var countOfFakeCreatures = 10;
            var attackerCreaturesInBattle = new CreaturesInBattle(fakeCreature, countOfFakeCreatures);
            var privateAttacker = new MStest.PrivateObject(attackerCreaturesInBattle);

            // Act
            attackerCreaturesInBattle.Skip();
            var specialty = (FakeSpecialty)fakeCreature.Specialties.Last();

            // Assert
            Assert.That(specialty.ApplyOnSkipIsCalled, Is.True);
        }
    }
}
