using System;
using Azure.DigitalTwins.Core;
using Azure.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Azure;

namespace ADT
{

    class Program
    {
       
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string clientId = "dd458422-2f89-4b7f-9542-59e2f1edfa1d";
            string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            string adtInstanceUrl = "https://teodtdemo.api.wus2.digitaltwins.azure.net";
            var credentials = new InteractiveBrowserCredential(tenantId, clientId);
            DigitalTwinsClient client = new DigitalTwinsClient(new Uri(adtInstanceUrl), credentials);
            Console.WriteLine($"Service client created – ready to go");
            Console.WriteLine();
            Console.WriteLine($"Upload a model");
            var typeList = new List<string>();
            string dtdl = File.ReadAllText("signifyadtmodel.json");
            typeList.Add(dtdl);
            // Upload the model to the service
            client.CreateModelsAsync(typeList);

            // Read a list of models back from the service
            AsyncPageable<ModelData> modelDataList = client.GetModelsAsync();
            await foreach (ModelData md in modelDataList)
            {
                Console.WriteLine($"Type name: {md.DisplayName}: {md.Id}");
            }

        }

        static async Task UploadModel()
        {
           
        }
    }
}
