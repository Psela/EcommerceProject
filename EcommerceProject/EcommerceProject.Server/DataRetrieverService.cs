using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Add;
using EcommerceProject.DatabaseModel.Delete;
using EcommerceProject.DatabaseModel.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace EcommerceProject.Server
{
  //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class DataRetrieverService : IDataRetrieverService
  {
    FindProduct dbFind;

    public DataRetrieverService(FindProduct findProduct)
    {
      dbFind = findProduct;
    }

    public DataRetrieverService()
    {
      dbFind = new FindProduct();
    }

    public virtual List<ProductData> ReadData()
    {
      List<ProductData> products = dbFind.GetAllProducts();
      return products;
    }

    public virtual List<ProductData> SearchData(string searchFor)
    {
      List<ProductData> listOfProducts = ReadData();
      List<ProductData> foundProduct = new List<ProductData>();

      foreach (ProductData product in listOfProducts)
      {
        int id = 0;
        if (int.TryParse(searchFor, out id))
        {
          if (product.p_id == id)
          {
            foundProduct.Clear();
            foundProduct.Add(product);
            break;
          }
        }
        if (
          product.product_name.ToLower().Contains(searchFor.ToLower()) ||
          product.tag1.ToLower() == searchFor.ToLower() ||
          product.tag2.ToLower() == searchFor.ToLower() ||
          product.tag3.ToLower() == searchFor.ToLower() ||
          product.description.ToLower().Contains(searchFor.ToLower()))
        {
          foundProduct.Add(product);
        }
      }

      return foundProduct;
    }

    public virtual ProductData FindById(string id)
    {
      ProductData product = new ProductData();
      int a = 0;
      if (int.TryParse(id, out a))
      {
        int ID = int.Parse(id ?? "1");
        if (ID != 0)
        {
          product = dbFind.GetProductByID(ID);
        }
      }

      return product;
    }

    public void RemoveById(int id)
    {
      RemoveProduct remove = new RemoveProduct();
      remove.DeleteProductByID(id);
    }

    public void CreateNewProductItem(ProductData product)
    {
      NewProduct newProduct = new NewProduct();
      // validateInput();
      newProduct.CreateNewProduct(product);
    }

    private Dictionary<ProductData, int> _basket;

    public Dictionary<ProductData, int> GetBasket()
    {
      if (_basket == null)
      {
        _basket = new Dictionary<ProductData, int>();
      }
      return _basket;
    }

    public void AddToBasket(ProductData product, int amount)
    {
      _basket.Add(product, amount);
    }

  }
}
