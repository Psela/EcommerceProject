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
    List<Product> expectedResult;

    [TestInitialize]
    public void Setup()
    {
      mockDBReader = new Mock<DataRetrieverService>();
      select = new DatabaseReader(mockDBReader.Object);
      expectedResult = new List<Product>();
    }
    [TestMethod]
    public void Test_GetAllProducts_CallsReadDataOnTheDataRetrieverService_WhenCalled_ExactlyOnce()
    {
      //Arrange

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
      Product product1 = new Product();
      Product product2 = new Product();
      Product product3 = new Product();
      Product product4 = new Product();
      expectedResult.Add(product1);
      expectedResult.Add(product2);
      expectedResult.Add(product3);
      expectedResult.Add(product4);

      mockDBReader.Setup(x => x.ReadData()).Returns(expectedResult);

      //Act
      List<Product> actualResult = select.GetAllProducts();

      //Assert
      CollectionAssert.AreEqual(expectedResult, actualResult);
    }
  }
}
