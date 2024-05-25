using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity.Structures;

[OSStructure(Description = "GetId Response Structure")]
public struct GetIdResponse
{
    [OSStructureField(Description = "A unique identifier in the format REGION:GUID",
        DataType = OSDataType.Text)]
    public string IdentityId;
}