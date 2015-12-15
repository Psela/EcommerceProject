using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DatabaseModel.Select
{
    public class FindOrder
    {
        private ECommerceEntities context;

        public FindOrder(ECommerceEntities eCommerceEntities)
        {
            context = eCommerceEntities;
        }

        public List<OrderHistory> GetAllOrders()
        {
            using (context)
            {
                List<OrderHistory> orders = context.OrderHistories.ToList<OrderHistory>();
                return orders;
            }
        }

        public OrderHistory GetOrderByID(int ID)
        {
            using (context)
            {
                OrderHistory order = context.OrderHistories.Where<OrderHistory>(o => o.order_number == ID).FirstOrDefault();
                return order;
            }
        }
    }
}
