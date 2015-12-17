using EcommerceProject.DatabaseModel;
using EcommerceProject.DataModel;
using EcommerceProject.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Test
{
    [TestClass]
    public class DataModelTests
    {
        Mock<DataRetrieverService> mockDBReader;
        DatabaseReader select;
        List<ProductData> expectedResult;

        [TestInitialize]
        public void Setup()
        {
            mockDBReader = new Mock<DataRetrieverService>();
            select = new DatabaseReader(mockDBReader.Object);
            expectedResult = new List<ProductData>();
        }

        [TestMethod]
        public void Test_GetAllProducts_CallsReadDataOnTheDataRetrieverService_WhenCalled_ExactlyOnce()
        {
            //Arrange
            List<ProductData> returnResult = new List<ProductData>();
            ProductData product1 = new ProductData();
            mockDBReader.Setup(x => x.ReadData()).Returns(returnResult);

            //Act
            select.GetAllProducts();

            //Assert
            mockDBReader.Verify(x => x.ReadData(), Times.Once);

        }

        [TestMethod]
        public void Test_GetAllProducts_ReturnsListOfProducts_WhenCalled()
        {
            //Arrange
            mockDBReader.Setup(x => x.ReadData()).Returns(expectedResult);

            //Act
            var actualResult = select.GetAllProducts();

            //Assert
            Assert.IsInstanceOfType(actualResult.GetType(), typeof(List<Product>).GetType());
        }

        [TestMethod]
        public void Test_GetAllProducts_ReturnsListOfCountZeroWhenNothingInTheDatabase()
        {
            //Arrange
            mockDBReader.Setup(x => x.ReadData()).Returns(expectedResult);

            //Act
            List<Product> actualResult = select.GetAllProducts();

            //Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);

        }

        [TestMethod]
        public void Test_GetAllProducts_ReturnsAllProductsInDatabase_WhenCalled()
        {
            //Arrange
            List<ProductData> returnResult = new List<ProductData>();
            ProductData product1 = new ProductData()
            {
                p_id = 1,
                price = 2.30m,
                description = "ME",
                product_name = "You",
                tag1 = "",
                tag2 = "boo",
                tag3 = "radlyey",
                imageurl = "sdfsdf",
                stock = 3
            };
            ProductData product2 = new ProductData() { p_id = 2, price = 2.30m, description = "E", product_name = "Yo", tag1 = "", tag2 = "oo", tag3 = "ralyey", imageurl = "sdsdf", stock = 3 };

            returnResult.Add(product1);
            returnResult.Add(product2);

            List<Product> expectedProductList = new List<Product>();

            Product expectedproduct1 = new Product()
            {
                id = 1,
                price = 2.30,
                description = "ME",
                name = "You",
                tag1 = "",
                tag2 = "boo",
                tag3 = "radlyey",
                imageurl = "sdfsdf",
                stock = 3
            };
            Product expectedproduct2 = new Product() { id = 2, price = 2.30, description = "E", name = "Yo", tag1 = "", tag2 = "oo", tag3 = "ralyey", imageurl = "sdsdf", stock = 3 };
            expectedProductList.Add(expectedproduct1);
            expectedProductList.Add(expectedproduct2);


            mockDBReader.Setup(x => x.ReadData()).Returns(returnResult);

            //Act
            List<Product> actualResult = select.GetAllProducts();

            //Assert
            Assert.IsTrue(expectedProductList.SequenceEqual(actualResult, new ProductEqualityComparer()));

        }
    }
}
