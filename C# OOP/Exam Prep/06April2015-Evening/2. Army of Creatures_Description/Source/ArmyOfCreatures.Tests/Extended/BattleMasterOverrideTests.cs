namespace ArmyOfCreatures.Tests.Extended
{
    using Logic;
    using MSUnitTest = Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NUnit.Framework;
    using ArmyOfCreatures.Extended;

    [TestFixture]
    public class BattleMasterOverrideTests
    {
        [Test]
        public void BattleManagerOverride_ConstructorShouldUsePassedLogger()
        {
            // Arrange
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManagerOverride = new BattleMasterOverride(factory.Object, logger.Object);
            var privateManager = new MSUnitTest.PrivateObject(battleManagerOverride);

            // Act and assert
            Assert.AreEqual(logger.Object, privateManager.GetField("logger"));
        }

        [Test]
        public void BattleManagerOverride_ConstructorShouldUsePassedCreaturesFactory()
        {
            // Arrange
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManagerOverride = new BattleMasterOverride(factory.Object, logger.Object);
            var privateManager = new MSUnitTest.PrivateObject(battleManagerOverride);

            // Act and assert
            Assert.AreEqual(factory.Object, privateManager.GetField("creaturesFactory"));
        }

        [TestCase("firstArmyCreatures")]
        [TestCase("secondArmyCreatures")]
        [TestCase("thirdArmyCreatures")]
        public void BattleManagerOverride_ConstructorShouldInstantiateArmyOfCreaturesCorrectly(string armyNumber)
        {
            // Arrange
            var factory = new Mock<ICreaturesFactory>();
            var logger = new Mock<ILogger>();
            var battleManagerOverride = new BattleMasterOverride(factory.Object, logger.Object);
            var privateManager = new MSUnitTest.PrivateObject(battleManagerOverride);

            // Act and Assert
            Assert.IsNotNull(privateManager.GetField(armyNumber));
        }
    }
}
