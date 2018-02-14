using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Configuration;

namespace Denion.WebService.VerwijsIndex
{
    /// <summary>
    /// Incomming message interceptor
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LogBehavior : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            for (int i = 0; i < serviceHostBase.ChannelDispatchers.Count; i++)
            {
                ChannelDispatcher channelDispatcher = serviceHostBase.ChannelDispatchers[i] as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        //endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new DebugMessageInspector());
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new DatabaseDispatchMessageInspector());
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }

    /// <summary>
    /// Outgoing message interceptor
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class SoapContractBehavior : Attribute, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        { 
            //clientRuntime.MessageInspectors.Add(new DebugClientMessageInspector());
            clientRuntime.MessageInspectors.Add(new DatabaseClientMessageInspector());
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            return;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            return;
        }
    }

    /// <summary>
    /// Outgoing message interceptor
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class ConsoleSoapContractBehavior : Attribute, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ConsoleClientMessageInspector());
            
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            return;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            return;
        }
    }

    /// <summary>
    /// sends raw messages to debugger
    /// </summary>
    public class DebugMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();

            Debug.WriteLine("<!--Received-->\n" + buffer.CreateMessage().ToString());
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();

            Debug.WriteLine("<!--Sending-->\n" + buffer.CreateMessage().ToString());
        }
    }
    
    /// <summary>
    /// sends raw messages to debugger
    /// </summary>
    public class DebugClientMessageInspector : IClientMessageInspector
    {

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Debug.WriteLine("<!--Received-->\n" + reply.ToString());
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Debug.WriteLine("<!--Sending-->\n" + request.ToString());
            return null;
        }
    }

    /// <summary>
    /// sends raw messages to console
    /// </summary>
    public class ConsoleClientMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            throw new Exception(reply.ToString());
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            throw new Exception(request.ToString());
        }
    }

    /// <summary>
    /// sends raw messages to database
    /// </summary>
    public class DatabaseDispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();

            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            Database.Database.MessageLog(endpoint.Address, "", ConfigurationManager.AppSettings["ServiceId"], buffer.CreateMessage().ToString(), ConfigurationManager.AppSettings["ServiceId"] + "_MessageLog");
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();

            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            Database.Database.MessageLog("", endpoint.Address, ConfigurationManager.AppSettings["ServiceId"], buffer.CreateMessage().ToString(), ConfigurationManager.AppSettings["ServiceId"] + "_MessageLog");
        }
    }

    /// <summary>
    /// sends raw messages to database
    /// </summary>
    public class DatabaseClientMessageInspector : IClientMessageInspector
    {
        private string remoteAddress = null;
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Database.Database.MessageLog(remoteAddress, "", ConfigurationManager.AppSettings["ServiceId"], reply.ToString(), ConfigurationManager.AppSettings["ServiceId"] + "_SendingLog");
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            remoteAddress = channel.RemoteAddress.Uri.Host;
            Database.Database.MessageLog("", remoteAddress, ConfigurationManager.AppSettings["ServiceId"], request.ToString(), ConfigurationManager.AppSettings["ServiceId"] + "_SendingLog");
            return null;
        }
    }
}