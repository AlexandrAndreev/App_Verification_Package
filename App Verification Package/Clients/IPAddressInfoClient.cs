using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace App_Verification_Package.Clients
{
    public class IPAddressInfoClient
    {
        private const string apiName = "IPAddressInfo";

        private readonly MBClient client;

        public IPAddressInfoClient(MBClient mbClient)
        {
            this.client = mbClient;
        }

        public JsonObject GetReport(string requestBody)
        {
            var url = new Uri(client.BaseAddress + apiName + "/");
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            var result = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream());
            return result;
        }
    }
}
