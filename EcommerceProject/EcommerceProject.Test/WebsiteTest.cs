using EcommerceProject.Website.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EcommerceProject.Test
{
  [TestClass]
  public class WebsiteTest
  {
    HomeController controller;
    Mock<DatabaseReader> mockDbReader;

    [TestInitialize]
    public void Setup()
    {
      Mock<DataRetrieverService> mockService = new Mock<DataRetrieverService>();
      mockDbReader = new Mock<DatabaseReader>(mockService.Object);
      controller = new HomeController(mockDbReader.Object);
    }

    [TestMethod]
    public void Test_HomeControllerHasIndex()
    {
      // Arrange

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Test_SearchProducts_CallsUponGetAllProducts_ExactlyOnce_WhenCalled()
    {
      //Arrange
      Product product1 = new Product() { name = "testName" };
      List<Product> listOfProduct = new List<Product>() { product1 };
      mockDbReader.Setup(x => x.GetAllProducts()).Returns(listOfProduct);

      //Act
      controller.SearchProducts("test");

      //Assert
      mockDbReader.Verify(x => x.GetAllProducts(), Times.Once);

    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsSpecifiedProduct_WhenGivenAProductName()
    {
      //Arrange
      Product product1 = new Product() { name = "testName" };
      List<Product> listOfProduct = new List<Product>() { product1 };
      mockDbReader.Setup(x => x.GetAllProducts()).Returns(listOfProduct);

      //Act
      Product actualValue=controller.SearchProducts("testName");

      //Assert
      Assert.AreEqual(product1, actualValue);

    }
  }
}
