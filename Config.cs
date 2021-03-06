﻿using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
    {
    public class Config
        {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources ()
            {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
            }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients ()
            {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },
                new Client

                    {
                        ClientId = "mvc",
                        ClientName = "MVC Client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                        RequireConsent = false,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        RedirectUris           = { "http://localhost:5002/signin-oidc" },
                        PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1"
                        },
                        AllowOfflineAccess = true
                    }
            };
            }

        public static IEnumerable<IdentityResource> GetIdentityResources ()
            {
            return new List<IdentityResource>
                {
                             new IdentityResources.OpenId(),
        new IdentityResources.Profile(),

                };
            }
        }
    }
