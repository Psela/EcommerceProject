using EcommerceProject.DatabaseModel;
using EcommerceProject.Website;
using EcommerceProject.Website.Controllers;
using EcommerceProject.Website.WebsiteBasketHost;
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
    Mock<IBasket> mockBasketReader;
    BasketController basketController;

    [TestInitialize]
    public void Setup()
    {
      mockDbReader = new Mock<IDataRetrieverService>();
      List<ProductData> listOfProduct = new List<ProductData>() { new ProductData() };
      mockDbReader.Setup(x => x.SearchData(It.IsAny<string>())).Returns(listOfProduct);
      mockDbReader.Setup(x => x.ReadData()).Returns(listOfProduct);
      mockBasketReader = new Mock<IBasket>();
      mockBasketReader.Setup(x => x.AddToBasket(It.IsAny<ProductData>(), 1));
      homeController = new HomeController(mockDbReader.Object);
      basketController= new BasketController(mockBasketReader.Object);
    }

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

    [TestMethod]
    public void Test_BasketController_GetBasketProducts_CallsUponGetBasket_ExactlyOnce_WhenCalled()
    {
      //Arrange

      //Act
      basketController.GetBasketProducts();

      //Assert
      mockBasketReader.Verify(x => x.GetBasket(), Times.Once);

    }
  }
}
