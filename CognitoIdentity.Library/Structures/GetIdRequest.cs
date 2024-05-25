using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity.Structures;

[OSStructure(Description = "GetId Request Parameters")]
public struct GetIdRequest
{
    [OSStructureField(Description = "A standard AWS account ID (9+ digits).",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? AccountId;
    
    [OSStructureField(Description = "An identity pool ID in the format REGION:GUID.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string IdentityPoolId;

    [OSStructureField(Description = "A set of optional name-value pairs that map provider names to provider tokens",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<LoginValuePair>? Logins;
    
}

