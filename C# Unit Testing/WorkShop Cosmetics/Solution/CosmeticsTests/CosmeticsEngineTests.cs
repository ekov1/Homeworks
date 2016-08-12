namespace CosmeticsTests
{
    using Cosmetics.Common;
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
        public void Start_AddCategory_ShouldParseTheCommand()
        {
            Console.SetIn(new StringReader("CreateCategory ForMale"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            engine.Start();
            Assert.AreEqual(1, engine.Categories.Count);
        }

        [Test]
        public void Start_AddCategoryWhenItExistsInTheEngineList_ShouldNotCallTheCreateCategoryMethod()
        {
            Console.SetIn(new StringReader("CreateCategory ForMale"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var category = new Mock<ICategory>();

            category.Setup(x => x.Name).Returns("ForMale");
            engine.Categories.Add(category.Object.Name, category.Object);

            engine.Start();
            factory.Verify(x => x.CreateCategory("ForMale"), Times.Never);
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

        [Test]
        public void Start_AddProductToInvalidCategoryName_ShouldNotCallAddCodsmeticsMethod()
        {
            Console.SetIn(new StringReader("AddToCategory ForMale White+"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            mockedCategory.Setup(x => x.Name).Returns("Muje");
            mockedProduct.Setup(x => x.Name).Returns("White+");

            engine.Categories.Add(mockedCategory.Object.Name, mockedCategory.Object);
            engine.Products.Add(mockedProduct.Object.Name, mockedProduct.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddCosmetics(mockedProduct.Object), Times.Never());
        }

        [Test]
        public void Start_AddInvalidProductNameToCategory_ShouldNotCallAddCodsmeticsMethod()
        {
            Console.SetIn(new StringReader("AddToCategory ForMale White+"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();
            mockedCategory.Setup(x => x.Name).Returns("ForMale");
            mockedProduct.Setup(x => x.Name).Returns("Pasta");

            engine.Categories.Add(mockedCategory.Object.Name, mockedCategory.Object);
            engine.Products.Add(mockedProduct.Object.Name, mockedProduct.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddCosmetics(mockedProduct.Object), Times.Never());
        }

        [Test]
        public void RemoveFromCategory_InputValidCommand_ShouldRemoveProductFromCategory()
        {
            Console.SetIn(new StringReader("RemoveFromCategory ForMale Cool"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var category = new Mock<ICategory>();
            var product = new Mock<IProduct>();

            category.Setup(x => x.Name).Returns("ForMale");
            product.Setup(x => x.Name).Returns("Cool");

            engine.Categories.Add(category.Object.Name, category.Object);
            engine.Products.Add(product.Object.Name, product.Object);

            engine.Start();

            category.Verify(x => x.RemoveCosmetics(product.Object), Times.Once);
        }

        [Test]
        public void RemoveFromCategory_InputInvalidCategoryName_ShouldNotCallTheRemoveCosmeticsCommand()
        {
            Console.SetIn(new StringReader("RemoveFromCategory ForMen Cool"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var category = new Mock<ICategory>();
            var product = new Mock<IProduct>();

            category.Setup(x => x.Name).Returns("Kone");
            product.Setup(x => x.Name).Returns("Cool");

            engine.Categories.Add(category.Object.Name, category.Object);
            engine.Products.Add(product.Object.Name, product.Object);

            engine.Start();

            category.Verify(x => x.RemoveCosmetics(product.Object), Times.Never);
        }

        [Test]
        public void RemoveFromCategory_InputInvalidProductName_ShouldNotCallTheRemoveCosmeticsCommand()
        {
            Console.SetIn(new StringReader("RemoveFromCategory ForMen Cool"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var category = new Mock<ICategory>();
            var product = new Mock<IProduct>();

            category.Setup(x => x.Name).Returns("ForMen");
            product.Setup(x => x.Name).Returns("Smth");

            engine.Categories.Add(category.Object.Name, category.Object);
            engine.Products.Add(product.Object.Name, product.Object);

            engine.Start();

            category.Verify(x => x.RemoveCosmetics(product.Object), Times.Never);
        }

        [Test]
        public void Start_TestShowCategory_ShouldParseParseCommand()
        {
            Console.SetIn(new StringReader("ShowCategory ForMale"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var category = new Mock<ICategory>();

            category.Setup(x => x.Name).Returns("ForMale");
            engine.Categories.Add(category.Object.Name, category.Object);

            engine.Start();

            category.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_ShowCategoryWithoutTheCategoryInTheEngineList_ShouldNotCallThePrintMethod()
        {
            Console.SetIn(new StringReader("ShowCategory ForMale"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var category = new Mock<ICategory>();

            category.Setup(x => x.Name).Returns("ForMale");

            engine.Start();

            category.Verify(x => x.Print(), Times.Never);
        }

        [Test]
        public void Start_CreateShampoo_ShouldCorrectlyAddShampooToProductsList()
        {
            Console.SetIn(new StringReader("CreateShampoo Cool Nivea 0.50 men 500 everyday"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
        }

        [Test]
        public void Start_CreateShampooWithInvalidUsage_ShouldThrowInvalidOperationAndAddErrorMessageInstead()
        {
            Console.SetIn(new StringReader("CreateShampoo Cool Nivea 0.50 men 500 whenIwant"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            engine.Start();

            factory.Verify(x => x.CreateShampoo(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<decimal>(), It.IsAny<GenderType>(),
                It.IsAny<uint>(), It.IsAny<UsageType>()), Times.Never);
        }

        [Test]
        public void Start_CreateShampooWithInvalidGender_ShouldThrowInvalidOperationAndAddErrorMessageInstead()
        {
            Console.SetIn(new StringReader("CreateShampoo Cool Nivea 0.50 aliens 500 everyday"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            engine.Start();

            factory.Verify(x => x.CreateShampoo(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<decimal>(), It.IsAny<GenderType>(),
                It.IsAny<uint>(), It.IsAny<UsageType>()), Times.Never);
        }

        [Test]
        public void Start_CreateShampooWithNameThatAlreadyExistsInProductsList_ShouldNotAddTheShampooToProductsList()
        {
            Console.SetIn(new StringReader("CreateShampoo Cool Nivea 0.50 men 500 everyday"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var shampoo = new Mock<IProduct>();

            shampoo.Setup(x => x.Name).Returns("Cool");
            engine.Products.Add(shampoo.Object.Name, shampoo.Object);
            engine.Start();

            factory.Verify(x => x.CreateShampoo(It.IsAny<string>(), It.IsAny<string>(), 
                It.IsAny<decimal>(), It.IsAny<GenderType>(),
                It.IsAny<uint>(), It.IsAny<UsageType>()), Times.Never);
        }

        [Test]
        public void Start_CreateToothpaste_ShouldCorrectlyAddToothpasteToProductsList()
        {
            Console.SetIn(new StringReader("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);

            engine.Start();

            Assert.AreEqual(1, engine.Products.Count);
        }

        [Test]
        public void Start_ShouldCreateToothpaste_IfInputStringIsInValidFormat()
        {
            //Arrange
            var validInput = "CreateToothpaste White Lacalut 5.00 men igredientOne,igredientTwo";
            Console.SetIn(new StringReader(validInput));

            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();

            var toothpasteMock = new Mock<IToothpaste>();

            toothpasteMock.Setup(x => x.Name).Returns("White");

            factoryMock.Setup(x => x.CreateToothpaste(
                "White",
                "Lacalut",
                5.00m,
                GenderType.Men,
                new List<string>() { "ingredientOne", "ingredientTwo" }))
                .Returns(toothpasteMock.Object);

            var cosmeticsEngine = new CosmeticsEngineExtended(factoryMock.Object, shoppingCartMock.Object);

            //Act
            cosmeticsEngine.Start();

            //Assert
            //Assert.IsTrue(cosmeticsEngine.Products.ContainsKey("White"));
            Assert.AreEqual(toothpasteMock.Object, cosmeticsEngine.Products["White"]);
        }

        [Test]
        public void Start_CreateToothpasteWithNameThatAlreadyExistsInProductsList_ShouldNotAddTheToothpasteToProductsList()
        {
            Console.SetIn(new StringReader("CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var toothPaste = new Mock<IProduct>();

            toothPaste.Setup(x => x.Name).Returns("White+");
            engine.Products.Add(toothPaste.Object.Name, toothPaste.Object);
            engine.Start();

            factory.Verify(x => x.CreateToothpaste(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<decimal>(), It.IsAny<GenderType>(),
                It.IsAny<IList<string>>()), Times.Never);
        }

        [Test]
        public void Start_AddToShoppingCart_ShouldAddProductToCart()
        {
            Console.SetIn(new StringReader("AddToShoppingCart Cool"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var product = new Mock<IProduct>();

            product.Setup(x => x.Name).Returns("Cool");
            engine.Products.Add(product.Object.Name, product.Object);

            engine.Start();

            shoppingCart.Verify(x => x.AddProduct(product.Object), Times.Once);
        }

        [Test]
        public void Start_AddToShoppingCartWhenThereIsNoSuchProductInEngineList_ShouldNotCallAddToCartMethod()
        {
            Console.SetIn(new StringReader("AddToShoppingCart Cool"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var product = new Mock<IProduct>();

            product.Setup(x => x.Name).Returns("Cool");

            engine.Start();

            shoppingCart.Verify(x => x.AddProduct(product.Object), Times.Never);
        }

        [Test]
        public void Start_RemoveFromShoppingCart_ShouldCallMethodForRemovingFromShoppingCart()
        {
            Console.SetIn(new StringReader("RemoveFromShoppingCart White+"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var product = new Mock<IProduct>();

            product.Setup(x => x.Name).Returns("White+");
            engine.Products.Add(product.Object.Name, product.Object);
            shoppingCart.Setup(x => x.ContainsProduct(It.IsAny<IProduct>())).Returns(true);
            engine.Start();

            shoppingCart.Verify(x => x.RemoveProduct(product.Object), Times.Once);
        }

        [Test]
        public void Start_RemoveFromShoppingCartWhenNoSuchProductInProductList_ShouldNotCallRemoveFromCartMethod()
        {
            Console.SetIn(new StringReader("RemoveFromShoppingCart White+"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var product = new Mock<IProduct>();

            engine.Start();

            shoppingCart.Verify(x => x.RemoveProduct(product.Object), Times.Never);
        }

        [Test]
        public void Start_RemoveFromShoppingCartWhenNoSuchProductCart_ShouldNotCallRemoveFromCartMethod()
        {
            Console.SetIn(new StringReader("RemoveFromShoppingCart White+"));

            var factory = new Mock<ICosmeticsFactory>();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticsEngineExtended(factory.Object, shoppingCart.Object);
            var product = new Mock<IProduct>();

            product.Setup(x => x.Name).Returns("White+");
            engine.Products.Add(product.Object.Name, product.Object);

            engine.Start();

            shoppingCart.Verify(x => x.RemoveProduct(product.Object), Times.Never);
        }
    }
}
