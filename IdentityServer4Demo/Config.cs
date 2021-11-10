using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Demo
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),

            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api")
            };
        }
        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            string var = GrantTypes.ClientCredentials.FirstOrDefault();
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    //ClientName = "clientName",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // AllowedGrantTypes = new List<string>()
                    //{
                    //    GrantTypes.ClientCredentials.FirstOrDefault(),//Resource Owner Password模式
                    //},
                    //RequireConsent = false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //RedirectUris           = { "http://localhost:5000/signin-oidc" },
                    //PostLogoutRedirectUris = { "http://localhost:5000/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        //IdentityServerConstants.StandardScopes.OpenId,
                        //IdentityServerConstants.StandardScopes.Profile,
                        "api"
                    }
                    //AccessTokenLifetime = 60
                  
                    
                  
                }
            };
        }
    }
}
