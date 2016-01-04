using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
using EcommerceProject.Server;
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
    Mock<FindProduct> mockDbReader;
    ProductData product1;
    ProductData product2;
    ProductData product10;
    List<ProductData> listOfProduct;

    [TestInitialize]
    public void Setup()
    {
      Mock<ECommerceEntities> mockService = new Mock<ECommerceEntities>();
      mockDbReader = new Mock<FindProduct>(mockService.Object);

      product1 = new ProductData() { product_name = "product1", tag1 = "tag1", tag2 = "tag2", tag3 = "tag6", description = "description 1 is here",p_id=1 };
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
      mockDbReader.Setup(x => x.GetAllProducts()).Returns(listOfProduct);   
      controller = new HomeController(mockDbReader.Object);
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
    public void Test_SearchProducts_CallsUponGetAllProducts_ExactlyOnce_WhenCalled()
    {
      //Arrange

      //Act
      controller.SearchProducts("test");

      //Assert
      mockDbReader.Verify(x => x.GetAllProducts(), Times.Once);

    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsSpecifiedProduct_WhenGivenAProductName()
    {
      //Arrange

      //Act
      List<ProductData> actualValue = controller.SearchProducts("product2");

      //Assert
      Assert.AreEqual(1, actualValue.Count);
      Assert.AreEqual(product2, actualValue[0]);
    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsEmptyList_WhenGivenAProductNameAndNotFound()
    {
      //Arrange

      //Act
      List<ProductData> actualValue = controller.SearchProducts("testFail");

      //Assert
      Assert.AreEqual(0, actualValue.Count);
    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsListOfProductsWithCloseName_WhenGivenAProductsIncompleteName()
    {
      //Arrange
      List<ProductData> expectedReturnedList = new List<ProductData>() { product1, product10 };

      //Act
      List<ProductData> returnedListOfProducts = controller.SearchProducts("oduct1");

      //Assert
      CollectionAssert.AreEqual(expectedReturnedList, returnedListOfProducts);
    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsListOfProductsWithDemandedTag_WhenGivenATag()
    {
      //Arrange
      List<ProductData> expectedResults = new List<ProductData>() { product1, product2, product10 };

      //Act
      List<ProductData> actualResults = controller.SearchProducts("tag1");

      //Assert
      CollectionAssert.AreEqual(expectedResults, actualResults);
    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsEmptyList_WhenGivenANonExistingTag()
    {
      //Arrange

      //Act
      List<ProductData> actualResults = controller.SearchProducts("ft1");

      //Assert
      Assert.AreEqual(0, actualResults.Count);
    }

    [TestMethod]
    public void Test_SearchProduct_ReturnsListOfProductsContainingAskedForInDescription_WhenGivenAString()
    {
      //Arrange
      List<ProductData> expectedResults = new List<ProductData>() { product1, product2, product10 };

      //Act
      List<ProductData> actualResults = controller.SearchProducts("is here");

      //Assert
      CollectionAssert.AreEqual(expectedResults, actualResults);
    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsEmptyList_WhenGivenAStringAndNotFoundInTheDescription()
    {
      //Arrange

      //Act
      List<ProductData> actualResults = controller.SearchProducts("1is");

      //Assert
      Assert.AreEqual(0, actualResults.Count);
    }

    [TestMethod]
    public void Test_SearchProducts_ReturnsProduct_WhenGivenAProductID()
    {
      //Arrange
      List<ProductData> expectedResults = new List<ProductData>() { product1};

      //Act
      List<ProductData> actualResults = controller.SearchProducts("1");

      //Assert
      CollectionAssert.AreEqual(expectedResults, actualResults);
    }
  }
}
