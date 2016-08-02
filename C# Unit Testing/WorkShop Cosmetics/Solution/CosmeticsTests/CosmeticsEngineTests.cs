namespace CosmeticsTests
{
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_TestStartMethod_ShouldNotParseInputString()
        {
            Console.SetIn(new StringReader("see      "));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngine(factory.Object, shoppingCart.Object);

            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        public void Start_TestAddCategory_ShouldParseTheCommand()
        {
            Console.SetIn(new StringReader("CreateCategory ForMale"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            engine.Start();
            Assert.AreEqual(1, engine.Categories.Count);
        }

        [Test]
        public void Start_TestAddToCategory_ShouldParseTheCommand()
        {
            Console.SetIn(new StringReader("AddToCategory ForMale White+"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            mockedCategory.Setup(x => x.Name).Returns("ForMale");
            mockedProduct.Setup(x => x.Name).Returns("White+");

            engine.Categories.Add(mockedCategory.Object.Name,mockedCategory.Object);
            engine.Products.Add(mockedProduct.Object.Name, mockedProduct.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddCosmetics(mockedProduct.Object), Times.Once());
        }
    }
}
