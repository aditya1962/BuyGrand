﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Application_Seller.AddProductReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/")]
    [System.SerializableAttribute()]
    public partial class Category : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string categoryNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string subcategoryNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string categoryName {
            get {
                return this.categoryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.categoryNameField, value) != true)) {
                    this.categoryNameField = value;
                    this.RaisePropertyChanged("categoryName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string subcategoryName {
            get {
                return this.subcategoryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.subcategoryNameField, value) != true)) {
                    this.subcategoryNameField = value;
                    this.RaisePropertyChanged("subcategoryName");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/", ConfigurationName="AddProductReference.AddProductSoap")]
    public interface AddProductSoap {
        
        // CODEGEN: Generating message contract since element name description from namespace http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/AddItem", ReplyAction="*")]
        Order_Application_Seller.AddProductReference.AddItemResponse AddItem(Order_Application_Seller.AddProductReference.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/AddItem", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.AddItemResponse> AddItemAsync(Order_Application_Seller.AddProductReference.AddItemRequest request);
        
        // CODEGEN: Generating message contract since element name getCategoryNamesResult from namespace http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/getCategoryNames", ReplyAction="*")]
        Order_Application_Seller.AddProductReference.getCategoryNamesResponse getCategoryNames(Order_Application_Seller.AddProductReference.getCategoryNamesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/getCategoryNames", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.getCategoryNamesResponse> getCategoryNamesAsync(Order_Application_Seller.AddProductReference.getCategoryNamesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddItem", Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/", Order=0)]
        public Order_Application_Seller.AddProductReference.AddItemRequestBody Body;
        
        public AddItemRequest() {
        }
        
        public AddItemRequest(Order_Application_Seller.AddProductReference.AddItemRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/")]
    public partial class AddItemRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string description;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string name;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public double price;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string imagePath;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public int quantity;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string category;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string subcategory;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string username;
        
        public AddItemRequestBody() {
        }
        
        public AddItemRequestBody(string description, string name, double price, string imagePath, int quantity, string category, string subcategory, string username) {
            this.description = description;
            this.name = name;
            this.price = price;
            this.imagePath = imagePath;
            this.quantity = quantity;
            this.category = category;
            this.subcategory = subcategory;
            this.username = username;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddItemResponse", Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/", Order=0)]
        public Order_Application_Seller.AddProductReference.AddItemResponseBody Body;
        
        public AddItemResponse() {
        }
        
        public AddItemResponse(Order_Application_Seller.AddProductReference.AddItemResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/")]
    public partial class AddItemResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int AddItemResult;
        
        public AddItemResponseBody() {
        }
        
        public AddItemResponseBody(int AddItemResult) {
            this.AddItemResult = AddItemResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getCategoryNamesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getCategoryNames", Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/", Order=0)]
        public Order_Application_Seller.AddProductReference.getCategoryNamesRequestBody Body;
        
        public getCategoryNamesRequest() {
        }
        
        public getCategoryNamesRequest(Order_Application_Seller.AddProductReference.getCategoryNamesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class getCategoryNamesRequestBody {
        
        public getCategoryNamesRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getCategoryNamesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getCategoryNamesResponse", Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/", Order=0)]
        public Order_Application_Seller.AddProductReference.getCategoryNamesResponseBody Body;
        
        public getCategoryNamesResponse() {
        }
        
        public getCategoryNamesResponse(Order_Application_Seller.AddProductReference.getCategoryNamesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/AddProduct.asmx/")]
    public partial class getCategoryNamesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Order_Application_Seller.AddProductReference.Category[] getCategoryNamesResult;
        
        public getCategoryNamesResponseBody() {
        }
        
        public getCategoryNamesResponseBody(Order_Application_Seller.AddProductReference.Category[] getCategoryNamesResult) {
            this.getCategoryNamesResult = getCategoryNamesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AddProductSoapChannel : Order_Application_Seller.AddProductReference.AddProductSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddProductSoapClient : System.ServiceModel.ClientBase<Order_Application_Seller.AddProductReference.AddProductSoap>, Order_Application_Seller.AddProductReference.AddProductSoap {
        
        public AddProductSoapClient() {
        }
        
        public AddProductSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AddProductSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddProductSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddProductSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Order_Application_Seller.AddProductReference.AddItemResponse Order_Application_Seller.AddProductReference.AddProductSoap.AddItem(Order_Application_Seller.AddProductReference.AddItemRequest request) {
            return base.Channel.AddItem(request);
        }
        
        public int AddItem(string description, string name, double price, string imagePath, int quantity, string category, string subcategory, string username) {
            Order_Application_Seller.AddProductReference.AddItemRequest inValue = new Order_Application_Seller.AddProductReference.AddItemRequest();
            inValue.Body = new Order_Application_Seller.AddProductReference.AddItemRequestBody();
            inValue.Body.description = description;
            inValue.Body.name = name;
            inValue.Body.price = price;
            inValue.Body.imagePath = imagePath;
            inValue.Body.quantity = quantity;
            inValue.Body.category = category;
            inValue.Body.subcategory = subcategory;
            inValue.Body.username = username;
            Order_Application_Seller.AddProductReference.AddItemResponse retVal = ((Order_Application_Seller.AddProductReference.AddProductSoap)(this)).AddItem(inValue);
            return retVal.Body.AddItemResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.AddItemResponse> Order_Application_Seller.AddProductReference.AddProductSoap.AddItemAsync(Order_Application_Seller.AddProductReference.AddItemRequest request) {
            return base.Channel.AddItemAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.AddItemResponse> AddItemAsync(string description, string name, double price, string imagePath, int quantity, string category, string subcategory, string username) {
            Order_Application_Seller.AddProductReference.AddItemRequest inValue = new Order_Application_Seller.AddProductReference.AddItemRequest();
            inValue.Body = new Order_Application_Seller.AddProductReference.AddItemRequestBody();
            inValue.Body.description = description;
            inValue.Body.name = name;
            inValue.Body.price = price;
            inValue.Body.imagePath = imagePath;
            inValue.Body.quantity = quantity;
            inValue.Body.category = category;
            inValue.Body.subcategory = subcategory;
            inValue.Body.username = username;
            return ((Order_Application_Seller.AddProductReference.AddProductSoap)(this)).AddItemAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Order_Application_Seller.AddProductReference.getCategoryNamesResponse Order_Application_Seller.AddProductReference.AddProductSoap.getCategoryNames(Order_Application_Seller.AddProductReference.getCategoryNamesRequest request) {
            return base.Channel.getCategoryNames(request);
        }
        
        public Order_Application_Seller.AddProductReference.Category[] getCategoryNames() {
            Order_Application_Seller.AddProductReference.getCategoryNamesRequest inValue = new Order_Application_Seller.AddProductReference.getCategoryNamesRequest();
            inValue.Body = new Order_Application_Seller.AddProductReference.getCategoryNamesRequestBody();
            Order_Application_Seller.AddProductReference.getCategoryNamesResponse retVal = ((Order_Application_Seller.AddProductReference.AddProductSoap)(this)).getCategoryNames(inValue);
            return retVal.Body.getCategoryNamesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.getCategoryNamesResponse> Order_Application_Seller.AddProductReference.AddProductSoap.getCategoryNamesAsync(Order_Application_Seller.AddProductReference.getCategoryNamesRequest request) {
            return base.Channel.getCategoryNamesAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.getCategoryNamesResponse> getCategoryNamesAsync() {
            Order_Application_Seller.AddProductReference.getCategoryNamesRequest inValue = new Order_Application_Seller.AddProductReference.getCategoryNamesRequest();
            inValue.Body = new Order_Application_Seller.AddProductReference.getCategoryNamesRequestBody();
            return ((Order_Application_Seller.AddProductReference.AddProductSoap)(this)).getCategoryNamesAsync(inValue);
        }
    }
}
