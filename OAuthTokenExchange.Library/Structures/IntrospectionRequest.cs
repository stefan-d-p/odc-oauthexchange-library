using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Introspect an access token request structure")]
public struct IntrospectionRequest
{
    [OSStructureField(
        Description = "Identity Provider Token Introspection Endpoint Url",
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

    [OSStructureField(Description = "Access token to introspect",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Token;
}