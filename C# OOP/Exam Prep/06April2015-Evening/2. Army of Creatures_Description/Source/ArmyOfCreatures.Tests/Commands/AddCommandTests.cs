namespace ArmyOfCreatures.Tests.Commands
{
    using Console.Commands;
    using Logic.Battles;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_InputNullBattleManager_ShouldThrowArgumentNullException()
        {
            //Arrange
            var command = new AddCommand();
            var stringParams = new string[] { "10", "CyclopsKing(2)" };

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => command.ProcessCommand(null, stringParams));
        }

        [Test]
        public void ProcessCommand_InputNullStringParams_ShouldThrowArgumentNullException()
        {
            //Arrange
            var command = new AddCommand();
            var battleManager = new Mock<IBattleManager>();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => command.ProcessCommand(battleManager.Object, null));
        }

        [Test]
        public void ProcessCommand_InputLessThan2StringParams_ShouldThrowArgumentNullException()
        {
            //Arrange
            var command = new AddCommand();
            var battleManager = new Mock<IBattleManager>();
            var stringParams = new string[] { "10" };

            //Act and Assert
            Assert.Throws<ArgumentException>(() => command.ProcessCommand(battleManager.Object, stringParams));
        }

        [Test]
        public void ProcessCommand_InputValidArguments_ShouldCallAddCreaturesCommand()
        {
            //Arrange
            var command = new AddCommand();
            var battleManager = new Mock<IBattleManager>();
            var stringParams = new string[] { "10", "CyclopsKing(2)" };

            //Act
            command.ProcessCommand(battleManager.Object, stringParams);

            //Assert
            battleManager.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ProcessCommand_InputValidArguments_ShouldCallAddCreaturesCommandWithCorrectCreatureIdentifier()
        {
            //Arrange
            var command = new AddCommand();
            var battleManager = new Mock<IBattleManager>();
            var stringParams = new string[] { "10", "CyclopsKing(2)" };
            var creatureIdentifier = CreatureIdentifier.CreatureIdentifierFromString("CyclopsKing(2)");

            //Act
            command.ProcessCommand(battleManager.Object, stringParams);

            //Assert
            battleManager.Verify(x => x.AddCreatures
            (It.Is<CreatureIdentifier>(p => p.CreatureType == "CyclopsKing" && p.ArmyNumber == 2),
                It.Is<int>(z => z == 10)), Times.Once);
        }
    }
}
