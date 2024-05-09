using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Retrieve Discovery Document from Identity Provider request model")]
public struct DiscoveryRequest
{
    [OSStructureField(
        Description = "Identity Provider Well-Known Configuration Endpoint Url",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Address;

    [OSStructureField(Description = "Validation Policy",
        IsMandatory = false)]
    public DiscoveryDocumentPolicy? Policy;

}

[OSStructure(Description = "Discovery Document Policy")]
public struct DiscoveryDocumentPolicy
{
    [OSStructureField(Description = "Specifies if HTTPS is enforced on all endpoints. Defaults to true.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool RequireHttps;

    [OSStructureField(Description = "Specifies if all endpoints are checked to belong to the authority. Defaults to true.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool ValidateEndpoints;

    [OSStructureField(Description = "Specifies if a key set is required. Defaults to true.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool RequireKeySet;
    
    [OSStructureField(Description = "Specifies if the issuer name is checked to be identical to the authority. Defaults to true.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool ValidateIssuerName;
    
    [OSStructureField(Description = "Specifies if HTTP is allowed on loopback addresses. Defaults to true.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool AllowHttpOnLoopback;
}