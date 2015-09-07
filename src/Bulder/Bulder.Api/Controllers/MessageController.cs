using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bulder.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        public MessageController()
        {
            var tableClient = _storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference("messages");
            _table.CreateIfNotExists();
        }
        
        [HttpGet]
        public IEnumerable<Message> Get() => _messageHelper.GetCollection();
        
        public Message GetSpecific(string rowKey, string partitionKey) => _messageHelper.Get(rowKey, partitionKey);

        [HttpPost]
        public void Post([FromBody] Message message)
        {
            _messageHelper.Insert(new Message(message.PartitionKey)
            {
                Text = message.Text,
                Author = message.Author,
                Timestamp = DateTimeOffset.Now
            });
        }

        private readonly CloudStorageAccount _storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
        private readonly CloudTable _table;
        private readonly AzureHelper<Message> _messageHelper = new AzureHelper<Message>("messages"); 
    }
}