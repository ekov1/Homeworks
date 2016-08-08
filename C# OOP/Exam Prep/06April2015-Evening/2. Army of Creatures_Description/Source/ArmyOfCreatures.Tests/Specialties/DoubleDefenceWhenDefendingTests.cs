namespace ArmyOfCreatures.Tests.Specialties
{
    using Logic.Battles;
    using Logic.Creatures;
    using Logic.Specialties;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class DoubleDefenceWhenDefendingTests
    {
        [Test]
        public void ApplyWhenDefending_InputNullDefenderWithSpecialty_ShouldThrowArgumentNullException()
        {
            //Arrange
            var effectRounds = 5;
            var doubleDefence = new DoubleDefenseWhenDefending(effectRounds);
            var attacker = new Mock<ICreaturesInBattle>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
            doubleDefence.ApplyWhenDefending(null, attacker.Object));
        }

        [Test]
        public void ApplyWhenDefending_InputNullAttacker_ShouldThrowArgumentNullException()
        {
            //Arrange
            var effectRounds = 5;
            var doubleDefence = new DoubleDefenseWhenDefending(effectRounds);
            var defender = new Mock<ICreaturesInBattle>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
            doubleDefence.ApplyWhenDefending(defender.Object, null));
        }

        [Test]
        public void ApplyWhenDefending_WhenEffectIsExpired_ShouldNotChangeCurrentDefenceOfDefender()
        {
            //Arrange
            var effectRounds = 1;
            var defencePoints = 500;
            var doubleDefence = new DoubleDefenseWhenDefending(effectRounds);
            var defender = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();

            //Act 

            defender.SetupGet(x => x.CurrentDefense).Returns(defencePoints);
            defender.SetupSet(x => x.CurrentDefense = It.IsAny<int>());

            doubleDefence.ApplyWhenDefending(defender.Object, attacker.Object);
            doubleDefence.ApplyWhenDefending(defender.Object, attacker.Object);

            //Assert
            defender.VerifySet(x => x.CurrentDefense =
            It.Is<int>(z => z == defencePoints * 2), Times.Exactly(1));
        }

        [Test]
        public void ApplyWhenDefending_WhenEffectIsNotExpired_ShouldChangeCurrentDefenceOfDefender()
        {
            //Arrange
            var effectRounds = 3;
            var defencePoints = 500;
            var doubleDefence = new DoubleDefenseWhenDefending(effectRounds);
            var defender = new Mock<ICreaturesInBattle>();
            var attacker = new Mock<ICreaturesInBattle>();
            defender.SetupGet(x => x.CurrentDefense).Returns(defencePoints);
            defender.SetupSet(x => x.CurrentDefense = It.IsAny<int>());

            //Act 
            doubleDefence.ApplyWhenDefending(defender.Object, attacker.Object);
            doubleDefence.ApplyWhenDefending(defender.Object, attacker.Object);
            doubleDefence.ApplyWhenDefending(defender.Object, attacker.Object);

            //Assert
            defender.VerifySet(x => x.CurrentDefense =
            It.Is<int>(z => z == defencePoints * 2), Times.Exactly(effectRounds));
        }
    }
}
