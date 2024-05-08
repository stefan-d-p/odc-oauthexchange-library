using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using IdentityModel;
using IdentityModel.Client;
using Without.Systems.OAuthTokenExchange.Structures;
using Without.Systems.OAuthTokenExchange.Util;

namespace Without.Systems.OAuthTokenExchange;

public class OAuthTokenExchange : IOAuthTokenExchange
{
    
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly IMapper _automapper;

    public OAuthTokenExchange()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ClientCredentialsRequest, ClientCredentialsTokenRequest>();
            cfg.CreateMap<AuthorizationCodeRequest, AuthorizationCodeTokenRequest>()
                .ForMember(dest => dest.CodeVerifier,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.CodeVerifier)));
            cfg.CreateMap<RefreshRequest, RefreshTokenRequest>();
            cfg.CreateMap<TokenRevocationRequest, RevocationRequest>();
            cfg.CreateMap<DiscoveryDocumentResponse, DiscoveryDocument>();
            cfg.CreateMap<TokenResponse, TokenResult>()
                .ForMember(dest => dest.ExpiresOn, opt => opt.MapFrom(src => DateTime.Now.AddSeconds(src.ExpiresIn)));
        });
        
        _automapper = mapperConfiguration.CreateMapper();
    }

    public ProofKeyCode GenerateProofKeyCode()
    {
        using (var sha256 = SHA256.Create())
        {
            string codeVerifier = KeyGenerator.Random(48);
            byte[] challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
            string codeChallenge = Base64Url.Encode(challengeBytes);
            return new ProofKeyCode(codeVerifier, codeChallenge, "S256");
        }
    }
    
    public TokenResult RequestClientCredentialsToken(ClientCredentialsRequest clientCredentialsRequest)
    {
        var request = _automapper.Map<ClientCredentialsTokenRequest>(clientCredentialsRequest);
        TokenResponse response = AsyncUtil.RunSync(() => _httpClient.RequestClientCredentialsTokenAsync(request));
        if (response.IsError) throw new Exception(response.Error);
        return _automapper.Map<TokenResult>(response);
    }
    
    public TokenResult RequestAuthorizationCodeToken(AuthorizationCodeRequest authorizationCodeRequest)
    {
        var request = _automapper.Map<AuthorizationCodeTokenRequest>(authorizationCodeRequest);
        TokenResponse response = AsyncUtil.RunSync(() => _httpClient.RequestAuthorizationCodeTokenAsync(request));
        if (response.IsError) throw new Exception(response.Error);
        return _automapper.Map<TokenResult>(response);
    }
    
    public TokenResult RequestRefreshToken(RefreshRequest  refreshRequest)
    {
        var request = _automapper.Map<RefreshTokenRequest>(refreshRequest);
        TokenResponse response = AsyncUtil.RunSync(() => _httpClient.RequestRefreshTokenAsync(request));
        if (response.IsError) throw new Exception(response.Error);
        return _automapper.Map<TokenResult>(response);
    }
    
    public void RevokeToken(RevocationRequest revocationRequest)
    {
        var request = _automapper.Map<TokenRevocationRequest>(revocationRequest);
        TokenRevocationResponse response = AsyncUtil.RunSync(() => _httpClient.RevokeTokenAsync(request));
        if(response.IsError) throw new Exception(response.Error);
    }

    public DiscoveryDocument GetDiscoveryDocument(string wellKnownEndpointUrl)
    {
        DiscoveryDocumentResponse response = AsyncUtil.RunSync(() => _httpClient.GetDiscoveryDocumentAsync(wellKnownEndpointUrl));
        if (response.IsError) throw new Exception(response.Error);
        return _automapper.Map<DiscoveryDocument>(response);
    }
    
    public bool IntrospectToken(IntrospectionRequest  introspectionRequest)
    {
        var request = _automapper.Map<TokenIntrospectionRequest>(introspectionRequest);
        TokenIntrospectionResponse response = AsyncUtil.RunSync(() => _httpClient.IntrospectTokenAsync(request));
        if(response.IsError) throw new Exception(response.Error);
        return response.IsActive;
    }
    
    

    
}