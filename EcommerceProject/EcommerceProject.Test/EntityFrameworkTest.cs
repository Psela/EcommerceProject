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
    }
}
