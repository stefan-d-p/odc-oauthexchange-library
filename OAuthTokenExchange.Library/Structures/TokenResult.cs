using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Token result structure")]
public struct TokenResult
{
    [OSStructureField(Description = "Access Token",
        DataType = OSDataType.Text)]
    public string? AccessToken;

    [OSStructureField(Description = "Identity Token",
        DataType = OSDataType.Text)]
    public string? IdentityToken;

    [OSStructureField(Description = "Requested scope",
        DataType = OSDataType.Text)]
    public string? Scope;

    [OSStructureField(Description = "Issued Token Type",
        DataType = OSDataType.Text)]
    public string? IssuedTokenType;
    
    [OSStructureField(Description = "Token Type",
        DataType = OSDataType.Text)]
    public string? TokenType;

    [OSStructureField(Description = "Refresh Token",
        DataType = OSDataType.Text)]
    public string? RefreshToken;
    
    [OSStructureField(Description = "Expires In",
        DataType = OSDataType.Integer)]
    public int? ExpiresIn;
}