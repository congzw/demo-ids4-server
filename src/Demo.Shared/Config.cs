using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Demo.Shared
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope(DemoConst.DemoApi_Scope1, DemoConst.DemoApi_Scope1Title)
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // machine to machine client
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
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = DemoConst.DemoMvcClient_Id,
                    ClientSecrets = { new Secret(DemoConst.DemoMvcClient_Secret.Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    // where to redirect to after login
                    RedirectUris = { DemoConst.DemoMvcClient_RedirectUri },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { DemoConst.DemoMvcClient_PostLogoutRedirectUri},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
    }
}
