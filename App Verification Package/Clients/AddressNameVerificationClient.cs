using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace App_Verification_Package.Clients
{
    public class AddressNameVerificationClient
    {
        private const string apiName = "AddressNameVerification";

        private readonly MBClient client;

        public AddressNameVerificationClient(MBClient mbClient)
        {
            this.client = mbClient;
        }

        public JsonObject GetReport(string JSONRequestModel)
        {
            var url = new Uri(client.BaseAddress + apiName + "/");
            var content = new StringContent(JSONRequestModel, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            var result = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream());
            return result;
        }
    }
}
