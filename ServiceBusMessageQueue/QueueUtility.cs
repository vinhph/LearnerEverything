using System;
using Magnum;
using MassTransit;
using MassTransit.Context;
using MassTransit.Serialization;
using MassTransit.Transports.Msmq;
using System.Messaging;
using ServiceBusMessageQueue.Models;

namespace ServiceBusMessageQueue
{
    public class QueueUtility
    {
        public const string QueueName = "msmq://cl-vinhpham/HardWorkingQueue";
        public static void QueueMessage<T>(T message) where T : class
        {
            string localQueueName = new Uri(QueueName).GetLocalName();

            ISendContext<T> sc = new SendContext<T>(message);
            var messageEnvelope = Envelope.Create(sc);

            messageEnvelope.DestinationAddress = QueueName;

            /* using (var mq = new System.Messaging.MessageQueue(localQueueName))
            {
                mq.Send(messageEnvelope);
            
            }
            */

            var msmqMessage = new Message();
            try
            {
                if (!string.IsNullOrEmpty(sc.MessageType))
                {
                    msmqMessage.Label = sc.MessageType.Length > 250 ? sc.MessageType.Substring(0, 250) : sc.MessageType;
                }

                msmqMessage.Recoverable = false;
                msmqMessage.UseDeadLetterQueue = true;

                if (sc.ExpirationTime.HasValue)
                {
                    DateTime dateTime = sc.ExpirationTime.Value;
                    msmqMessage.TimeToBeReceived = dateTime.Kind == DateTimeKind.Utc
                                                       ? dateTime - SystemUtil.UtcNow
                                                       : dateTime - SystemUtil.Now;
                }

                var serializer = new XmlMessageSerializer();

                // (Action<Stream>)(stream => serializer.Serialize<T>(stream, sc))

                sc.SetBodyWriter(stream => serializer.Serialize(stream, sc));
                sc.SerializeTo(msmqMessage.BodyStream);

                // msmqMessage.Body = messageEnvelope;

                var transportMessageHeaders = new TransportMessageHeaders();

                if (!string.IsNullOrEmpty(sc.ContentType))
                {
                    transportMessageHeaders.Add("Content-Type", sc.ContentType);
                }

                if (!string.IsNullOrEmpty(sc.OriginalMessageId))
                {
                    transportMessageHeaders.Add("Original-Message-Id", sc.OriginalMessageId);
                }

                msmqMessage.Extension = transportMessageHeaders.GetBytes();

                using (var mq = new MessageQueue(localQueueName))
                {
                    mq.Send(msmqMessage, MessageQueueTransactionType.None);
                }
            }
            finally
            {
                msmqMessage.Dispose();
            }
        }
    }
}
