using App_Verification_Package.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace App_Verification_Package
{
    public class AppVerificationPackageClient
    {
        private MBClient mbBaseClient;

        public string Authorization { get; private set; }

        private SSNValidationClient sSNValidationClient;
        public SSNValidationClient SSNValidationClient
        {
            get
            {
                if (sSNValidationClient == null)
                {
                    sSNValidationClient = new SSNValidationClient(MBBaseClient);
                }

                return sSNValidationClient;
            }
        }

        private SSNPhoneVerificationClient sSNPhoneVerificationClient;
        public SSNPhoneVerificationClient SSNPhoneVerificationClient
        {
            get
            {
                if (sSNPhoneVerificationClient == null)
                {
                    sSNPhoneVerificationClient = new SSNPhoneVerificationClient(MBBaseClient);
                }

                return sSNPhoneVerificationClient;
            }
        }

        private SSNNameVerificationClient sSNNameVerificationClient;
        public SSNNameVerificationClient SSNNameVerificationClient
        {
            get
            {
                if (sSNNameVerificationClient == null)
                {
                    sSNNameVerificationClient = new SSNNameVerificationClient(MBBaseClient);
                }

                return sSNNameVerificationClient;
            }
        }

        private SSNAddressVerificationClient sSNAddressVerificationClient;
        public SSNAddressVerificationClient SSNAddressVerificationClient
        {
            get
            {
                if (sSNAddressVerificationClient == null)
                {
                    sSNAddressVerificationClient = new SSNAddressVerificationClient(MBBaseClient);
                }

                return sSNAddressVerificationClient;
            }
        }

        private PhoneNameVerificationClient phoneNameVerificationClient;
        public PhoneNameVerificationClient PhoneNameVerificationClient
        {
            get
            {
                if (phoneNameVerificationClient == null)
                {
                    phoneNameVerificationClient = new PhoneNameVerificationClient(MBBaseClient);
                }

                return phoneNameVerificationClient;
            }
        }

        private PhoneAddressVerificationClient phoneAddressVerificationClient;
        public PhoneAddressVerificationClient PhoneAddressVerificationClient
        {
            get
            {
                if (phoneAddressVerificationClient == null)
                {
                    phoneAddressVerificationClient = new PhoneAddressVerificationClient(MBBaseClient);
                }

                return phoneAddressVerificationClient;
            }
        }

        private OFACWatchlistSearchClient oFACWatchlistSearchClient;
        public OFACWatchlistSearchClient OFACWatchlistSearchClient
        {
            get
            {
                if (oFACWatchlistSearchClient == null)
                {
                    oFACWatchlistSearchClient = new OFACWatchlistSearchClient(MBBaseClient);
                }

                return oFACWatchlistSearchClient;
            }
        }

        private IPAddressInfoClient iPAddressInfoClient;
        public IPAddressInfoClient IPAddressInfoClient
        {
            get
            {
                if (iPAddressInfoClient == null)
                {
                    iPAddressInfoClient = new IPAddressInfoClient(MBBaseClient);
                }

                return iPAddressInfoClient;
            }
        }

        private EmailValidationClient emailValidationClient;
        public EmailValidationClient EmailValidationClient
        {
            get
            {
                if (emailValidationClient == null)
                {
                    emailValidationClient = new EmailValidationClient(MBBaseClient);
                }

                return emailValidationClient;
            }
        }

        private DLVerifyClient dLVerifyClient;
        public DLVerifyClient DLVerifyClient
        {
            get
            {
                if (dLVerifyClient == null)
                {
                    dLVerifyClient = new DLVerifyClient(MBBaseClient);
                }

                return dLVerifyClient;
            }
        }

        private DeathMasterFileValidationClient deathMasterFileValidationClient;
        public DeathMasterFileValidationClient DeathMasterFileValidationClient
        {
            get
            {
                if (deathMasterFileValidationClient == null)
                {
                    deathMasterFileValidationClient = new DeathMasterFileValidationClient(MBBaseClient);
                }

                return deathMasterFileValidationClient;
            }
        }

        private AddressNameVerificationClient addressNameVerificationClient;
        public AddressNameVerificationClient AddressNameVerificationClient
        {
            get
            {
                if (addressNameVerificationClient == null)
                {
                    addressNameVerificationClient = new AddressNameVerificationClient(MBBaseClient);
                }

                return addressNameVerificationClient;
            }
        }

        private MBClient MBBaseClient
        {
            get
            {
                if (mbBaseClient == null)
                {
                    mbBaseClient = new MBClient(Authorization, baseUri);
                }

                return mbBaseClient;
            }
        }
        private readonly Uri baseUri;

        public AppVerificationPackageClient(string client_id, string client_secret, EnvironmentType type = EnvironmentType.Production)
        {
            baseUri = new Uri(type.ToDescriptionString());
            Authorization = MBAuthorizations(client_id, client_secret);
        }

        public string MBAuthorizations(string client_id, string client_secret)
        {
            using (var client = new HttpClient() { BaseAddress = baseUri })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var authorization = new JsonObject()
                {
                    ["client_id"] = JsonValue.Create(client_id),
                    ["client_secret"] = JsonValue.Create(client_secret),
                    ["grant_type"] = JsonValue.Create("client_credentials")
                };
                var content = new StringContent(authorization.ToString(), Encoding.UTF8, "application/json");
                try
                {
                    var response = client.PostAsync(new Uri(baseUri, "OAuth/GetAccessToken"), content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsr = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream());
                        JsonNode access_token;
                        if (jsr.TryGetPropertyValue("access_token", out access_token))
                        {
                            return access_token.ToString();
                        }
                        else
                        {
                            throw new Exception(string.Format("Authorizations faled : {}", response.Content.ReadAsStringAsync().Result));
                        }
                    }
                    else
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (HttpRequestException)
                {
                    throw;
                }
            }
        }

    }
}
