﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceProject.AdminPortal.ServiceHostReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceHostReference.IDataRetrieverService")]
    public interface IDataRetrieverService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/ReadData", ReplyAction="http://tempuri.org/IDataRetrieverService/ReadDataResponse")]
        EcommerceProject.DatabaseModel.ProductData[] ReadData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/ReadData", ReplyAction="http://tempuri.org/IDataRetrieverService/ReadDataResponse")]
        System.Threading.Tasks.Task<EcommerceProject.DatabaseModel.ProductData[]> ReadDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/SearchData", ReplyAction="http://tempuri.org/IDataRetrieverService/SearchDataResponse")]
        EcommerceProject.DatabaseModel.ProductData[] SearchData(string searchFor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/SearchData", ReplyAction="http://tempuri.org/IDataRetrieverService/SearchDataResponse")]
        System.Threading.Tasks.Task<EcommerceProject.DatabaseModel.ProductData[]> SearchDataAsync(string searchFor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/FindById", ReplyAction="http://tempuri.org/IDataRetrieverService/FindByIdResponse")]
        EcommerceProject.DatabaseModel.ProductData FindById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/FindById", ReplyAction="http://tempuri.org/IDataRetrieverService/FindByIdResponse")]
        System.Threading.Tasks.Task<EcommerceProject.DatabaseModel.ProductData> FindByIdAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/CreateNewProductItem", ReplyAction="http://tempuri.org/IDataRetrieverService/CreateNewProductItemResponse")]
        void CreateNewProductItem(EcommerceProject.DatabaseModel.ProductData product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataRetrieverService/CreateNewProductItem", ReplyAction="http://tempuri.org/IDataRetrieverService/CreateNewProductItemResponse")]
        System.Threading.Tasks.Task CreateNewProductItemAsync(EcommerceProject.DatabaseModel.ProductData product);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataRetrieverServiceChannel : EcommerceProject.AdminPortal.ServiceHostReference.IDataRetrieverService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataRetrieverServiceClient : System.ServiceModel.ClientBase<EcommerceProject.AdminPortal.ServiceHostReference.IDataRetrieverService>, EcommerceProject.AdminPortal.ServiceHostReference.IDataRetrieverService {
        
        public DataRetrieverServiceClient() {
        }
        
        public DataRetrieverServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataRetrieverServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataRetrieverServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataRetrieverServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EcommerceProject.DatabaseModel.ProductData[] ReadData() {
            return base.Channel.ReadData();
        }
        
        public System.Threading.Tasks.Task<EcommerceProject.DatabaseModel.ProductData[]> ReadDataAsync() {
            return base.Channel.ReadDataAsync();
        }
        
        public EcommerceProject.DatabaseModel.ProductData[] SearchData(string searchFor) {
            return base.Channel.SearchData(searchFor);
        }
        
        public System.Threading.Tasks.Task<EcommerceProject.DatabaseModel.ProductData[]> SearchDataAsync(string searchFor) {
            return base.Channel.SearchDataAsync(searchFor);
        }
        
        public EcommerceProject.DatabaseModel.ProductData FindById(string id) {
            return base.Channel.FindById(id);
        }
        
        public System.Threading.Tasks.Task<EcommerceProject.DatabaseModel.ProductData> FindByIdAsync(string id) {
            return base.Channel.FindByIdAsync(id);
        }
              
        public void CreateNewProductItem(EcommerceProject.DatabaseModel.ProductData product) {
            base.Channel.CreateNewProductItem(product);
        }
        
        public System.Threading.Tasks.Task CreateNewProductItemAsync(EcommerceProject.DatabaseModel.ProductData product) {
            return base.Channel.CreateNewProductItemAsync(product);
        }
    }
}
