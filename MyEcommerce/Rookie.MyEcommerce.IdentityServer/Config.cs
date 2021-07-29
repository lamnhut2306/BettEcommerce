// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Rookie.MyEcommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("identity.api", "Identity Api"),
                new ApiScope("rookie.myecommerce.api", "Rookie MyEcommerce Api")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // code flow
                new Client
                {
                    ClientId = "Rookie.MyEcommerce.AdminSite",
                    ClientName = "Admin Site",
                    ClientUri = "http://localhost:3000",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = new List<string>()
                    {
                        "http://localhost:3000/category",
                        "http://localhost:3000/callback"
                    },

                    PostLogoutRedirectUris = new List<string>() { "http://localhost:3000/signout-callback-oidc" },
                    AllowedCorsOrigins = { "http://localhost:3000" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookie.myecommerce.api",
                        "identity.api"
                    }
                },

                //hybrid flow 
                new Client
                {
                    ClientId = "Rookie.MyEcommerce.CustomerSite",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "http://localhost:5003/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:5003/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "identity.api", "rookie.myecommerce.api" }
                },
            };
    }
}