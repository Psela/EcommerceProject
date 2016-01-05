using EcommerceProject.DatabaseModel;
using EcommerceProject.Website;
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
    ProductController productController;

    [TestInitialize]
    public void Setup()
    {
      mockDbReader = new Mock<IDataRetrieverService>();
      List<ProductData> listOfProduct = new List<ProductData>() { new ProductData() };
      mockDbReader.Setup(x => x.SearchData(It.IsAny<string>())).Returns(listOfProduct);
      mockDbReader.Setup(x => x.ReadData()).Returns(listOfProduct);
      mockDbReader.Setup(x => x.AddToBasket(It.IsAny<ProductData>(), 1));
      homeController = new HomeController(mockDbReader.Object);
      productController = new ProductController(mockDbReader.Object);
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

    [TestMethod]
    public void Test_ProductController_AddToBasket_CallsAddToBasket_ExactlyOnce()
    {
      //Arrange
      ProductData product1 = new ProductData();

      //Act
      productController.AddToBasket(product1);

      //Assert
      mockDbReader.Verify(x => x.AddToBasket(It.IsAny<ProductData>(), 1));
    }
  }
}
