namespace ArmyOfCreatures.Tests.Extended
{
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;
    using Logic.Creatures;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class CreatureFactoryOverrideTests
    {
        [Test]
        public void CreateCreature_ShouldThrowArgumentExceptionWithMessage_WhenCreateIsNonExisting()
        {
            // Arrange
            var creatureFactory = new CreatureFactoryOverride();

            // Act
            var expectedException = Assert.Throws<ArgumentException>
                (() => creatureFactory.CreateCreature("Slon"));

            // Assert
            Assert.IsTrue(expectedException.Message.Contains("Invalid creature type"));
        }

        //[TestCase("AncientBehemoth")]
        //[TestCase("CyclopsKing")]
        //[TestCase("Griffin")]
        [Test]
        public void CreateCreature_ShouldReturnCorrespondingCreature_WhenInputCreatureExists()
        {
            // Arrange
            var creatureFactory = new CreatureFactoryOverride();
            //var creatureType = Type.GetType(creatureName);
            // Act
            var creature = creatureFactory.CreateCreature("AncientBehemoth");

            // Assert
            //Assert.IsTrue(creature.GetType() == creatureType);
            Assert.IsInstanceOf<AncientBehemoth>(creature);
        }
    }
}
