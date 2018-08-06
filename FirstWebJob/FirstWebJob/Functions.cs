using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.ServiceBus.Messaging;
using Common;

namespace FirstWebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        {
            log.WriteLine(message);
        }

        // This function will get triggered/executed when a new message is written
        // on an Azure Service Bus Queue called MySBQueue.
        public static void ProcessServiceBusQueue([ServiceBusTrigger("nitprodevqueue")] BrokeredMessage message, TextWriter log)
        {
            try
            {
                MyQueueMessage currentMessage = message.GetBody<MyQueueMessage>();
                log.WriteLine(message.MessageId + "  and " + currentMessage.PushedDate);
            }
            catch (Exception exception)
            {
                log.WriteLine(exception.Message);
            }
        }

        // This function will get triggered/executed when a new message is written
        // on an Azure Service Bus Topic called Nitorprodevstdtopic and with matching subscription as nitorprodevstdtopicsub1
        public static void ProcessServiceBusTopic1([ServiceBusTrigger("Nitorprodevstdtopic", "nitorprodevstdtopicsub1")] BrokeredMessage message, TextWriter log)
        {
            try
            {
                MyQueueMessage currentMessage = message.GetBody<MyQueueMessage>();
                log.WriteLine(message.MessageId + "  and " + currentMessage.PushedDate);
            }
            catch (Exception exception)
            {
                log.WriteLine(exception.Message);
            }
        }

        // This function will get triggered/executed when a new message is written
        // on an Azure Service Bus Topic called Nitorprodevstdtopic and with matching subscription as nitorprodevstdtopicsub2
        public static void ProcessServiceBusTopic2([ServiceBusTrigger("Nitorprodevstdtopic", "nitorprodevstdtopicsub2")] BrokeredMessage message, TextWriter log)
        {
            try
            {
                MyQueueMessage currentMessage = message.GetBody<MyQueueMessage>();
                log.WriteLine(message.MessageId + "  and " + currentMessage.PushedDate);
            }
            catch (Exception exception)
            {
                log.WriteLine(exception.Message);
            }
        }
    }
}
