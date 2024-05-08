﻿using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Request model for exchanging an authorization code for an access token")]
public struct AuthorizationCodeRequest
{
    [OSStructureField(
        Description = "Identity Provicer Token Endpoint Url",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Address;

    [OSStructureField(Description = "Client Id",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ClientId;

    [OSStructureField(Description = "Client Secret",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ClientSecret;

    [OSStructureField(Description = "Authorization code retrieved from the authorization server",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Code;

    [OSStructureField(Description = "Redirect Uri. Same value used during Authorization.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string RedirectUri;
    
    [OSStructureField(Description = "Code Verifier (Proof Key Code Exchange flow)",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? CodeVerifier;
    
}