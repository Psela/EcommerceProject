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
    }
}
