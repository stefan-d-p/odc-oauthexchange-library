using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Well known OpenID Discovery document")]
public struct DiscoveryDocument
{
    [OSStructureField(Description = "URL of the OAuth 2.0 Authorization Endpoint",
        DataType = OSDataType.Text)]
    public string? AuthorizationEndpoint;

    [OSStructureField(Description =
        "Array containing a list of the clim-names that the OpenID provider may be able to supply.")]
    public List<string>? ClaimsSupported;
    
    [OSStructureField(Description = "Issuer Identifier",
        DataType = OSDataType.Text)]
    public string? Issuer;

    [OSStructureField(Description = "JSON Web Key values endpoint url",
        DataType = OSDataType.Text)]
    public string? JwksUri;
    
    [OSStructureField(Description = "List of OAuth 2.0 response_type values supported",
        DataType = OSDataType.Text)]
    public List<string>? ResponseTypesSupported;
    
    [OSStructureField(Description = "List of OAuth 2.0 grant types supported",
        DataType = OSDataType.InferredFromDotNetType)]
    public List<string>? GrantTypesSupported;
    
    [OSStructureField(Description = "List of OAuth 2.0 scope values supported",
        DataType = OSDataType.InferredFromDotNetType)]
    public List<string>? ScopesSupported;

    [OSStructureField(Description = "Token endpoint",
        DataType = OSDataType.Text)]
    public string? TokenEndpoint;
    
    [OSStructureField(Description = "Revocation endpoint",
        DataType = OSDataType.Text)]
    public string? RevocationEndpoint;
    
    [OSStructureField(Description = "Userinfo endpoint",
        DataType = OSDataType.Text)]
    public string? UserInfoEndpoint;
    
    [OSStructureField(Description = "Introspection endpoint",
        DataType = OSDataType.Text)]
    public string? IntrospectionEndpoint;
    
    [OSStructureField(Description = "End session endpoint",
        DataType = OSDataType.Text)]
    public string? EndSessionEndpoint;
}