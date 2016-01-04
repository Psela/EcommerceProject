using EcommerceProject.DatabaseModel;
using EcommerceProject.DatabaseModel.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcommerceProject.Server
{
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

        public ProductData FindById(string id)
        {
            try
            {
                int a = 0;
                if (int.TryParse(id, out a))
                {
                    int ID = int.Parse(id ?? "1");
                    if (ID != 0)
                    {
                        id = ID.ToString();
                        ProductData product = dbFind.GetAllProducts().Where<ProductData>(x => x.p_id == ID).FirstOrDefault();
                        return product;
                    }
                }

                ProductData p;
                return p = dbFind.GetAllProducts().Where<ProductData>(x => x.p_id == 1).First();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
