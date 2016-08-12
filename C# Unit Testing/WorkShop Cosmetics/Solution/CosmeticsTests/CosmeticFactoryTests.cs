namespace CosmeticsTests
{
    using Cosmetics.Products;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cosmetics.Common;
    using Cosmetics.Engine;
    using Cosmetics.Contracts;
    using Moq;

    [TestFixture]
    public class CosmeticFactoryTests
    {
        [Test]
        public void CreateShampoo_InputNullName_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<ICosmeticsFactory>();
            factory.Setup(x => x.CreateShampoo(null, It.IsAny<string>(),
                It.IsAny<decimal>(), It.IsAny<GenderType>(),
                It.IsAny<uint>(), It.IsAny<UsageType>())).Throws(new ArgumentNullException());

            Assert.Throws<ArgumentNullException>(() => factory.Object.CreateShampoo(null, "Nivea", 10.0m, GenderType.Men, 200, UsageType.EveryDay));
        }
        // TODO: Find out which way is correct 
        [Test]
        public void CreateShampoo_InputNullBrand_ShouldThrowArgumentNullException()
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("Blast", null, 10.0m, GenderType.Men, 200, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_InputValidParameters_ShouldReturnNewShampoo()
        {
            var factory = new CosmeticsFactory();
            var shampoo = new Shampoo("Blast", "Nivea", 10.0m, GenderType.Men, 200, UsageType.EveryDay);
            Assert.IsInstanceOf<IShampoo>(shampoo);
        }


    }
}
