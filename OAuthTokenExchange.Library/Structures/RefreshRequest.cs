using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Refresh an access token with a refresh token request structure")]
public struct RefreshRequest
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
    
    [OSStructureField(Description = "Refresh Token",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string RefreshToken;
}