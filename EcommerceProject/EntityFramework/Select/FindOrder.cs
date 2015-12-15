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
    }
}
