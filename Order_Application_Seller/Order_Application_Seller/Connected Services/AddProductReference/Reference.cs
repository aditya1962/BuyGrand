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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/AddProduct.asmx/", ConfigurationName="AddProductReference.AddProductSoap")]
    public interface AddProductSoap {
        
        // CODEGEN: Generating message contract since element name description from namespace http://localhost/AddProduct.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/AddProduct.asmx/AddItem", ReplyAction="*")]
        Order_Application_Seller.AddProductReference.AddItemResponse AddItem(Order_Application_Seller.AddProductReference.AddItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/AddProduct.asmx/AddItem", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.AddItemResponse> AddItemAsync(Order_Application_Seller.AddProductReference.AddItemRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddItem", Namespace="http://localhost/AddProduct.asmx/", Order=0)]
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
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/AddProduct.asmx/")]
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
        
        public AddItemRequestBody() {
        }
        
        public AddItemRequestBody(string description, string name, double price, string imagePath, int quantity, string category, string subcategory) {
            this.description = description;
            this.name = name;
            this.price = price;
            this.imagePath = imagePath;
            this.quantity = quantity;
            this.category = category;
            this.subcategory = subcategory;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddItemResponse", Namespace="http://localhost/AddProduct.asmx/", Order=0)]
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
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/AddProduct.asmx/")]
    public partial class AddItemResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int AddItemResult;
        
        public AddItemResponseBody() {
        }
        
        public AddItemResponseBody(int AddItemResult) {
            this.AddItemResult = AddItemResult;
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
        
        public int AddItem(string description, string name, double price, string imagePath, int quantity, string category, string subcategory) {
            Order_Application_Seller.AddProductReference.AddItemRequest inValue = new Order_Application_Seller.AddProductReference.AddItemRequest();
            inValue.Body = new Order_Application_Seller.AddProductReference.AddItemRequestBody();
            inValue.Body.description = description;
            inValue.Body.name = name;
            inValue.Body.price = price;
            inValue.Body.imagePath = imagePath;
            inValue.Body.quantity = quantity;
            inValue.Body.category = category;
            inValue.Body.subcategory = subcategory;
            Order_Application_Seller.AddProductReference.AddItemResponse retVal = ((Order_Application_Seller.AddProductReference.AddProductSoap)(this)).AddItem(inValue);
            return retVal.Body.AddItemResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.AddItemResponse> Order_Application_Seller.AddProductReference.AddProductSoap.AddItemAsync(Order_Application_Seller.AddProductReference.AddItemRequest request) {
            return base.Channel.AddItemAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.AddProductReference.AddItemResponse> AddItemAsync(string description, string name, double price, string imagePath, int quantity, string category, string subcategory) {
            Order_Application_Seller.AddProductReference.AddItemRequest inValue = new Order_Application_Seller.AddProductReference.AddItemRequest();
            inValue.Body = new Order_Application_Seller.AddProductReference.AddItemRequestBody();
            inValue.Body.description = description;
            inValue.Body.name = name;
            inValue.Body.price = price;
            inValue.Body.imagePath = imagePath;
            inValue.Body.quantity = quantity;
            inValue.Body.category = category;
            inValue.Body.subcategory = subcategory;
            return ((Order_Application_Seller.AddProductReference.AddProductSoap)(this)).AddItemAsync(inValue);
        }
    }
}