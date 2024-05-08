using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Revoke an access token request structure")]
public struct RevocationRequest
{
    [OSStructureField(
        Description = "Identity Provicer Token Revocation Endpoint Url",
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

    [OSStructureField(Description = "Access token to revoke",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Token;
}