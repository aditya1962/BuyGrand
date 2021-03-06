﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Application_Admin.ManageSellerReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/ManageSeller.asmx/", ConfigurationName="ManageSellerReference.ManageSellerSoap")]
    public interface ManageSellerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ManageSeller.asmx/manageSellers", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable manageSellers(int startindex, int endindex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ManageSeller.asmx/manageSellers", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> manageSellersAsync(int startindex, int endindex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ManageSeller.asmx/delete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int delete(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ManageSeller.asmx/delete", ReplyAction="*")]
        System.Threading.Tasks.Task<int> deleteAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ManageSeller.asmx/getEmail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string getEmail(string username, int startindex, int endindex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ManageSeller.asmx/getEmail", ReplyAction="*")]
        System.Threading.Tasks.Task<string> getEmailAsync(string username, int startindex, int endindex);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ManageSellerSoapChannel : Order_Application_Admin.ManageSellerReference.ManageSellerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManageSellerSoapClient : System.ServiceModel.ClientBase<Order_Application_Admin.ManageSellerReference.ManageSellerSoap>, Order_Application_Admin.ManageSellerReference.ManageSellerSoap {
        
        public ManageSellerSoapClient() {
        }
        
        public ManageSellerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManageSellerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageSellerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManageSellerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable manageSellers(int startindex, int endindex) {
            return base.Channel.manageSellers(startindex, endindex);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> manageSellersAsync(int startindex, int endindex) {
            return base.Channel.manageSellersAsync(startindex, endindex);
        }
        
        public int delete(string username) {
            return base.Channel.delete(username);
        }
        
        public System.Threading.Tasks.Task<int> deleteAsync(string username) {
            return base.Channel.deleteAsync(username);
        }
        
        public string getEmail(string username, int startindex, int endindex) {
            return base.Channel.getEmail(username, startindex, endindex);
        }
        
        public System.Threading.Tasks.Task<string> getEmailAsync(string username, int startindex, int endindex) {
            return base.Channel.getEmailAsync(username, startindex, endindex);
        }
    }
}
