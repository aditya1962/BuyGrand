﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Application_Seller.YourItemReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Item", Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/")]
    [System.SerializableAttribute()]
    public partial class Item : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        private double priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string image_pathField;
        
        private double discountField;
        
        private double ratingField;
        
        private int ratingCountField;
        
        private int order_countField;
        
        private int quantity_availableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string categoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string subcategoryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public double price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string image_path {
            get {
                return this.image_pathField;
            }
            set {
                if ((object.ReferenceEquals(this.image_pathField, value) != true)) {
                    this.image_pathField = value;
                    this.RaisePropertyChanged("image_path");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public double discount {
            get {
                return this.discountField;
            }
            set {
                if ((this.discountField.Equals(value) != true)) {
                    this.discountField = value;
                    this.RaisePropertyChanged("discount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public double rating {
            get {
                return this.ratingField;
            }
            set {
                if ((this.ratingField.Equals(value) != true)) {
                    this.ratingField = value;
                    this.RaisePropertyChanged("rating");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int ratingCount {
            get {
                return this.ratingCountField;
            }
            set {
                if ((this.ratingCountField.Equals(value) != true)) {
                    this.ratingCountField = value;
                    this.RaisePropertyChanged("ratingCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public int order_count {
            get {
                return this.order_countField;
            }
            set {
                if ((this.order_countField.Equals(value) != true)) {
                    this.order_countField = value;
                    this.RaisePropertyChanged("order_count");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public int quantity_available {
            get {
                return this.quantity_availableField;
            }
            set {
                if ((this.quantity_availableField.Equals(value) != true)) {
                    this.quantity_availableField = value;
                    this.RaisePropertyChanged("quantity_available");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string category {
            get {
                return this.categoryField;
            }
            set {
                if ((object.ReferenceEquals(this.categoryField, value) != true)) {
                    this.categoryField = value;
                    this.RaisePropertyChanged("category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string subcategory {
            get {
                return this.subcategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.subcategoryField, value) != true)) {
                    this.subcategoryField = value;
                    this.RaisePropertyChanged("subcategory");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/", ConfigurationName="YourItemReference.UserItemSoap")]
    public interface UserItemSoap {
        
        // CODEGEN: Generating message contract since element name username from namespace http://localhost/ServiceBuyGrandSeller/UserItem.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/items", ReplyAction="*")]
        Order_Application_Seller.YourItemReference.itemsResponse items(Order_Application_Seller.YourItemReference.itemsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/items", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.YourItemReference.itemsResponse> itemsAsync(Order_Application_Seller.YourItemReference.itemsRequest request);
        
        // CODEGEN: Generating message contract since element name username from namespace http://localhost/ServiceBuyGrandSeller/UserItem.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/itemCount", ReplyAction="*")]
        Order_Application_Seller.YourItemReference.itemCountResponse itemCount(Order_Application_Seller.YourItemReference.itemCountRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/itemCount", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.YourItemReference.itemCountResponse> itemCountAsync(Order_Application_Seller.YourItemReference.itemCountRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class itemsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="items", Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/", Order=0)]
        public Order_Application_Seller.YourItemReference.itemsRequestBody Body;
        
        public itemsRequest() {
        }
        
        public itemsRequest(Order_Application_Seller.YourItemReference.itemsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/")]
    public partial class itemsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int page;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int filter;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string username;
        
        public itemsRequestBody() {
        }
        
        public itemsRequestBody(int page, int filter, string username) {
            this.page = page;
            this.filter = filter;
            this.username = username;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class itemsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="itemsResponse", Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/", Order=0)]
        public Order_Application_Seller.YourItemReference.itemsResponseBody Body;
        
        public itemsResponse() {
        }
        
        public itemsResponse(Order_Application_Seller.YourItemReference.itemsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/")]
    public partial class itemsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Order_Application_Seller.YourItemReference.Item[] itemsResult;
        
        public itemsResponseBody() {
        }
        
        public itemsResponseBody(Order_Application_Seller.YourItemReference.Item[] itemsResult) {
            this.itemsResult = itemsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class itemCountRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="itemCount", Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/", Order=0)]
        public Order_Application_Seller.YourItemReference.itemCountRequestBody Body;
        
        public itemCountRequest() {
        }
        
        public itemCountRequest(Order_Application_Seller.YourItemReference.itemCountRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/")]
    public partial class itemCountRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string username;
        
        public itemCountRequestBody() {
        }
        
        public itemCountRequestBody(string username) {
            this.username = username;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class itemCountResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="itemCountResponse", Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/", Order=0)]
        public Order_Application_Seller.YourItemReference.itemCountResponseBody Body;
        
        public itemCountResponse() {
        }
        
        public itemCountResponse(Order_Application_Seller.YourItemReference.itemCountResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/UserItem.asmx/")]
    public partial class itemCountResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int itemCountResult;
        
        public itemCountResponseBody() {
        }
        
        public itemCountResponseBody(int itemCountResult) {
            this.itemCountResult = itemCountResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UserItemSoapChannel : Order_Application_Seller.YourItemReference.UserItemSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserItemSoapClient : System.ServiceModel.ClientBase<Order_Application_Seller.YourItemReference.UserItemSoap>, Order_Application_Seller.YourItemReference.UserItemSoap {
        
        public UserItemSoapClient() {
        }
        
        public UserItemSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserItemSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserItemSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserItemSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Order_Application_Seller.YourItemReference.itemsResponse Order_Application_Seller.YourItemReference.UserItemSoap.items(Order_Application_Seller.YourItemReference.itemsRequest request) {
            return base.Channel.items(request);
        }
        
        public Order_Application_Seller.YourItemReference.Item[] items(int page, int filter, string username) {
            Order_Application_Seller.YourItemReference.itemsRequest inValue = new Order_Application_Seller.YourItemReference.itemsRequest();
            inValue.Body = new Order_Application_Seller.YourItemReference.itemsRequestBody();
            inValue.Body.page = page;
            inValue.Body.filter = filter;
            inValue.Body.username = username;
            Order_Application_Seller.YourItemReference.itemsResponse retVal = ((Order_Application_Seller.YourItemReference.UserItemSoap)(this)).items(inValue);
            return retVal.Body.itemsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.YourItemReference.itemsResponse> Order_Application_Seller.YourItemReference.UserItemSoap.itemsAsync(Order_Application_Seller.YourItemReference.itemsRequest request) {
            return base.Channel.itemsAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.YourItemReference.itemsResponse> itemsAsync(int page, int filter, string username) {
            Order_Application_Seller.YourItemReference.itemsRequest inValue = new Order_Application_Seller.YourItemReference.itemsRequest();
            inValue.Body = new Order_Application_Seller.YourItemReference.itemsRequestBody();
            inValue.Body.page = page;
            inValue.Body.filter = filter;
            inValue.Body.username = username;
            return ((Order_Application_Seller.YourItemReference.UserItemSoap)(this)).itemsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Order_Application_Seller.YourItemReference.itemCountResponse Order_Application_Seller.YourItemReference.UserItemSoap.itemCount(Order_Application_Seller.YourItemReference.itemCountRequest request) {
            return base.Channel.itemCount(request);
        }
        
        public int itemCount(string username) {
            Order_Application_Seller.YourItemReference.itemCountRequest inValue = new Order_Application_Seller.YourItemReference.itemCountRequest();
            inValue.Body = new Order_Application_Seller.YourItemReference.itemCountRequestBody();
            inValue.Body.username = username;
            Order_Application_Seller.YourItemReference.itemCountResponse retVal = ((Order_Application_Seller.YourItemReference.UserItemSoap)(this)).itemCount(inValue);
            return retVal.Body.itemCountResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.YourItemReference.itemCountResponse> Order_Application_Seller.YourItemReference.UserItemSoap.itemCountAsync(Order_Application_Seller.YourItemReference.itemCountRequest request) {
            return base.Channel.itemCountAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.YourItemReference.itemCountResponse> itemCountAsync(string username) {
            Order_Application_Seller.YourItemReference.itemCountRequest inValue = new Order_Application_Seller.YourItemReference.itemCountRequest();
            inValue.Body = new Order_Application_Seller.YourItemReference.itemCountRequestBody();
            inValue.Body.username = username;
            return ((Order_Application_Seller.YourItemReference.UserItemSoap)(this)).itemCountAsync(inValue);
        }
    }
}
