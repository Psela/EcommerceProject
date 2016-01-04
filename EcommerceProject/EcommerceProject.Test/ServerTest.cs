using EcommerceProject.AdminPortal.UpdateVM;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
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
    public class ServerTest
    {
        DataRetrieverService dbService;
        Mock<FindProduct> mockFind;
        List<ProductData> listOfProduct;
        ProductData product1;
        ProductData product2;
        ProductData product10;

        [TestInitialize]
        public void Setup()
        {
            product1 = new ProductData() { product_name = "product1", tag1 = "tag1", tag2 = "tag2", tag3 = "tag6", description = "description 1 is here", p_id = 1 };
            product2 = new ProductData() { product_name = "product2", tag1 = "tag1", tag2 = "tag3", tag3 = "tag2", description = "description 2 not is here" };
            ProductData product3 = new ProductData() { product_name = "product3", tag1 = "tag2", tag2 = "tag5", tag3 = "tag6", description = "description 6 is not here" };
            ProductData product4 = new ProductData() { product_name = "product4", tag1 = "tag3", tag2 = "tag8", tag3 = "tag12", description = "description 3 is over there" };
            ProductData product5 = new ProductData() { product_name = "product5", tag1 = "tag4", tag2 = "tag9", tag3 = "tag7", description = "description 2 is there" };
            ProductData product6 = new ProductData() { product_name = "product6", tag1 = "tag2", tag2 = "tag10", tag3 = "tag4", description = "description 7 is where" };
            ProductData product7 = new ProductData() { product_name = "product7", tag1 = "tag3", tag2 = "tag6", tag3 = "tag8", description = "description 9 is not here" };
            ProductData product8 = new ProductData() { product_name = "product8", tag1 = "tag5", tag2 = "tag6", tag3 = "tag7", description = "description 2 is there" };
            ProductData product9 = new ProductData() { product_name = "product9", tag1 = "tag7", tag2 = "tag9", tag3 = "tag4", description = "description 4 is not there" };
            product10 = new ProductData() { product_name = "product10", tag1 = "tag6", tag2 = "tag1", tag3 = "tag3", description = "description 7 is here" };
            listOfProduct = new List<ProductData>() 
      { 
        product1,
        product2,
        product3,
        product4,
        product5,
        product6,
        product7,
        product8,
        product9,
        product10
      };
            mockFind = new Mock<FindProduct>();
            mockFind.Setup(x => x.GetAllProducts()).Returns(listOfProduct);
            dbService = new DataRetrieverService(mockFind.Object);
        }

        [TestMethod]
        public void Test_ReadData_CallsOnGetAllProductFromFindProduct_OnlyOnce()
        {
            //Arrange

            //Act
            dbService.ReadData();

            //Assert
            mockFind.Verify(x => x.GetAllProducts(), Times.Once);
        }

        [TestMethod]
        public void Test_ReadData_ReturnsListOfProductsFromGivenDatabase()
        {
            //Arrange

            //Act
            List<ProductData> actual = dbService.ReadData();

            //Assert
            CollectionAssert.AreEqual(listOfProduct, actual);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsSpecifiedProduct_WhenGivenAProductName()
        {
            //Arrange

            //Act
            List<ProductData> actualValue = dbService.SearchData("product2");

            //Assert
            Assert.AreEqual(1, actualValue.Count);
            Assert.AreEqual(product2, actualValue[0]);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsEmptyList_WhenGivenAProductNameAndNotFound()
        {
            //Arrange

            //Act
            List<ProductData> actualValue = dbService.SearchData("testFail");

            //Assert
            Assert.AreEqual(0, actualValue.Count);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsListOfProductsWithCloseName_WhenGivenAProductsIncompleteName()
        {
            //Arrange
            List<ProductData> expectedReturnedList = new List<ProductData>() { product1, product10 };

            //Act
            List<ProductData> returnedListOfProducts = dbService.SearchData("oduct1");

            //Assert
            CollectionAssert.AreEqual(expectedReturnedList, returnedListOfProducts);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsListOfProductsWithDemandedTag_WhenGivenATag()
        {
            //Arrange
            List<ProductData> expectedResults = new List<ProductData>() { product1, product2, product10 };

            //Act
            List<ProductData> actualResults = dbService.SearchData("tag1");

            //Assert
            CollectionAssert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsEmptyList_WhenGivenANonExistingTag()
        {
            //Arrange

            //Act
            List<ProductData> actualResults = dbService.SearchData("ft1");

            //Assert
            Assert.AreEqual(0, actualResults.Count);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsListOfProductsContainingAskedForInDescription_WhenGivenAString()
        {
            //Arrange
            List<ProductData> expectedResults = new List<ProductData>() { product1, product2, product10 };

            //Act
            List<ProductData> actualResults = dbService.SearchData("is here");

            //Assert
            CollectionAssert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsEmptyList_WhenGivenAStringAndNotFoundInTheDescription()
        {
            //Arrange

            //Act
            List<ProductData> actualResults = dbService.SearchData("1is");

            //Assert
            Assert.AreEqual(0, actualResults.Count);
        }

        [TestMethod]
        public void Test_SearchData_ReturnsProduct_WhenGivenAProductID()
        {
            //Arrange
            List<ProductData> expectedResults = new List<ProductData>() { product1 };

            //Act
            List<ProductData> actualResults = dbService.SearchData("1");

            //Assert
            CollectionAssert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void Test_FindById_ReturnsOneProduct_WhenPassesAnIdAsString()
        {
            //Arrange
            string input = "1";      
            
            //Act
            dbService.FindById(input);
            
            //Assert
            
            mockFind.Verify(dr => dr.GetAllProducts(),Times.Once());
        }
    }
}
