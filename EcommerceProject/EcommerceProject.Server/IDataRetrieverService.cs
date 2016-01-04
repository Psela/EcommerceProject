using EcommerceProject.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Server
{
    [ServiceContract]
    public interface IDataRetrieverService
    {
        [OperationContract]
        List<ProductData> ReadData();

        [OperationContract]
        List<ProductData> SearchData();
    }
}
