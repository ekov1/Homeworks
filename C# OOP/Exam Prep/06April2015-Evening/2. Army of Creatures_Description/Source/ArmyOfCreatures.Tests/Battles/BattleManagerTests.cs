namespace ArmyOfCreatures.Tests.Battles
{
    using ArmyOfCreatures.Extended;
    using Fakes;
    using Logic;
    using Logic.Battles;
    using Moq;
    using NUnit.Framework;
    using System;
    using Moq.Protected;

    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void AddCreatures_ShouldthrowArgumentNullException_WhenIdentifierIsNull()
        {
            // Arrange
            var creaturesCount = 15;

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() =>
            battleManager.AddCreatures(null, creaturesCount));
        }

        [Test]
        public void AddCreatures_ShouldCallCreateCreatureCommand_WhenInputArgumentsAreValid()
        {
            // Arrange
            var creaturesCount = 15;
            var fakeCreatureType = "Fake";

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(1)");
            factory.Setup(x => x.CreateCreature(fakeCreatureType)).Returns(new FakeCreature());

            // Act 
            battleManager.AddCreatures(identifier, creaturesCount);

            // Assert
            factory.Verify(x => x.CreateCreature(fakeCreatureType), Times.Once);
        }

        [Test]
        public void AddCreatures_ShouldCallWriteLineFromLogger_WhenInputArgumentsAreValid()
        {
            // Arrange
            var creaturesCount = 15;
            var fakeCreatureType = "Fake";

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(1)");
            factory.Setup(x => x.CreateCreature(fakeCreatureType)).Returns(new FakeCreature());

            // Act 
            battleManager.AddCreatures(identifier, creaturesCount);

            // Assert
            logger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddCreatures_ShouldThrowArgumentException_WhenArmyNumberIsInvalid()
        {
            // Arrange
            var creaturesCount = 15;
            var fakeCreatureType = "Fake";

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(3)");
            factory.Setup(x => x.CreateCreature(fakeCreatureType)).Returns(new FakeCreature());

            // Act and Assert
            Assert.Throws<ArgumentException>(() => battleManager.AddCreatures(identifier, creaturesCount));
        }


        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenAttackerIdentifierIsNull()
        {
            // Arrange
            var firstFakeCreatureType = "FakeCreature";
            var creaturesCount = 5;

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString(firstFakeCreatureType + "(1)");
            factory.Setup(x => x.CreateCreature(firstFakeCreatureType)).Returns(new FakeCreature());

            // Act 
            battleManager.AddCreatures(defenderIdentifier, creaturesCount);

            // Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.Attack(null, defenderIdentifier));
        }

        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenDefenderIdentifierIsNull()
        {
            // Arrange
            var firstFakeCreatureType = "FakeCreature";
            var creaturesCount = 5;

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString(firstFakeCreatureType + "(1)");
            factory.Setup(x => x.CreateCreature(firstFakeCreatureType)).Returns(new FakeCreature());

            // Act 
            battleManager.AddCreatures(attackerIdentifier, creaturesCount);

            // Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.Attack(attackerIdentifier, null));
        }

        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenTheUnitIsNoSuchUnitInArmy()
        {
            // Arrange
            var firstFakeCreatureType = "FakeCreature";

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManager = new BattleManager(factory.Object, logger.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString(firstFakeCreatureType + "(1)");
            factory.Setup(x => x.CreateCreature(firstFakeCreatureType)).Returns(new FakeCreature());

            // Act
            var expectedException = Assert.Throws<ArgumentException>(() => battleManager.Attack(attackerIdentifier, null));

            Assert.That(() => 
            battleManager.Attack(attackerIdentifier, null), 
            Throws.Exception.With.Message.Contains("Attacker not found"));
            // Assert
            Assert.IsTrue(expectedException.Message.Contains("Attacker not found:"));
        }

        [Test]
        public void Attack_ShouldCallLoggerWriteLine4Times_WhenAttackingSuccessfully()
        {
            // Arrange
            var fakeCreatureType = "FakeCreature";

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();

            var attacker = new Mock<ICreaturesInBattle>();
            attacker.Setup(x => x.Creature).Returns(new FakeCreature());

            var defender = new Mock<ICreaturesInBattle>();
            defender.Setup(x => x.Creature).Returns(new FakeCreature());

            var fakeBattleManager = new BattleManagerFake(factory.Object, logger.Object, attacker.Object, defender.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(2)");

            // Act 
            fakeBattleManager.Attack(attackerIdentifier, defenderIdentifier);

            // Assert  
            logger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void Attack_ShouldCallLoggerWriteLine4TimesWithCorrectMessages_WhenAttackingSuccessfully()
        {
            // Arrange
            var fakeCreatureType = "FakeCreature";

            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            logger.Setup(x => x.WriteLine(It.IsAny<string>()));

            var attacker = new Mock<ICreaturesInBattle>();
            attacker.Setup(x => x.Creature).Returns(new FakeCreature());

            var defender = new Mock<ICreaturesInBattle>();
            defender.Setup(x => x.Creature).Returns(new FakeCreature());

            var fakeBattleManager = new BattleManagerFake(factory.Object, logger.Object, attacker.Object, defender.Object);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString(fakeCreatureType + "(2)");

            // Act 
            fakeBattleManager.Attack(attackerIdentifier, defenderIdentifier);

            // Assert  
            logger.Verify(x => x.WriteLine(It.Is<string>(m => m.Contains("Attacker before"))), Times.Once);
            logger.Verify(x => x.WriteLine(It.Is<string>(m => m.Contains("Defender before"))), Times.Once);
            logger.Verify(x => x.WriteLine(It.Is<string>(m => m.Contains("Attacker after"))), Times.Once);
            logger.Verify(x => x.WriteLine(It.Is<string>(m => m.Contains("Defender after"))), Times.Once);
        }
    }
}
