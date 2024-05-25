using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity.Structures;

[OSStructure(Description = "Credentials for the provided identity ID")]
public struct Credentials
{
    [OSStructureField(Description = "The Access Key portion of the credentials",
        DataType = OSDataType.Text)]
    public string AccessKeyId;
    
    [OSStructureField(Description = "The Secret Access Key portion of the credentials",
        DataType = OSDataType.Text)]
    public string SecretKey;
    
    [OSStructureField(Description = "The Session Token portion of the credentials",
        DataType = OSDataType.Text)]
    public string SessionToken;
    
    [OSStructureField(Description = "The expiration date of the credentials",
        DataType = OSDataType.DateTime)]
    public DateTime? Expiration;
}