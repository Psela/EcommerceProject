using EcommerceProject.AdminPortal;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Delete;
using EcommerceProject.DataModel;
using EcommerceProject.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Test
{
  [TestClass]
  public class AdminPortalTest
  {
    FindProductViewModel viewModel;
    Product product1;
    Mock<DatabaseReader> mockDbReader;
    Mock<RemoveProduct> mockRemoveProduct;
    [TestInitialize]
    public void Setup()
    {
      Mock<DataRetrieverService> mockService = new Mock<DataRetrieverService>();
      mockDbReader = new Mock<DatabaseReader>(mockService.Object);

      product1 = new Product()
      {
        name = "product1",
        tag1 = "tag1",
        tag2 = "tag2",
        tag3 = "tag6",
        description = "description 1 is here",
        id = 1,
        imageurl = "imageurlhere"
      };
      Product product2 = new Product()
      {
        name = "product2",
        tag1 = "tag1",
        tag2 = "tag3",
        tag3 = "tag2",
        description = "description 2 not is here",
        id = 2,
        imageurl = "imageurlfor2"
      };
      List<Product> listOfProduct = new List<Product>() 
      { 
        product1,
        product2
      };
      mockDbReader.Setup(x => x.GetAllProducts()).Returns(listOfProduct);
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<ProductData> productDataList = new List<ProductData>();
      Mock<ProductData> mockProductData = new Mock<ProductData>();
      mockProductData.SetupAllProperties();
      mockProductData.Object.p_id = 1;

      productDataList.Add(mockProductData.Object);

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);
      context.SetupAllProperties();
      context.Object.ProductDatas = mockedDataSet;

      mockRemoveProduct = new Mock<RemoveProduct>(context.Object);
      viewModel = new FindProductViewModel(mockDbReader.Object, mockRemoveProduct.Object);
    }

    [TestMethod]
    public void Test_CanSearch_ReturnsTrueWhenCalled()
    {
      //Arrange

      //Act
      bool actualresult = viewModel.CanSearch();

      //Assert
      Assert.IsTrue(actualresult);
    }

    [TestMethod]
    public void Test_Search_CallsGetAllProductsFromDatabaseReader_WhenCalledWithIntInSearchBox()
    {
      //Arrange
      viewModel.SearchBox = "2";

      //Act
      viewModel.Search();

      //Assert
      mockDbReader.Verify(x => x.GetAllProducts(), Times.Once);
    }

    [TestMethod]
    public void Test_Search_OutputsCorrectValue_WhenSearchBoxSetToId1()
    {
      //Arrange
      viewModel.SearchBox = "1";

      //Act
      viewModel.Search();

      //Assert
      Assert.AreEqual(product1.description, viewModel.productTemp.description);
      Assert.AreEqual(product1.name, viewModel.productTemp.name);
      Assert.AreEqual(product1.price, viewModel.productTemp.price);
      Assert.AreEqual(product1.stock, viewModel.productTemp.stock);
      Assert.AreEqual(product1.tag1, viewModel.productTemp.tag1);
      Assert.AreEqual(product1.tag2, viewModel.productTemp.tag2);
      Assert.AreEqual(product1.tag3, viewModel.productTemp.tag3);
      Assert.AreEqual(product1.imageurl, viewModel.productTemp.imageurl);
    }

    [TestMethod]
    public void Test_Search_OutputsNothing_WhenSearchBoxSetToStringNotNumber()
    {
      //Arrange
      viewModel.SearchBox = "Fail";

      //Act
      viewModel.Search();

      //Assert
      Assert.IsNull(viewModel.productTemp.description);
      Assert.IsNull(viewModel.productTemp.name);
      Assert.AreEqual(0.0, viewModel.productTemp.price);
      Assert.AreEqual(0, viewModel.productTemp.stock);
      Assert.IsNull(viewModel.productTemp.tag1);
      Assert.IsNull(viewModel.productTemp.tag2);
      Assert.IsNull(viewModel.productTemp.tag3);
      Assert.IsNull(viewModel.productTemp.imageurl);
    }

    [TestMethod]
    public void Test_Search_OutputsNothing_WhenSearchBoxSetToNothing()
    {
      //Arrange
      viewModel.SearchBox = "";

      //Act
      viewModel.Search();

      //Assert
      Assert.IsNull(viewModel.productTemp.description);
      Assert.IsNull(viewModel.productTemp.name);
      Assert.AreEqual(0.0, viewModel.productTemp.price);
      Assert.AreEqual(0, viewModel.productTemp.stock);
      Assert.IsNull(viewModel.productTemp.tag1);
      Assert.IsNull(viewModel.productTemp.tag2);
      Assert.IsNull(viewModel.productTemp.tag3);
      Assert.IsNull(viewModel.productTemp.imageurl);
    }

    [TestMethod]
    public void Test_Search_OutputsNothing_WhenSearchBoxSetToUnknownId()
    {
      //Arrange
      viewModel.SearchBox = "52";

      //Act
      viewModel.Search();

      //Assert
      Assert.IsNull(viewModel.productTemp.description);
      Assert.IsNull(viewModel.productTemp.name);
      Assert.AreEqual(0.0, viewModel.productTemp.price);
      Assert.AreEqual(0, viewModel.productTemp.stock);
      Assert.IsNull(viewModel.productTemp.tag1);
      Assert.IsNull(viewModel.productTemp.tag2);
      Assert.IsNull(viewModel.productTemp.tag3);
      Assert.IsNull(viewModel.productTemp.imageurl);
    }

    [TestMethod]
    public void Test_CanGoToUpdatePage_ReturnsTrueWhenCalled()
    {
      //Arrange

      //Act
      bool actualresult = viewModel.CanGoToUpdatePage();

      //Assert
      Assert.IsTrue(actualresult);
    }

    //[TestMethod]
    //public void Test_Remove_DoesntCallDeleteProductById_WhenSearchBoxStringNotInt()
    //{
    //  //Arrange
    //  viewModel.SearchBox = "Fail";

    //  //Act
    //  viewModel.Remove();

    //  //Assert
    //  mockRemoveProduct.Verify(x => x.DeleteProductByID(It.IsAny<int>()), Times.Never);
    //}

    [TestMethod]
    public void Test_CanRemove_ReturnsTrue_WhenCalled()
    {
      //Arrange

      //Act
      bool actual = viewModel.CanRemove();

      //Assert
      Assert.IsTrue(actual);
    }

  }
}
