using OutSystems.ExternalLibraries.SDK;
using Without.Systems.OAuthTokenExchange.Structures;

namespace Without.Systems.OAuthTokenExchange
{
    [OSInterface(
        Description = "Wrapper for operating with OAuth 2.0 compatible Authorization servers to exchange, refresh, introspect and revoke tokens. Includes utility action to generate Proof Key Code Exchange.",
        IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuth.png")]
    public interface IOAuthTokenExchange
    {
        [OSAction(
            Description = "Request access token with client credentials flow",
            ReturnName = "result",
            ReturnDescription = "Access Token response structure",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        TokenResult RequestClientCredentialsToken(
            [OSParameter(
                Description = "Client credentials flow request")]
            ClientCredentialsRequest clientCredentialsRequest);

        [OSAction(
            Description = "Exchange an authorization code for an access token",
            ReturnName = "result",
            ReturnDescription = "Access Token response structure",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        TokenResult RequestAuthorizationCodeToken(
            [OSParameter(
                Description = "Authorization Code exchange request")]
            AuthorizationCodeRequest authorizationCodeRequest);

        [OSAction(
            Description = "Refresh an access token with a refresh token",
            ReturnName = "result",
            ReturnDescription = "Access token response structure",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        public TokenResult RequestRefreshToken(
            [OSParameter(
                Description = "Refresh access token request")]
            RefreshRequest refreshRequest);

        [OSAction(
            Description = "Revoke an access token",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        public void RevokeToken(
            [OSParameter(
                Description = "Revoke access token request")]
            RevocationRequest revocationRequest);

        [OSAction(
            Description = "Generates code verifier and challange for Proof Key Code Exchange Authorization code flow",
            ReturnName = "result",
            ReturnDescription = "Proof Key Code details",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        ProofKeyCode GenerateProofKeyCode();

        [OSAction(
            Description = "Introspect an access token",
            ReturnName = "isActive",
            ReturnDescription = "Indicates if the access token is active",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        public bool IntrospectToken(
            [OSParameter(
                Description = "Introspect access token request")]
            IntrospectionRequest introspectionRequest);

        [OSAction(
            Description = "Retrieve OpenID Connect Configuration of Identity Provider",
            ReturnName = "result",
            ReturnDescription = "OpenID Discovery Document",
            IconResourceName = "Without.Systems.OAuthTokenExchange.Resources.OAuthAction.png")]
        public DiscoveryDocument GetDiscoveryDocument(
            [OSParameter(
                Description = "Get Well-Known Configuration document request")]
            DiscoveryRequest discoveryRequest);
    }
}