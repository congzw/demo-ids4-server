using System;
using System.Net.Http;
using System.Threading.Tasks;
using Demo.Shared;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace DemoClient
{
    class Program
    {
        private static async Task Main()
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var identityServerUri = DemoConst.IdentityServer_Uri;
            var disco = await client.GetDiscoveryDocumentAsync(identityServerUri);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = DemoConst.DemoClient_Id,
                ClientSecret = DemoConst.DemoClient_Secret,
                Scope = DemoConst.DemoApi_Scope1
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var response = await apiClient.GetAsync(DemoConst.DemoApi_Uri_GetUser);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
