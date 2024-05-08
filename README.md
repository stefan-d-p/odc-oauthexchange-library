# OutSystems Developer Cloud External Logic Connector Library for OAuth Token Exchange

Wrapper for operating with OAuth 2.0 compatible Authorization servers to exchange, refresh, introspect and revoke tokens. Includes utility action to generate Proof Key Code Exchange.

## Actions
The library exposes the following actions

### RequestClientCredentials

Request access token with client credentials flow

**Input parameters**

* `Address` - Identity Provicer Token Endpoint Url
* `ClientId` - Client ID
* `ClientSecret` - Client Secret
* `Scope` - Space separated list of scopes

**Result**

* `AccessToken` - Access token
* `IdentityToken` - Identity token - only applicable in authorization code flow with requested identity scope
* `RequestedScope` - Space separated list of requested scopes.
* `IssuedTokenType` - Type of issued token
* `TokenType` - Type of token
* `RefreshToken` - Refresh token - only applicable in authorization code flow with requested offline scope.
* `ExpiresOn` - Date and time when access token expires

### RequestAuthorizationCodeToken

Exchange an authorization code for an access token

**Input parameters**

* `Address` - Identity Provicer Token Endpoint Url
* `ClientId` - Client ID
* `ClientSecret` - Client Secret
* `Code` - Authorization code retrieved from the authorization server
* `RedirectUri` - Redirect Uri. Same value used during Authorization.
* `CodeVerifier` - Code Verifier (Proof Key Code Exchange flow)

**Result**

* `AccessToken` - Access token
* `IdentityToken` - Identity token - only applicable in authorization code flow with requested identity scope
* `RequestedScope` - Space separated list of requested scopes.
* `IssuedTokenType` - Type of issued token
* `TokenType` - Type of token
* `RefreshToken` - Refresh token - only applicable in authorization code flow with requested offline scope.
* `ExpiresOn` - Date and time when access token expires

### RequestRefreshToken

Refresh an access token with a refresh token

**Input parameters**

* `Address` - Identity Provicer Token Endpoint Url
* `ClientId` - Client ID
* `ClientSecret` - Client Secret
* `RefreshToken` - Refresh token

**Result**

* `AccessToken` - Access token
* `IdentityToken` - Identity token - only applicable in authorization code flow with requested identity scope
* `RequestedScope` - Space separated list of requested scopes.
* `IssuedTokenType` - Type of issued token
* `TokenType` - Type of token
* `RefreshToken` - Refresh token - only applicable in authorization code flow with requested offline scope.
* `ExpiresOn` - Date and time when access token expires

### RevokeToken

Revoke an access token

**Input parameters**

* `Address` - Identity Provicer Token Revocation Endpoint Url
* `ClientId` - Client ID
* `ClientSecret` - Client Secret
* `Token` - Access token to revoke

### IntrospectToken

Introspect an access token

**Input parameters**

* `Address` - Identity Provicer Token Introspection Endpoint Url
* `ClientId` - Client ID
* `ClientSecret` - Client Secret
* `Token` - Access token to introspect

**Result**

* `isActive` - Indicates if the access token is active

### GenerateProofKeyCode

Generates code verifier and challange for Proof Key Code Exchange Authorization code flow

**Result**

* `CodeVerifier` - Random code verifier
* `CodeChallenge` - Code challenge
* `CodeChallengeMethod` - Code Challenge Method. Aloways S256.

### GetDiscoveryDocument

Retrieve OpenID Connect Configuration of Identity Provider

**Input parameters**

* `wellKnownEndpointUrl` - Well-Known OpenID Connect configuration endpoint URL

**Result**

* `AuthorizationEndpoint` - URL of the OAuth 2.0 Authorization Endpoint
* `ClaimsSupported` - Array containing a list of the clim-names that the OpenID provider may be able to supply
* `Issuer` - Issuer Identifier
* `JwksUri` - JSON Web Key values endpoint url
* `ResponseTypesSupported` - List of OAuth 2.0 response_type values supported
* `GrantTypesSupported` - List of OAuth 2.0 grant types supported
* `ScopesSupported` - List of OAuth 2.0 scope values supported
* `TokenEndpoint` - Token endpoint url
* `RevocationEndpoint` - Revocation endpoint url
* `UserInfoEndpoint` - User Info endpoint url
* `IntrospectionEndpoint` - Introspection endpoint url
* `EndSessionEndpoint` - End session endpoint url