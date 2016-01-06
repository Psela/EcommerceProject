using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
using EcommerceProject.DatabaseModel.Add;
using EcommerceProject.DatabaseModel.Delete;
using EcommerceProject.DatabaseModel.Update;


namespace EcommerceProject.Test
{

  [TestClass]
  public class EntityFrameworkTest
  {
    Mock<ECommerceEntities> context;
    FindProduct findProduct;
    List<ProductData> productDataList;
    Mock<ProductData> mockProductData;

    [TestInitialize]
    public void Setup()
    {
      context = new Mock<ECommerceEntities>();
      context.SetupAllProperties();   
      productDataList = new List<ProductData>();
      mockProductData = new Mock<ProductData>();
      mockProductData.SetupAllProperties();
      mockProductData.Object.p_id = 1;
      mockProductData.Object.product_name = "product1";
      productDataList.Add(mockProductData.Object);

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);

      context.Object.ProductDatas = mockedDataSet;

      findProduct = new FindProduct(context.Object);
    }

    [TestMethod]
    public void test_thatGetAllProducts_returnsAListOfProductData_whenCalled()
    {
      //Arrange

      //Act
      List<ProductData> list = findProduct.GetAllProducts();

      //Assert
      CollectionAssert.AreEqual(productDataList, list);
    }

    [TestMethod]
    public void test_thatGetAllOrders_returnsOrderHistory_whenCalled()
    {
      //Arrange
      List<OrderHistory> orderHistoryList = new List<OrderHistory>();
      Mock<OrderHistory> mockOrderHistory = new Mock<OrderHistory>();
      mockOrderHistory.SetupAllProperties();

      orderHistoryList.Add(mockOrderHistory.Object);

      DbSet<OrderHistory> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<OrderHistory>(orderHistoryList);
      context.Object.OrderHistories = mockedDataSet;

      FindOrder findOrder = new FindOrder(context.Object);

      //Act
      List<OrderHistory> list = findOrder.GetAllOrders();

      //Assert
      CollectionAssert.AreEqual(orderHistoryList, list);
    }

    [TestMethod]
    public void test_thatGetAllCustomers_returnsAListOfAllCustomers_whenCalled()
    {
      //Arrange
      List<CustomerData> customerList = new List<CustomerData>();
      Mock<CustomerData> mockCustomers = new Mock<CustomerData>();
      mockCustomers.SetupAllProperties();

      customerList.Add(mockCustomers.Object);

      DbSet<CustomerData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<CustomerData>(customerList);
      context.Object.CustomerDatas = mockedDataSet;

      FindCustomer findCustomers = new FindCustomer(context.Object);

      //Act
      List<CustomerData> list = findCustomers.GetAllCustomers();

      //Assert
      CollectionAssert.AreEqual(customerList, list);
    }

    [TestMethod]
    public void test_thatGetCustomerByID_returnsACustomerDataObject_whenCalledWithAValidID()
    {
      //Arrange
      List<CustomerData> mockCustomerList = new List<CustomerData>();
      Mock<CustomerData> mockCustomers = new Mock<CustomerData>();
      mockCustomers.SetupAllProperties();
      mockCustomers.Object.c_id = 1;
      mockCustomerList.Add(mockCustomers.Object);

      DbSet<CustomerData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<CustomerData>(mockCustomerList);
      context.Object.CustomerDatas = mockedDataSet;

      FindCustomer findCustomerByID = new FindCustomer(context.Object);

      //Act
      CustomerData returnedCustomer = findCustomerByID.GetCustomerByID(1);

      //Assert
      Assert.AreEqual(mockCustomers.Object, returnedCustomer);
    }

    [TestMethod]
    public void test_thatGetProductByID_returnsAProductDataObject_whenCalledWithAValidID()
    {
      //Arrange

      //Act
      ProductData returnedProduct = findProduct.GetProductByID(1);

      //Assert
      Assert.AreEqual(mockProductData.Object, returnedProduct);
    }

