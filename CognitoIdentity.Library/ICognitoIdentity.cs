using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.CognitoIdentity
{
    [OSInterface(
        Name = "AWSCognitoIdentity",
        Description = "An Amazon Cognito identity pool is a directory of federated identities that you can exchange for AWS credentials. Identity pools generate temporary AWS credentials for the users of your app, whether they’ve signed in or you haven’t identified them yet. With AWS Identity and Access Management (IAM) roles and policies, you can choose the level of permission that you want to grant to your users",
        IconResourceName = "Without.Systems.CognitoIdentity.Resources.Cognito.png")]
    public interface ICognitoIdentity
    {
        [OSAction(
            Description =
                "Generates (or retrieves) IdentityID. Supplying multiple logins will create an implicit linked account",
            ReturnName = "result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.CognitoIdentity.Resources.Cognito.png")]
        Structures.GetIdResponse GetId(
            [OSParameter(
                DataType = OSDataType.InferredFromDotNetType,
                Description = "GetId Request Parameters")]
            Structures.GetIdRequest getIdRequest);
        
        [OSAction(
            Description =
                "Returns credentials for the provided identity ID. Any provided logins will be validated against supported login providers",
            ReturnName = "credentials",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.CognitoIdentity.Resources.Cognito.png")]
        Structures.GetCredentialsForIdentityResponse GetCredentialsForIdentity(
            [OSParameter(
                DataType = OSDataType.InferredFromDotNetType,
                Description = "GetCredentialsForIdentity Request Parameters")]
            Structures.GetCredentialsForIdentityRequest getCredentialsForIdentityRequest);
    }
}