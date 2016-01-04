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
    [TestMethod]
    public void test_thatGetAllProducts_returnsAListOfProductData_whenCalled()
    {
      //Arrange
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<ProductData> productDataList = new List<ProductData>();
      Mock<ProductData> mockProductData = new Mock<ProductData>();
      mockProductData.SetupAllProperties();

      productDataList.Add(mockProductData.Object);

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);
      context.SetupAllProperties();
      context.Object.ProductDatas = mockedDataSet;

      FindProduct findProduct = new FindProduct(context.Object);

      //Act
      List<ProductData> list = findProduct.GetAllProducts();

      //Assert
      CollectionAssert.AreEqual(productDataList, list);
    }

    [TestMethod]
    public void test_thatGetAllOrders_returnsOrderHistory_whenCalled()
    {
      //Arrange
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<OrderHistory> orderHistoryList = new List<OrderHistory>();
      Mock<OrderHistory> mockOrderHistory = new Mock<OrderHistory>();
      mockOrderHistory.SetupAllProperties();

      orderHistoryList.Add(mockOrderHistory.Object);

      DbSet<OrderHistory> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<OrderHistory>(orderHistoryList);
      context.SetupAllProperties();
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
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<CustomerData> customerList = new List<CustomerData>();
      Mock<CustomerData> mockCustomers = new Mock<CustomerData>();
      mockCustomers.SetupAllProperties();

      customerList.Add(mockCustomers.Object);

      DbSet<CustomerData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<CustomerData>(customerList);
      context.SetupAllProperties();
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
      Mock<ECommerceEntities> mockContext = new Mock<ECommerceEntities>();
      List<CustomerData> mockCustomerList = new List<CustomerData>();
      Mock<CustomerData> mockCustomers = new Mock<CustomerData>();
      mockCustomers.SetupAllProperties();
      mockCustomers.Object.c_id = 1;
      mockCustomerList.Add(mockCustomers.Object);

      DbSet<CustomerData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<CustomerData>(mockCustomerList);
      mockContext.SetupAllProperties();
      mockContext.Object.CustomerDatas = mockedDataSet;

      FindCustomer findCustomerByID = new FindCustomer(mockContext.Object);

      //Act
      CustomerData returnedCustomer = findCustomerByID.GetCustomerByID(1);

      //Assert
      Assert.AreEqual(mockCustomers.Object, returnedCustomer);
    }

    [TestMethod]
    public void test_thatGetProductByID_returnsAProductDataObject_whenCalledWithAValidID()
    {
      //Arrange
      Mock<ECommerceEntities> mockContext = new Mock<ECommerceEntities>();
      List<ProductData> mockProductList = new List<ProductData>();
      Mock<ProductData> mockProducts = new Mock<ProductData>();
      mockProducts.SetupAllProperties();
      mockProducts.Object.p_id = 1;
      mockProductList.Add(mockProducts.Object);

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(mockProductList);
      mockContext.SetupAllProperties();
      mockContext.Object.ProductDatas = mockedDataSet;

      FindProduct findProductByID = new FindProduct(mockContext.Object);

      //Act
      ProductData returnedProduct = findProductByID.GetProductByID(1);

      //Assert
      Assert.AreEqual(mockProducts.Object, returnedProduct);
    }

    [TestMethod]
    public void test_thatGetOrderByID_returnsAnOrderHistoryObject_whenCalledWithAValidID()
    {
      //Arrange
      Mock<ECommerceEntities> mockContext = new Mock<ECommerceEntities>();
      List<OrderHistory> mockOrderList = new List<OrderHistory>();
      Mock<OrderHistory> mockOrders = new Mock<OrderHistory>();
      mockOrders.SetupAllProperties();
      mockOrders.Object.order_number = 1;
      mockOrderList.Add(mockOrders.Object);

      DbSet<OrderHistory> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<OrderHistory>(mockOrderList);
      mockContext.SetupAllProperties();
      mockContext.Object.OrderHistories = mockedDataSet;

      FindOrder findOrderByID = new FindOrder(mockContext.Object);

      //Act
      OrderHistory returnedOrder = findOrderByID.GetOrderByID(1);

      //Assert
      Assert.AreEqual(mockOrders.Object, returnedOrder);
    }

    [TestMethod]
    public void test_thatAddNewProduct_addsANewProductToTheDatabase_whenCalledWithValidParameters()
    {
      //Arrange
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<ProductData> productDataList = new List<ProductData>();
      Mock<ProductData> mockProductData = new Mock<ProductData>();
      mockProductData.SetupAllProperties();

      productDataList.Add(mockProductData.Object);

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);
      context.SetupAllProperties();
      context.Object.ProductDatas = mockedDataSet;

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
      Mock<ECommerceEntities> context = new Mock<ECommerceEntities>();
      List<ProductData> productDataList = new List<ProductData>();

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);
      context.SetupAllProperties();
      context.Object.ProductDatas = mockedDataSet;

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
      Assert.AreEqual(product, productDataList[0]);
      //Assert.AreEqual(product.product_name, productDataList[0].product_name);
      //Assert.AreEqual(product.description, productDataList[0].description);
      //Assert.AreEqual(product.imageurl, productDataList[0].imageurl);
      //Assert.AreEqual(product.price, productDataList[0].price);
      //Assert.AreEqual(product.stock, productDataList[0].stock);
      //Assert.AreEqual(product.tag1, productDataList[0].tag1);
      //Assert.AreEqual(product.tag2, productDataList[0].tag2);
      //Assert.AreEqual(product.tag3, productDataList[0].tag3);
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
      Mock<ECommerceEntities> mockContext = new Mock<ECommerceEntities>();
      List<ProductData> productDataList = new List<ProductData>();

      DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);

      mockContext.SetupAllProperties();
      mockContext.Object.ProductDatas = mockedDataSet;

      EditProduct updateProduct = new EditProduct(mockContext.Object);

      //Act
      updateProduct.UpdateProduct(null,null);

      //Assert
      mockContext.Verify(c => c.SaveChanges(), Times.Once);
    }

    //[TestMethod]
    //public void test_thatUpdateProduct_ChangesProductDetails_WhenGivenProductToChangeAndProductWithNewDetails()
    //{
    //  //Arrange
    //  ProductData originalProduct = new ProductData() { p_id = 1 };

    //  Mock<ECommerceEntities> mockContext = new Mock<ECommerceEntities>();
    //  List<ProductData> productDataList = new List<ProductData>();
    //  productDataList.Add(originalProduct);

    //  DbSet<ProductData> mockedDataSet = GetQueryableMockSet.GetQueryableMockDbSet<ProductData>(productDataList);

    //  mockContext.SetupAllProperties();
    //  mockContext.Object.ProductDatas = mockedDataSet;

    //  EditProduct updateProduct = new EditProduct(mockContext.Object);

    //  ProductData expectedChanges = new ProductData() { p_id = 1, product_name="UpdatedProduct" };

    //  //Act
    //  updateProduct.UpdateProduct(originalProduct,expectedChanges);

    //  //Assert
    //  Assert.AreEqual(expectedChanges, originalProduct);
    //}
  }
}
