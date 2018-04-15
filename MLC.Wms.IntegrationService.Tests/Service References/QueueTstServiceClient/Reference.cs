﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MLC.Wms.IntegrationService.Tests.QueueTstServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wms.my.ru/services/v1/", ConfigurationName="QueueTstServiceClient.QueueTstService")]
    public interface QueueTstService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wms.my.ru/services/v1/QueueTstService/DoWork", ReplyAction="http://wms.my.ru/services/v1/QueueTstService/DoWorkResponse")]
        string DoWork(string id);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://wms.my.ru/services/v1/QueueTstService/DoWork", ReplyAction="http://wms.my.ru/services/v1/QueueTstService/DoWorkResponse")]
        System.IAsyncResult BeginDoWork(string id, System.AsyncCallback callback, object asyncState);
        
        string EndDoWork(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface QueueTstServiceChannel : MLC.Wms.IntegrationService.Tests.QueueTstServiceClient.QueueTstService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DoWorkCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DoWorkCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class QueueTstServiceClient : System.ServiceModel.ClientBase<MLC.Wms.IntegrationService.Tests.QueueTstServiceClient.QueueTstService>, MLC.Wms.IntegrationService.Tests.QueueTstServiceClient.QueueTstService {
        
        private BeginOperationDelegate onBeginDoWorkDelegate;
        
        private EndOperationDelegate onEndDoWorkDelegate;
        
        private System.Threading.SendOrPostCallback onDoWorkCompletedDelegate;
        
        public QueueTstServiceClient() {
        }
        
        public QueueTstServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public QueueTstServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QueueTstServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public QueueTstServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<DoWorkCompletedEventArgs> DoWorkCompleted;
        
        public string DoWork(string id) {
            return base.Channel.DoWork(id);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDoWork(string id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDoWork(id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndDoWork(System.IAsyncResult result) {
            return base.Channel.EndDoWork(result);
        }
        
        private System.IAsyncResult OnBeginDoWork(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string id = ((string)(inValues[0]));
            return this.BeginDoWork(id, callback, asyncState);
        }
        
        private object[] OnEndDoWork(System.IAsyncResult result) {
            string retVal = this.EndDoWork(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDoWorkCompleted(object state) {
            if ((this.DoWorkCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DoWorkCompleted(this, new DoWorkCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DoWorkAsync(string id) {
            this.DoWorkAsync(id, null);
        }
        
        public void DoWorkAsync(string id, object userState) {
            if ((this.onBeginDoWorkDelegate == null)) {
                this.onBeginDoWorkDelegate = new BeginOperationDelegate(this.OnBeginDoWork);
            }
            if ((this.onEndDoWorkDelegate == null)) {
                this.onEndDoWorkDelegate = new EndOperationDelegate(this.OnEndDoWork);
            }
            if ((this.onDoWorkCompletedDelegate == null)) {
                this.onDoWorkCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDoWorkCompleted);
            }
            base.InvokeAsync(this.onBeginDoWorkDelegate, new object[] {
                        id}, this.onEndDoWorkDelegate, this.onDoWorkCompletedDelegate, userState);
        }
    }
}