﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _05.ConsoleClient.SubstringServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SubstringServiceReference.ISubstringService")]
    public interface ISubstringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubstringService/GetOccurrencesCount", ReplyAction="http://tempuri.org/ISubstringService/GetOccurrencesCountResponse")]
        int GetOccurrencesCount(string substring, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubstringService/GetOccurrencesCount", ReplyAction="http://tempuri.org/ISubstringService/GetOccurrencesCountResponse")]
        System.Threading.Tasks.Task<int> GetOccurrencesCountAsync(string substring, string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISubstringServiceChannel : _05.ConsoleClient.SubstringServiceReference.ISubstringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubstringServiceClient : System.ServiceModel.ClientBase<_05.ConsoleClient.SubstringServiceReference.ISubstringService>, _05.ConsoleClient.SubstringServiceReference.ISubstringService {
        
        public SubstringServiceClient() {
        }
        
        public SubstringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SubstringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubstringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubstringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetOccurrencesCount(string substring, string text) {
            return base.Channel.GetOccurrencesCount(substring, text);
        }
        
        public System.Threading.Tasks.Task<int> GetOccurrencesCountAsync(string substring, string text) {
            return base.Channel.GetOccurrencesCountAsync(substring, text);
        }
    }
}
