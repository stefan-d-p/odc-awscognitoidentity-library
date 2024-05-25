using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity.Structures;

[OSStructure(Description = "Provider Map")]
public struct LoginValuePair
{
    [OSStructureField(Description = "Provider Identifier e.g. api.twitter.com",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Provider;
    [OSStructureField(Description = "Provider Token",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Token;
}