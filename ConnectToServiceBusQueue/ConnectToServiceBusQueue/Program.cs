using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Common;
using Microsoft.ServiceBus;

namespace ConnectToServiceBusQueue
{
    public class Program
    {
        private static bool connectToQueue = false;

        private static void ProcessMessage(long sequenceNumber, string queueMessageId, MyQueueMessage message)
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Message details");
            //Console.WriteLine(string.Format("Message sequence number: {0}", sequenceNumber));
            Console.WriteLine(string.Format("Message queue Id: {0}", queueMessageId));
            //Console.WriteLine(string.Format("Message Id: {0}", message.MessageId));
            Console.WriteLine(string.Format("Message date: {0}", message.PushedDate));
            //Console.WriteLine(string.Format("Message body: {0}", message.MessageBody));
            Console.WriteLine("===============================================");
            throw new Exception("Error occurred");
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Program started");

                if (connectToQueue)
                {
                    ConnectToQueue connect = new ConnectToQueue();
                    connect.MyConnect();
                }
                else
                {
                    ConnectToTopic connect = new ConnectToTopic();
                    connect.MyConnect();
                }

                ////ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Https;

                ////Console.ReadLine();


                ////var connectionString = "Endpoint=sb://nitprodev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ITfvDogxy7Kuc/wbTPu1HP7g1Mh7eqSvtaP/E6y3HH0=";

                ////var queueName = "nitprodevqueue";

                ////var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

                ////var deadQueue = QueueClient.CreateFromConnectionString(connectionString, QueueClient.FormatDeadLetterPath(client.Path));

                ////if (sendMessage)
                ////{
                ////    myMessage.PushedDate = DateTime.Now;
                ////    myMessage.MessageId = "WF20170306092600";
                ////    myMessage.MessageBody = string.Format("This is message body at {0}", DateTime.Now);

                ////    var message = new BrokeredMessage(myMessage);
                ////    client.Send(message);
                ////}
                ////else
                ////{
                ////    //// Read from dead queue
                ////    deadQueue.OnMessage(deadMessage =>
                ////    {
                ////        Console.WriteLine("Dead message details: ");
                ////        Console.WriteLine(string.Format("Dead message Id: {0}", deadMessage.MessageId));
                ////        Console.WriteLine(string.Format("Dead message: {0}", deadMessage.GetBody<QueueMessage>().PushedDate));
                ////    });

                ////    //// Read from normal queue
                ////    ////client.OnMessage(message =>
                ////    ////{
                ////    ////    try
                ////    ////    {
                ////    ////        ProcessMessage(message.SequenceNumber, message.MessageId, message.GetBody<QueueMessage>());
                ////    ////    }
                ////    ////    catch (Exception exception)
                ////    ////    {
                ////    ////        throw exception;
                ////    ////    }
                ////    ////});
                ////}
                ////Console.WriteLine("Program completed");
                ////Console.ReadLine();
                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
