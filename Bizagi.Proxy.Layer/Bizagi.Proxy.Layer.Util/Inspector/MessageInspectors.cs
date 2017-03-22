

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;
using System.Text;

namespace Bizagi.Proxy.Layer.Util.Inspector
{



    public class MessageInspector : IDispatchMessageInspector
    {


        private static readonly ILog log = LogManager.GetLogger(typeof(MessageInspector));

        public object AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(Path.Combine(AssemblyDirectory, "log4netConfig.config")));
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            Message copyRequest = buffer.CreateMessage();
            StringBuilder sb = new StringBuilder();
            using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(sb))
            {
                copyRequest.WriteMessage(xw);
                xw.Flush();
                xw.Close();
            }
            log.Info(sb.ToString());
            request = buffer.CreateMessage();
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(Path.Combine(AssemblyDirectory, "log4netConfig.config")));
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            Message copyReply = buffer.CreateMessage();
            StringBuilder sb = new StringBuilder();
            using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(sb))
            {
                copyReply.WriteMessage(xw);
                xw.Flush();
                xw.Close();
            }
            log.Info(sb.ToString());
            reply = buffer.CreateMessage();
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }


    public class MessageBehaviourExtension : BehaviorExtensionElement, IServiceBehavior
    {

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            //Logger.WriteLogEntry("Inside the ApplyClientBehavior");
        }

        public override Type BehaviorType
        {
            get { return typeof(MessageBehaviourExtension); }
        }

        protected override object CreateBehavior()
        {
            return new MessageBehaviourExtension();
        }

        public void AddBindingParameters(ServiceDescription serviceDescription,
         System.ServiceModel.ServiceHostBase serviceHostBase,
         System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
         BindingParameterCollection bindingParameters)
        {
            //Logger.WriteLogEntry("Inside the AddBindingParameters");
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
         System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            //Logger.WriteLogEntry("Inside Apply Dispatch Behavior");
            for (int i = 0; i < serviceHostBase.ChannelDispatchers.Count; i++)
            {
                ChannelDispatcher channelDispatcher = serviceHostBase.ChannelDispatchers[i] as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        MessageInspector inspector = new MessageInspector();
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription,
          System.ServiceModel.ServiceHostBase serviceHostBase)
        {

        }
    }
}
