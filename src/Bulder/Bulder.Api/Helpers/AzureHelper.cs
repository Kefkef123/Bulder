using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace Bulder.Api
{
    public class AzureHelper<T> where T : TableEntity , new()
    {
        public AzureHelper(string tableName)
        {
            _tableClient = _storageAccount.CreateCloudTableClient();
            _table = _tableClient.GetTableReference(tableName);
            _table.CreateIfNotExists();
        }

        public IEnumerable<T> GetCollection() => _table.ExecuteQuery(new TableQuery<T>());

        public T Get(string rowKey, string partitionKey)
            => (T) _table.Execute(TableOperation.Retrieve(partitionKey, rowKey)).Result;

        public void Insert(T model)
        {
            _table.Execute(TableOperation.Insert(model));
        }

        private CloudStorageAccount _storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
        private CloudTableClient _tableClient;
        private CloudTable _table;
    }
}