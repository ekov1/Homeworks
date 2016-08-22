namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    using Moq;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        //[TestMethod]
        //public void CreateController_WithEmptyConstructor_ShouldInitializeEmptyController()
        //{
        //    var controller = new Mock<CarsController>();
        //    // ...
        //}

        [TestMethod]
        public void Index_ShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCar_ShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCar_ShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCar_ShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCar_ShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            // Messed up test...
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void Search_InputSearchCondition_ShouldReturnCollectionOfSearchResults()
        {
            var search = (IList<Car>)this.GetModel(() => this.controller.Search("make"));
            Assert.AreEqual(2, search[0].Id);
            Assert.AreEqual(3, search[1].Id);
        }

        [TestMethod]
        public void Sort_SortByMake_ShouldReturnCollectionOfSortedByMakeCars()
        {
            var search = (IList<Car>)this.GetModel(() => this.controller.Sort("make"));
            Assert.AreEqual(1, search[0].Id);
            Assert.AreEqual(2, search[1].Id);
            Assert.AreEqual(3, search[2].Id);
            Assert.AreEqual(4, search[3].Id);

        }

        [TestMethod]
        public void Sort_SortByYear_ShouldReturnCollectionOfSortedByYearCars()
        {
            var search = (IList<Car>)this.GetModel(() => this.controller.Sort("year"));
            Assert.AreEqual(1, search[0].Id);
            Assert.AreEqual(3, search[1].Id);
            Assert.AreEqual(2, search[2].Id);
            Assert.AreEqual(4, search[3].Id);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sort_InputInvalidSortingCommand_ShouldThrowArgumenException()
        {
            var search = (IList<Car>)this.GetModel(() => this.controller.Sort("price"));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Details_InputInvalidID_ShouldThrowArgumentException()
        {
            var car = (Car)this.GetModel(() => this.controller.Details(-30));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
