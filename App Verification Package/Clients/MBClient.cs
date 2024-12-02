using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App_Verification_Package.Clients
{
    public class MBClient : HttpClient
    {
        public MBClient(string authorization, Uri baseURL)
        {
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", authorization));
            this.BaseAddress = baseURL;
        }
    }
}
