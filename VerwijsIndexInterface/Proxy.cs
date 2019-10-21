using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Denion.WebService.VerwijsIndex
{
    /// <summary>
    /// IPayment Client Proxy
    /// </summary>
    public class VerwijsIndexClient : ClientBase<IVerwijsIndex>, IVerwijsIndex
    {
        public VerwijsIndexClient()
        {
        }

        public VerwijsIndexClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public VerwijsIndexClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public VerwijsIndexClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public PaymentStartResponse PaymentStart(PaymentStartRequest PaymentStartRequest)
        {
            return base.Channel.PaymentStart(PaymentStartRequest);
        }

        public PaymentEndResponse PaymentEnd(PaymentEndRequest PaymentEndRequest)
        {
            return base.Channel.PaymentEnd(PaymentEndRequest);
        }

        public PaymentCheckResponse PaymentCheck(PaymentCheckRequest PaymentCheckRequest)
        {
            return base.Channel.PaymentCheck(PaymentCheckRequest);
        }
        public StatusResponse ServiceStatus()
        {
            return base.Channel.ServiceStatus();
        }
    }

    /// <summary>
    /// IProvider Client Proxy 
    /// </summary>
    public class ProviderClient : ClientBase<IProvider>, IProvider
    {
        public ProviderClient()
        {
        }

        public ProviderClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public ProviderClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public ProviderClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        //public LinkResponse Request(LinkRequest req)
        //{
        //    return base.Channel.Request(req);
        //}

        public LinkRegistrationResponse Registration(LinkRegistrationRequest req)
        {
            return base.Channel.Registration(req);
        }

        public LinkRegistrationBatchResponse BatchRegistration(LinkRegistrationBatchRequest req)
        {
            return base.Channel.BatchRegistration(req);
        }

        public ActivateAuthorisationResponse ActivateAuthorisation(ActivateAuthorisationRequest req)
        {
            return base.Channel.ActivateAuthorisation(req);
        }

        public CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest req)
        {
            return base.Channel.CancelAuthorisation(req);
        }

        public StatusResponse ServiceStatus()
        {
            return base.Channel.ServiceStatus();
        }

        public LinkTerminationAcknowledged Terminated(LinkTerminationNotification ltn)
        {
            return base.Channel.Terminated(ltn);
        }
    }

    /// <summary>
    /// IConsumer Client Proxy
    /// </summary>
    public class ConsumerClient : ClientBase<IConsumer>, IConsumer
    {
        public ConsumerClient()
        {
        }

        public ConsumerClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public ConsumerClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public ConsumerClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public ActivateAuthorisationResponse ActivateAuthorisation(ActivateAuthorisationRequest req)
        {
            return base.Channel.ActivateAuthorisation(req);
        }

        public CancelAuthorisationResponse CancelAuthorisation(CancelAuthorisationRequest req)
        {
            return base.Channel.CancelAuthorisation(req);
        }
    }
}