    [TestMethod]
    public void test_thatGetOrderByID_returnsAnOrderHistoryObject_whenCalledWithAValidID()
    {
      //Arrange
      List<OrderHistory> mockOrderList = new List<OrderHistory>();
      Mock<OrderHistory> mockOrders = new Mock<OrderHistory>();
      mockOrders.SetupAllProperties();
      mockOrders.Object.order_number = 1;
      mockOrderList.Add(mockOrders.Object);

      DbSet<OrderHistory> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<OrderHistory>(mockOrderList);
      context.Object.OrderHistories = mockedDataSet;

      FindOrder findOrderByID = new FindOrder(context.Object);

      //Act
      OrderHistory returnedOrder = findOrderByID.GetOrderByID(1);

      //Assert
      Assert.AreEqual(mockOrders.Object, returnedOrder);
    }

    [TestMethod]
    public void test_thatAddNewProduct_addsANewProductToTheDatabase_whenCalledWithValidParameters()
    {
      //Arrange
      NewProduct addProduct = new NewProduct(context.Object);
      ProductData product = new ProductData()
      {
        p_id = 3,
        product_name = "",
        price = 0.0m,
        tag1 = "",
        tag2 = "",
        tag3 = "",
        stock = 0,
        description = "",
        imageurl = ""
      };

      //Act
      addProduct.CreateNewProduct(product);

      //Assert
      Assert.AreEqual(2, productDataList.Count);
    }

    [TestMethod]
    public void test_thatAddNewProduct_PassesCorrectParametersToDatabase_whenCalledWithValidParameters()
    {
      //Arrange
      NewProduct addProduct = new NewProduct(context.Object);
      ProductData product = new ProductData()
      {
        product_name = "",
        description = "",
        price = 0.0m,
        tag1 = "",
        tag2 = "",
        tag3 = "",
        stock = 1,
        imageurl = ""
      };

      //Act
      addProduct.CreateNewProduct(product);


      //Assert
      Assert.AreEqual(product, productDataList[1]);
    }

    [TestMethod]
    public void test_thatDeleteProductByID_DeletesAProductFromTheDatabase_whenCalledWithAValidID()
    {
      //Arrange
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<ProductData> productDataList = new List<ProductData>();
      Mock<ProductData> mockProductData = new Mock<ProductData>();
      mockProductData.SetupAllProperties();
      mockProductData.Object.p_id = 1;

      productDataList.Add(mockProductData.Object);

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);
      context.SetupAllProperties();
      context.Object.ProductDatas = mockedDataSet;


      RemoveProduct delProduct = new RemoveProduct(context.Object);

      //Act
      delProduct.DeleteProductByID(1);

      //Assert
      Assert.AreEqual(0, productDataList.Count);
    }

    [TestMethod]
    public void test_thatUpdateProduct_CallsSaveChangesOnce_whenCalled()
    {
      //Arrange
      EditProduct updateProduct = new EditProduct(context.Object);

      Mock<ProductData> mockProduct = new Mock<ProductData>();
      mockProduct.SetupAllProperties();
      mockProduct.Object.p_id = 1;

      //Act
      updateProduct.UpdateProduct(mockProduct.Object);

      //Assert
      context.Verify(c => c.SaveChanges(), Times.Once);
    }

    [TestMethod]
    public void test_thatUpdateProduct_ChangesProductDetails_WhenGivenProductToChangeAndProductWithNewDetails()
    {
      //Arrange
      EditProduct updateProduct = new EditProduct(context.Object);

      Mock<ProductData> expectedChanges = new Mock<ProductData>();
      expectedChanges.SetupAllProperties();
      expectedChanges.Object.p_id = 1;
      expectedChanges.Object.product_name = "Updated Product";
      
      //Act
      updateProduct.UpdateProduct(expectedChanges.Object);

      //Assert
      Assert.AreEqual(expectedChanges.Object.p_id, productDataList[0].p_id);
      Assert.AreEqual(expectedChanges.Object.description, productDataList[0].description);
      Assert.AreEqual(expectedChanges.Object.imageurl, productDataList[0].imageurl);
      Assert.AreEqual(expectedChanges.Object.price, productDataList[0].price);
      Assert.AreEqual(expectedChanges.Object.product_name, productDataList[0].product_name);
      Assert.AreEqual(expectedChanges.Object.stock, productDataList[0].stock);
      Assert.AreEqual(expectedChanges.Object.tag1, productDataList[0].tag1);
      Assert.AreEqual(expectedChanges.Object.tag2, productDataList[0].tag2);
      Assert.AreEqual(expectedChanges.Object.tag3, productDataList[0].tag3);
    }
  }
}
