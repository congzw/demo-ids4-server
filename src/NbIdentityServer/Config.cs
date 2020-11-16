using System.Collections.Generic;
using Demo.Shared;
using IdentityServer4.Models;

namespace NbIdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(DemoConst.DemoApi_Scope1, DemoConst.DemoApi_Scope1Title)
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = DemoConst.DemoClient_Id,

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(DemoConst.DemoClient_Secret.Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { DemoConst.DemoApi_Scope1 }
                }
            };
    }
}
