﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Application_Seller.FeedbacksReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Feedback", Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/")]
    [System.SerializableAttribute()]
    public partial class Feedback : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string messageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string submittedDateField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                if ((object.ReferenceEquals(this.messageField, value) != true)) {
                    this.messageField = value;
                    this.RaisePropertyChanged("message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string submittedDate {
            get {
                return this.submittedDateField;
            }
            set {
                if ((object.ReferenceEquals(this.submittedDateField, value) != true)) {
                    this.submittedDateField = value;
                    this.RaisePropertyChanged("submittedDate");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/", ConfigurationName="FeedbacksReference.GetFeedbacksSoap")]
    public interface GetFeedbacksSoap {
        
        // CODEGEN: Generating message contract since element name username from namespace http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/ViewFeedbacks", ReplyAction="*")]
        Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponse ViewFeedbacks(Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/ViewFeedbacks", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponse> ViewFeedbacksAsync(Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest request);
        
        // CODEGEN: Generating message contract since element name reply from namespace http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/addReplyToFeedback", ReplyAction="*")]
        Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponse addReplyToFeedback(Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/addReplyToFeedback", ReplyAction="*")]
        System.Threading.Tasks.Task<Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponse> addReplyToFeedbackAsync(Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ViewFeedbacksRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ViewFeedbacks", Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/", Order=0)]
        public Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequestBody Body;
        
        public ViewFeedbacksRequest() {
        }
        
        public ViewFeedbacksRequest(Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/")]
    public partial class ViewFeedbacksRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string username;
        
        public ViewFeedbacksRequestBody() {
        }
        
        public ViewFeedbacksRequestBody(string username) {
            this.username = username;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ViewFeedbacksResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ViewFeedbacksResponse", Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/", Order=0)]
        public Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponseBody Body;
        
        public ViewFeedbacksResponse() {
        }
        
        public ViewFeedbacksResponse(Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/")]
    public partial class ViewFeedbacksResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Order_Application_Seller.FeedbacksReference.Feedback[] ViewFeedbacksResult;
        
        public ViewFeedbacksResponseBody() {
        }
        
        public ViewFeedbacksResponseBody(Order_Application_Seller.FeedbacksReference.Feedback[] ViewFeedbacksResult) {
            this.ViewFeedbacksResult = ViewFeedbacksResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class addReplyToFeedbackRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="addReplyToFeedback", Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/", Order=0)]
        public Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequestBody Body;
        
        public addReplyToFeedbackRequest() {
        }
        
        public addReplyToFeedbackRequest(Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/")]
    public partial class addReplyToFeedbackRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int originalID;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string reply;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string username;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string datetime;
        
        public addReplyToFeedbackRequestBody() {
        }
        
        public addReplyToFeedbackRequestBody(int originalID, string reply, string username, string datetime) {
            this.originalID = originalID;
            this.reply = reply;
            this.username = username;
            this.datetime = datetime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class addReplyToFeedbackResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="addReplyToFeedbackResponse", Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/", Order=0)]
        public Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponseBody Body;
        
        public addReplyToFeedbackResponse() {
        }
        
        public addReplyToFeedbackResponse(Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/")]
    public partial class addReplyToFeedbackResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int addReplyToFeedbackResult;
        
        public addReplyToFeedbackResponseBody() {
        }
        
        public addReplyToFeedbackResponseBody(int addReplyToFeedbackResult) {
            this.addReplyToFeedbackResult = addReplyToFeedbackResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetFeedbacksSoapChannel : Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetFeedbacksSoapClient : System.ServiceModel.ClientBase<Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap>, Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap {
        
        public GetFeedbacksSoapClient() {
        }
        
        public GetFeedbacksSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetFeedbacksSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetFeedbacksSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetFeedbacksSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponse Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap.ViewFeedbacks(Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest request) {
            return base.Channel.ViewFeedbacks(request);
        }
        
        public Order_Application_Seller.FeedbacksReference.Feedback[] ViewFeedbacks(string username) {
            Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest inValue = new Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest();
            inValue.Body = new Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequestBody();
            inValue.Body.username = username;
            Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponse retVal = ((Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap)(this)).ViewFeedbacks(inValue);
            return retVal.Body.ViewFeedbacksResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponse> Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap.ViewFeedbacksAsync(Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest request) {
            return base.Channel.ViewFeedbacksAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.FeedbacksReference.ViewFeedbacksResponse> ViewFeedbacksAsync(string username) {
            Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest inValue = new Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequest();
            inValue.Body = new Order_Application_Seller.FeedbacksReference.ViewFeedbacksRequestBody();
            inValue.Body.username = username;
            return ((Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap)(this)).ViewFeedbacksAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponse Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap.addReplyToFeedback(Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest request) {
            return base.Channel.addReplyToFeedback(request);
        }
        
        public int addReplyToFeedback(int originalID, string reply, string username, string datetime) {
            Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest inValue = new Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest();
            inValue.Body = new Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequestBody();
            inValue.Body.originalID = originalID;
            inValue.Body.reply = reply;
            inValue.Body.username = username;
            inValue.Body.datetime = datetime;
            Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponse retVal = ((Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap)(this)).addReplyToFeedback(inValue);
            return retVal.Body.addReplyToFeedbackResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponse> Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap.addReplyToFeedbackAsync(Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest request) {
            return base.Channel.addReplyToFeedbackAsync(request);
        }
        
        public System.Threading.Tasks.Task<Order_Application_Seller.FeedbacksReference.addReplyToFeedbackResponse> addReplyToFeedbackAsync(int originalID, string reply, string username, string datetime) {
            Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest inValue = new Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequest();
            inValue.Body = new Order_Application_Seller.FeedbacksReference.addReplyToFeedbackRequestBody();
            inValue.Body.originalID = originalID;
            inValue.Body.reply = reply;
            inValue.Body.username = username;
            inValue.Body.datetime = datetime;
            return ((Order_Application_Seller.FeedbacksReference.GetFeedbacksSoap)(this)).addReplyToFeedbackAsync(inValue);
        }
    }
}