using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Common;

namespace ConnectToServiceBusQueue
{
    public class ConnectToQueue
    {
        private static bool sendMessage = false;
        private static string connectionString;
        private static string queueName;
        private static MessagingFactory messagingFactory;
        private static MessageSender messageSender;
        private static MessageReceiver messageReceiver;
        private static OnMessageOptions options;

        public ConnectToQueue()
        {
            connectionString = "Endpoint=sb://nitprodev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ITfvDogxy7Kuc/wbTPu1HP7g1Mh7eqSvtaP/E6y3HH0=";
            queueName = "nitprodevqueue";
            messagingFactory = MessagingFactory.CreateFromConnectionString(connectionString);
            messageSender = messagingFactory.CreateMessageSender(queueName);
            messageReceiver = messagingFactory.CreateMessageReceiver(queueName);
            options = new OnMessageOptions();

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var deadQueue = QueueClient.CreateFromConnectionString(connectionString, QueueClient.FormatDeadLetterPath(client.Path));
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
