using Common;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToServiceBusQueue
{
    public class ConnectToTopic
    {
        private static bool sendMessage = false;
        private static string connectionString;
        private static MessagingFactory messagingFactory;
        private static MessageSender messageSender;
        private static MessageReceiver messageReceiver;
        private static OnMessageOptions options;
        private static string topicName;
        private static string subscription1;

        public ConnectToTopic()
        {
            connectionString = "Endpoint=sb://nitprodevstd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=bVW5y5kVXRbG4FU0g45OUuWELdsGWVLsongkRjWS+uk=";
            topicName = "nitorprodevstdtopic";
            subscription1 = "nitorprodevstdtopicsub1";
            messagingFactory = MessagingFactory.CreateFromConnectionString(connectionString);
            messageSender = messagingFactory.CreateMessageSender(topicName);
            messageReceiver = messagingFactory.CreateMessageReceiver(topicName + "/subscriptions/" + subscription1);
            options = new OnMessageOptions();
        }

        public void MyConnect()
        {
            if (sendMessage)
            {
                BrokeredMessage message = new BrokeredMessage(new MyQueueMessage() { PushedDate = DateTime.Now, MessageBody = "Message using Message Sender" });
                messageSender.Send(message);
                Console.WriteLine(string.Format("Message send: {0}", message.MessageId + " with date as " + message.GetBody<MyQueueMessage>().PushedDate));
            }
            else
            {
                messageReceiver.OnMessage(receivedMessage =>
                {
                    Console.WriteLine(string.Format("Message received: {0}", receivedMessage.MessageId));
                }, options);
            }
        }
    }
}
