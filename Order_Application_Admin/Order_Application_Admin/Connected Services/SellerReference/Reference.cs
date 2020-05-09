﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Application_Admin.SellerReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/ApproveSeller.asmx/", ConfigurationName="SellerReference.ApproveSellerSoap")]
    public interface ApproveSellerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ApproveSeller.asmx/approveSellers", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable approveSellers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ApproveSeller.asmx/approveSellers", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> approveSellersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ApproveSeller.asmx/approveSeller", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int approveSeller(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ApproveSeller.asmx/approveSeller", ReplyAction="*")]
        System.Threading.Tasks.Task<int> approveSellerAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ApproveSellerSoapChannel : Order_Application_Admin.SellerReference.ApproveSellerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ApproveSellerSoapClient : System.ServiceModel.ClientBase<Order_Application_Admin.SellerReference.ApproveSellerSoap>, Order_Application_Admin.SellerReference.ApproveSellerSoap {
        
        public ApproveSellerSoapClient() {
        }
        
        public ApproveSellerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ApproveSellerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ApproveSellerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ApproveSellerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable approveSellers() {
            return base.Channel.approveSellers();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> approveSellersAsync() {
            return base.Channel.approveSellersAsync();
        }
        
        public int approveSeller(string id) {
            return base.Channel.approveSeller(id);
        }
        
        public System.Threading.Tasks.Task<int> approveSellerAsync(string id) {
            return base.Channel.approveSellerAsync(id);
        }
    }
}