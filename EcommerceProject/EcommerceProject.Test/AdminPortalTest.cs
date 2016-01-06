using EcommerceProject.AdminPortal.FindVM;
using EcommerceProject.AdminPortal.ServiceHostReference;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Delete;
using EcommerceProject.DatabaseModel.Select;
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
    ProductData product1;
    Mock<IDataRetrieverService> mockDbReader;

    [TestInitialize]
    public void Setup()
    {
      mockDbReader = new Mock<IDataRetrieverService>();

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

      mockDbReader.Setup(x => x.ReadData()).Returns(listOfProduct);

      viewModel = new FindProductViewModel(mockDbReader.Object);
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
    public void Test_Search_CallsFIndByIDFromDataRetriever_WhenCalledWithIntInSearchBox()
    {
      //Arrange
      viewModel.SearchBox = "2";

      //Act
      viewModel.Search();

      //Assert
      mockDbReader.Verify(x => x.FindById(It.IsAny<string>()), Times.Once);
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

    [TestMethod]
    public void Test_CanRemove_ReturnsTrue_WhenCalled()
    {
      //Arrange

      //Act
      bool actual = viewModel.CanRemove();

      //Assert
      Assert.IsTrue(actual);
    }

    [TestMethod]
    public void Test_CanGoMainMenu_ReturnsTrue_WhenCalled()
    {
      //Arrange

      //Act
      bool actual = viewModel.CanGoMainMenu();

      //Assert
      Assert.IsTrue(actual);
    }


  }
}
