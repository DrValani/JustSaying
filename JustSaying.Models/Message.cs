﻿using System;

namespace JustSaying.Models
{
    public abstract class Message
    {
        protected Message()
        {
            TimeStamp = DateTime.UtcNow;
            Id = Guid.NewGuid();
            CorrelationId = Id;
        }

        protected Message(Message message)
        {
            TimeStamp = DateTime.UtcNow;
            Id = Guid.NewGuid();
            CorrelationId = message.CorrelationId;
        }
        
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string RaisingComponent { get; set; }
        public Guid CorrelationId { get; private set; }
        public string Version{ get; private set; }
        public string SourceIp { get; private set; }
        public string Tenant { get; set; }
        public string Conversation { get; set; }
        public string ReceiptHandle { get; set; }
        public string QueueUrl { get; set; }
        public int? DelaySeconds { get; set; }

        //footprint in order to avoid the same message being processed multiple times.
        public virtual string UniqueKey() => Id.ToString();
    }
}
