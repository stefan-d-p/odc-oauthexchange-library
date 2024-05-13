using System.Diagnostics;
using System.Xml;
using Microsoft.Extensions.Configuration;
using Without.Systems.OAuthTokenExchange.Structures;

namespace Without.Systems.OAuthTokenExchange.Test;

public class Tests
{
    private static readonly IOAuthTokenExchange _actions = new OAuthTokenExchange();
    private string _discoveryUrl;
    private string _clientId;
    private string _clientSecret;

    private DiscoveryRequest _discoveryRequest;
    
    [SetUp]
    public void Setup()
    {

        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        _discoveryUrl = configuration["OAuthDiscoveryUrl"] ?? throw new InvalidOperationException();
        _clientId = configuration["OAuthClientId"] ?? throw new InvalidOperationException();
        _clientSecret = configuration["OAuthClientSecret"] ?? throw new InvalidOperationException();

        _discoveryRequest = new DiscoveryRequest
        {
            Address = _discoveryUrl,
            Policy = new DiscoveryDocumentPolicy
            {
                RequireHttps = false,
                ValidateEndpoints = false,
                RequireKeySet = false,
                ValidateIssuerName = false,
                AllowHttpOnLoopback = true
            }
        };
        
    }

    [Test]
    public void Retrieve_DiscoveryDocument()
    {
        
        
        var result = _actions.GetDiscoveryDocument(_discoveryRequest);
    }

    [Test]
    public void Client_Credentials_Flow()
    {
        var disco = _actions.GetDiscoveryDocument(_discoveryRequest);
        Debug.Assert(disco.TokenEndpoint != null, "disco.TokenEndpoint != null");
        ClientCredentialsRequest request = new ClientCredentialsRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = _clientId,
            ClientSecret = _clientSecret,
            Scope = "openid email profile offline_access https://graph.microsoft.com/.default"
        };

        var result = _actions.RequestClientCredentialsToken(request);
    }
    
}