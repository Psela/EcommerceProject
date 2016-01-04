using EcommerceProject.DatabaseModel;
using EcommerceProject.Website.Controllers;
using EcommerceProject.Website.WebsiteServerHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace EcommerceProject.Test
{
  [TestClass]
  public class WebsiteTest
  {
    HomeController homeController;
    Mock<IDataRetrieverService> mockDbReader;

    [TestInitialize]
    public void Setup()
    {
      mockDbReader = new Mock<IDataRetrieverService>();
      List<ProductData> listOfProduct = new List<ProductData>() { new ProductData() };
      mockDbReader.Setup(x => x.SearchData(It.IsAny<string>())).Returns(listOfProduct);
      mockDbReader.Setup(x => x.ReadData()).Returns(listOfProduct);
      homeController = new HomeController(mockDbReader.Object);
    }

    //[TestMethod]
    //public void Test_HomeControllerHasIndex()
    //{
    //  // Arrange

    //  // Act
    //  ViewResult result = controller.Index() as ViewResult;

    //  // Assert
    //  Assert.IsNotNull(result);
    //}

    [TestMethod]
    public void Test_HomeController_SearchProducts_CallsUponSearchData_ExactlyOnce_WhenCalled()
    {
      //Arrange

      //Act
      homeController.SearchProducts("test");

      //Assert
      mockDbReader.Verify(x => x.SearchData(It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    public void Test_HomeController_GetAllProductsInList_CallsUponReadData_ExactlyOnce_WhenCalled()
    {
      //Arrange

      //Act
      homeController.GetAllProductsInList();

      //Assert
      mockDbReader.Verify(x => x.ReadData(), Times.Once);
    }
  }
}
