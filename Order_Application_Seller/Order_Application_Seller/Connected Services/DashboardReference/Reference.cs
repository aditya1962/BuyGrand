﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Order_Application_Seller.DashboardReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/ServiceBuyGrandSeller/Dashboard.asmx/", ConfigurationName="DashboardReference.DashboardSoap")]
    public interface DashboardSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/Dashboard.asmx/GetDashboard", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetDashboard();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/ServiceBuyGrandSeller/Dashboard.asmx/GetDashboard", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetDashboardAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DashboardSoapChannel : Order_Application_Seller.DashboardReference.DashboardSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DashboardSoapClient : System.ServiceModel.ClientBase<Order_Application_Seller.DashboardReference.DashboardSoap>, Order_Application_Seller.DashboardReference.DashboardSoap {
        
        public DashboardSoapClient() {
        }
        
        public DashboardSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DashboardSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DashboardSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DashboardSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetDashboard() {
            return base.Channel.GetDashboard();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetDashboardAsync() {
            return base.Channel.GetDashboardAsync();
        }
    }
}