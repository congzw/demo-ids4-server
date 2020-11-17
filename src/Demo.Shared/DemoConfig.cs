using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Demo.Shared
{
    public class DemoConfig
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
                new ApiScope(DemoConst.ApiScope1, DemoConst.ApiScope1),
                new ApiScope(DemoConst.ApiScope2, DemoConst.ApiScope2)
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = DemoConst.DemoClient,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(DemoConst.Secret.Sha256())
                    },
                    AllowedScopes = { DemoConst.ApiScope1 }
                },
                new Client
                {
                    ClientId = DemoConst.DemoApi,
                    ClientSecrets = { new Secret(DemoConst.Secret.Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { DemoConst.DemoApiUri_LoginRedirect },
                    PostLogoutRedirectUris = { DemoConst.DemoApiUri_LogoutRedirect },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId = DemoConst.DemoMvc,
                    ClientSecrets = { new Secret(DemoConst.Secret.Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { DemoConst.DemoMvcUri_LoginRedirect },
                    PostLogoutRedirectUris = { DemoConst.DemoMvcUri_LogoutRedirect },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        DemoConst.ApiScope1
                    }
                }
            };
    }
}