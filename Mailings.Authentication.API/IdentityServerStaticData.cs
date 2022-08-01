﻿using IdentityModel;
using IdentityServer4.Models;
using Mailings.Authentication.Shared.StaticData;

namespace Mailings.Authentication.API;
public static class IdentityServerStaticData
{
    public static IEnumerable<IdentityResource> IdentityResources 
        => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResource(OidcConstants.StandardScopes.Profile, new []
            {
                JwtClaimTypes.FamilyName,
                JwtClaimTypes.GivenName,
                JwtClaimTypes.PreferredUserName
            })
        };
    public static IEnumerable<ApiResource> ApiResources
        => new List<ApiResource>()
        {
            new ApiResource("_resourceServer", 
                "Api resource to access resources on server side.")
            {
                Enabled = true,
                Scopes =
                {
                    "readSecured_resourceServer",
                    "writeDefault_resourceServer"
                }
            }
        };
    public static IEnumerable<ApiScope> Scopes 
        => new List<ApiScope>()
        {
            new ApiScope(
                name: "readDefault_resourceServer",
                displayName: "Scope of resource server for any users")
            {
                ShowInDiscoveryDocument = true,
            },
            new ApiScope(
                name: "readSecured_resourceServer",
                displayName: "Scope of resource server with extra permissions")
            {
                ShowInDiscoveryDocument = true,
            },
            new ApiScope(
                name: "writeDefault_resourceServer",
                displayName: "Scope of resource server with rights to" +
                             " writing data on resource server")
            {
                ShowInDiscoveryDocument = true,
            },
            new ApiScope(
                name: "fullAccess_resourceServer",
                displayName: "Scope of resource server with full access to " +
                             "any endpoint in resource server side")
            {
                ShowInDiscoveryDocument = true,
            }
        };

    public static IEnumerable<Client> GetClients(bool withPkce = true)
        => new List<Client>()
        {
            new Client()
            {
                ClientId = "webUser_Client",
                ClientName = "MVC Web client application",

                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes = new[]
                {
                    OidcConstants.StandardScopes.OpenId,
                    OidcConstants.StandardScopes.Email,
                    OidcConstants.StandardScopes.Profile,
                    "readSecured_resourceServer",
                    "writeDefault_resourceServer"
                },

                ClientSecrets = {new Secret("_webClientSecret".ToSha256())},

                RequirePkce = withPkce,

                RedirectUris =
                {
                    IdentityClients.ClientServer + "/signin-oidc",
                    "https://oauth.pstmn.io/v1/browser-callback"
                },
                PostLogoutRedirectUris =
                    { IdentityClients.ClientServer + "/signout-callback-oidc" },
                AllowAccessTokensViaBrowser = true,
            }
        };
}