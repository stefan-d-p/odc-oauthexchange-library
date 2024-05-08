using Microsoft.Extensions.Configuration;

namespace Without.Systems.OAuthTokenExchange.Test;

public class Tests
{
    private static readonly IOAuthTokenExchange _actions = new OAuthTokenExchange();
    private string _discoveryUrl;
    private string _clientId;
    private string _clientSecret;
    
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

    }
    
}