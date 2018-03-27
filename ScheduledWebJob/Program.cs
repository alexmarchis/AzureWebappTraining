using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace ScheduledWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=webappstrainingstorage;AccountKey=KqgxAaYNtImst4om4ehFXgO26LWmv0POYb6nGXzM2Oa0eCIc3O/RSTmWc6FspFzTxEUusl61wHLtoSBv70CkJQ==;EndpointSuffix=core.windows.net");
            CloudQueueClient client = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference("messagequeue");
            queue.AddMessage(new CloudQueueMessage(DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.ToShortTimeString()));
        }
    }
}
