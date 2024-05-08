using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.OAuthTokenExchange.Structures;

[OSStructure(Description = "Generated Proof Key Code")]
public struct ProofKeyCode
{
    [OSStructureField(Description = "Random code verifier",
        DataType = OSDataType.Text)]
    public string CodeVerifier;
    
    [OSStructureField(Description = "Code challenge",
        DataType = OSDataType.Text)]
    public string CodeChallenge;
    
    [OSStructureField(Description = "Code challenge method",
        DataType = OSDataType.Text)]
    public string CodeChallengeMethod;

    public ProofKeyCode(string codeVerifier, string codeChallenge, string codeChallengeMethod)
    {
        CodeVerifier = codeVerifier;
        CodeChallenge = codeChallenge;
        CodeChallengeMethod = codeChallengeMethod;
    }
}