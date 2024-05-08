using System.ComponentModel.DataAnnotations;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Request model for obtaining an access token using client credentials flow")]
public struct ClientCredentialsRequest
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

    [OSStructureField(Description = "Space separated list of requested scopes",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Scope;
}