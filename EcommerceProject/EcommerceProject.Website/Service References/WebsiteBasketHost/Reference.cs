﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceProject.Website.WebsiteBasketHost {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BasketItem", Namespace="http://schemas.datacontract.org/2004/07/EcommerceProject.ServerBasket")]
    [System.SerializableAttribute()]
    public partial class BasketItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int itemCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private EcommerceProject.DatabaseModel.ProductData productField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int itemCount {
            get {
                return this.itemCountField;
            }
            set {
                if ((this.itemCountField.Equals(value) != true)) {
                    this.itemCountField = value;
                    this.RaisePropertyChanged("itemCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public EcommerceProject.DatabaseModel.ProductData product {
            get {
                return this.productField;
            }
            set {
                if ((object.ReferenceEquals(this.productField, value) != true)) {
                    this.productField = value;
                    this.RaisePropertyChanged("product");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebsiteBasketHost.IBasket")]
    public interface IBasket {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBasket/GetBasket", ReplyAction="http://tempuri.org/IBasket/GetBasketResponse")]
        System.Collections.Generic.List<EcommerceProject.Website.WebsiteBasketHost.BasketItem> GetBasket();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBasket/GetBasket", ReplyAction="http://tempuri.org/IBasket/GetBasketResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EcommerceProject.Website.WebsiteBasketHost.BasketItem>> GetBasketAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBasket/AddToBasket", ReplyAction="http://tempuri.org/IBasket/AddToBasketResponse")]
        void AddToBasket(EcommerceProject.DatabaseModel.ProductData product, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBasket/AddToBasket", ReplyAction="http://tempuri.org/IBasket/AddToBasketResponse")]
        System.Threading.Tasks.Task AddToBasketAsync(EcommerceProject.DatabaseModel.ProductData product, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBasket/EmptyBasket", ReplyAction="http://tempuri.org/IBasket/EmptyBasketResponse")]
        void EmptyBasket();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBasket/EmptyBasket", ReplyAction="http://tempuri.org/IBasket/EmptyBasketResponse")]
        System.Threading.Tasks.Task EmptyBasketAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBasketChannel : EcommerceProject.Website.WebsiteBasketHost.IBasket, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BasketClient : System.ServiceModel.ClientBase<EcommerceProject.Website.WebsiteBasketHost.IBasket>, EcommerceProject.Website.WebsiteBasketHost.IBasket {
        
        public BasketClient() {
        }
        
        public BasketClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BasketClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BasketClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BasketClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<EcommerceProject.Website.WebsiteBasketHost.BasketItem> GetBasket() {
            return base.Channel.GetBasket();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EcommerceProject.Website.WebsiteBasketHost.BasketItem>> GetBasketAsync() {
            return base.Channel.GetBasketAsync();
        }
        
        public void AddToBasket(EcommerceProject.DatabaseModel.ProductData product, int amount) {
            base.Channel.AddToBasket(product, amount);
        }
        
        public System.Threading.Tasks.Task AddToBasketAsync(EcommerceProject.DatabaseModel.ProductData product, int amount) {
            return base.Channel.AddToBasketAsync(product, amount);
        }
        
        public void EmptyBasket() {
            base.Channel.EmptyBasket();
        }
        
        public System.Threading.Tasks.Task EmptyBasketAsync() {
            return base.Channel.EmptyBasketAsync();
        }
    }
}
