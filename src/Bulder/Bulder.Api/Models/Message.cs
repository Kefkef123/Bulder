using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bulder.Api
{
    public class Message : TableEntity
    {
        public Message(string channelName)
        {
            PartitionKey = channelName;
            RowKey = Guid.NewGuid().ToString();
        }

        public Message() { }

        public string Text { get; set; }
        public string Author { get; set; }
    }
}