﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DatabaseModel.Select
{
    public class FindCustomer
    {
        private ECommerceEntities context;

        public FindCustomer(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public List<CustomerData> GetAllCustomers()
        {
            using (context)
            {
                List<CustomerData> customers = context.CustomerDatas.ToList<CustomerData>();
                return customers;  
            }
        }

        public CustomerData GetCustomerByID(int ID)
        {
            using (context)
            {
                CustomerData customer = context.CustomerDatas.Where<CustomerData>(c => c.c_id == ID).FirstOrDefault();
                return customer;
            }
        }
    }
}
