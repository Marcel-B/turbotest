using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using ApiScope = IdentityServer4.Models.ApiScope;
using Client = IdentityServer4.Models.Client;
using Secret = IdentityServer4.Models.Secret;

namespace IdentityServer
{
    public static class Config
    {
        public static void AddIdentityResource(this ConfigurationDbContext context)
        {
            if (!context.IdentityResources.Any())
            {
                var openId = new IdentityResources.OpenId();
                var profile = new IdentityResources.Profile();
                context.IdentityResources.Add(new IdentityServer4.EntityFramework.Entities.IdentityResource
                {
                    Name = openId.Name,
                    Enabled = true,
                    DisplayName = openId.DisplayName,
                    Description = openId.Description,
                    Required = openId.Required,
                    Emphasize = openId.Emphasize,
                    ShowInDiscoveryDocument = true,
                    NonEditable = true,
                    Created = DateTime.Now
                });

                context.IdentityResources.Add(new IdentityServer4.EntityFramework.Entities.IdentityResource
                {
                    Name = profile.Name,
                    Enabled = true,
                    DisplayName = profile.DisplayName,
                    Description = profile.Description,
                    Required = profile.Required,
                    Emphasize = profile.Emphasize,
                    ShowInDiscoveryDocument = true,
                    NonEditable = true,
                    Created = DateTime.Now
                });
                context.SaveChanges();
            }
        }

        public static void CreateApiScopes(this ConfigurationDbContext context)
        {
            if (context.ApiScopes.FirstOrDefault(x => x.Name == "fishbook-feed") is null)
            {
                context.ApiScopes.Add(new IdentityServer4.EntityFramework.Entities.ApiScope
                {
                    Enabled = true,
                    Name = "fishbook-feed",
                    DisplayName = "Fishbook Feed",
                    Description = "Scope um den Feed abzufragen",
                    ShowInDiscoveryDocument = true
                });
            }

            context.SaveChanges();
        }

        public static void CreateClients(this ConfigurationDbContext context)
        {
            var clientSecret = new IdentityServer4.EntityFramework.Entities.ClientSecret
            {
                Created = DateTime.Now,
                Value = "123-abc".Sha512(),
                Expiration = DateTime.MaxValue
            };
            var client = new IdentityServer4.EntityFramework.Entities.Client
            {
                Enabled = true,
                ClientId = "fishbook.js.client",
                Description = "JavaScript Client für die SPA",
                ClientName = "fishbook-js-client",
                AccessTokenLifetime = 3600,
                AbsoluteRefreshTokenLifetime = 3600,
                IdentityTokenLifetime = 3600,
                AccessTokenType = (int) AccessTokenType.Jwt,
                AllowAccessTokensViaBrowser = true,
                Created = DateTime.Now,
                ClientSecrets = new List<ClientSecret> {clientSecret},
                RequireConsent = false,
                UpdateAccessTokenClaimsOnRefresh = true,
                RefreshTokenUsage = 1,
                EnableLocalLogin = true,
                DeviceCodeLifetime = 3600,
                NonEditable = false
            };
            /*
            var clientScope = new IdentityServer4.EntityFramework.Entities.ClientScope
            {
                Client = client,
                
            };
            var clientGrantTypes = new IdentityServer4.EntityFramework.Entities.ClientGrantType
            {
                Client = client,
                GrantType = "profile"
            };
            */

            var clientCorsOrigin = new IdentityServer4.EntityFramework.Entities.ClientCorsOrigin
            {
                Client = client,
                Origin = "http://192.168.2.103:9500"
            };
            
            context.ClientCorsOrigins.Add(clientCorsOrigin);
            context.SaveChanges();
        }

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256())},

                    AllowedScopes = {"scope1"}
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = {new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = {"https://localhost:44300/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = {"https://localhost:44300/signout-callback-oidc"},

                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "scope2"}
                },
            };
    }
}