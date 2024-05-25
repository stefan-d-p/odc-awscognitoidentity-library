using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity.Structures;

[OSStructure(Description = "GetCredentialsForIdentity Request Parameters")]
public struct GetCredentialsForIdentityRequest
{
    [OSStructureField(
        Description =
            "The Amazon Resource Name (ARN) of the role to be assumed when multiple roles were received in the token from the identity provider. For example, a SAML-based identity provider. This parameter is optional for identity providers that do not support role customization",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? CustomRoleArn;
    
    [OSStructureField(Description = "A unique identifier in the format REGION:GUID",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string IdentityId;

    [OSStructureField(Description = "A set of optional name-value pairs that map provider names to provider tokens",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<LoginValuePair>? Logins;
}