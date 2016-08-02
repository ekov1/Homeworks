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

    [TestFixture]
    public class CosmeticFactoryTests
    {
        [Test]
        public void CreateShampoo_InputNullName_ShouldThrowArgumentNullException()
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(null, "Nivea", 10.0m, GenderType.Men, 200, UsageType.EveryDay));
        }
    }
}
