using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace SocialCRM.IdentityServer.Data
{
    public static class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    name: "name",
                    displayName: "User name",
                    claimTypes: new[] { "name", "email", "status" })
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apiApp", "My API")
                {
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email }
                }
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "clientApp",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "apiApp" }
                },

                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { $"{configuration["ClientAddress"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"{configuration["ClientAddress"]}/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiApp"
                    },
                    AllowOfflineAccess = true
                },

                // OpenID Connect implicit flow client (Angular)
                new Client
                {
                    ClientId = "ng",
                    ClientName = "Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,

                    RedirectUris = { $"{configuration["ClientAddress"]}/" },
                    PostLogoutRedirectUris = { $"{configuration["ClientAddress"]}/home" },
                    AllowedCorsOrigins = { configuration["ClientAddress"] },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiApp"
                    },

                },
                
                // OpenID Connect implicit flow client (api Swagger)
                new Client
                {
                    ClientId = "swagger",
                    ClientName = "Swagger web client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,

                    RedirectUris = { $"{configuration["ApiAddress"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{configuration["ApiAddress"]}/swagger" },
                    AllowedCorsOrigins = { configuration["ApiAddress"] },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apiApp"
                    },

                }

            };
        }
    }
}