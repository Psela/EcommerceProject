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

    [TestInitialize]
    public void Setup()
    {
      ProductData product1 = new ProductData();
      ProductData product2 = new ProductData();
      listOfProduct = new List<ProductData>(){product1, product2};
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
      CollectionAssert.AreEqual(listOfProduct,actual);
    }
  }
}
