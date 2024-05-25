using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity.Structures;

[OSStructure(Description = "GetCredentialsForIdentity Response Structure")]
public struct GetCredentialsForIdentityResponse
{
    [OSStructureField(Description = "Credentials for the provided Identity ID",
        DataType = OSDataType.Text)]
    public Credentials Credentials;
    
    [OSStructureField(Description = "A unique identifier in the format REGION:GUID",
        DataType = OSDataType.Text)]
    public string IdentityId;
}