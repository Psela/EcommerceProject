using EcommerceProject.AdminPortal;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Delete;
using EcommerceProject.DatabaseModel.Select;
using EcommerceProject.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceProject.AdminPortal.FindVM;

namespace EcommerceProject.Test
{
  [TestClass]
  public class AdminPortalTest
  {
    FindProductViewModel viewModel;
    ProductData product1;
    Mock<FindProduct> mockDbReader;
    Mock<RemoveProduct> mockRemoveProduct;
    [TestInitialize]
    public void Setup()
    {
      Mock<ECommerceEntities> mockService = new Mock<ECommerceEntities>();
      mockDbReader = new Mock<FindProduct>(mockService.Object);

      product1 = new ProductData()
      {
        product_name = "product1",
        tag1 = "tag1",
        tag2 = "tag2",
        tag3 = "tag6",
        description = "description 1 is here",
        p_id = 1,
        imageurl = "imageurlhere"
      };
      ProductData product2 = new ProductData()
      {
          product_name = "product2",
        tag1 = "tag1",
        tag2 = "tag3",
        tag3 = "tag2",
        description = "description 2 not is here",
        p_id = 2,
        imageurl = "imageurlfor2"
      };
      List<ProductData> listOfProduct = new List<ProductData>() 
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
      Assert.AreEqual(product1, viewModel.productTemp);
    }

    [TestMethod]
    public void Test_Search_OutputsNothing_WhenSearchBoxSetToStringNotNumber()
    {
      //Arrange
      viewModel.SearchBox = "Fail";

      //Act
      viewModel.Search();

      //Assert
      Assert.IsNull(viewModel.productTemp);
    }

    [TestMethod]
    public void Test_Search_OutputsNothing_WhenSearchBoxSetToNothing()
    {
      //Arrange
      viewModel.SearchBox = "";

      //Act
      viewModel.Search();

      //Assert
      Assert.IsNull(viewModel.productTemp);
    }

    [TestMethod]
    public void Test_Search_OutputsNothing_WhenSearchBoxSetToUnknownId()
    {
      //Arrange
      viewModel.SearchBox = "52";

      //Act
      viewModel.Search();

      //Assert
      Assert.IsNull(viewModel.productTemp);
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
