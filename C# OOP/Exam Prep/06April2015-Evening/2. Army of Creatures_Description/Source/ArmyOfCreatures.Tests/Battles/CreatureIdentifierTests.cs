namespace ArmyOfCreatures.Tests.Battles
{
    using Logic.Battles;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_ShouldThrowArgumentNullException_WhenPassedNullString()
        {
            // Arrange, Act and Assert
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_ShouldThrowFormatException_WhenPassedInvalidArmyNumber()
        {
            // Arrange
            var fakeIdentifier = "Angel(dve)";

            // Act and Assert
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString(fakeIdentifier));
        }

        [Test]
        public void CreatureIdentifierFromString_ShouldThrowIndexOutOfRangeException_WhenPassedInvalidStringWithNoBrackets()
        {
            // Arrange
            var fakeIdentifier = "Angel1";

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString(fakeIdentifier));
        }

        [Test]
        public void CreatureIdentifierFromString_ShouldOutputCorrectToString_WhenPassedValidArguments()
        {
            // Arrange
            var fakeIdentifierInput = "FakeCreature(1)";

            // Act
            var fakeIdentifier = CreatureIdentifier.CreatureIdentifierFromString(fakeIdentifierInput);

            // Assert
            Assert.AreEqual(fakeIdentifierInput, fakeIdentifier.ToString());
        }
    }
}
