using System.Net;
using Amazon.CognitoIdentity;
using Amazon.Runtime;
using AutoMapper;
using Without.Systems.CognitoIdentity.Util;

namespace Without.Systems.CognitoIdentity;

public class CognitoIdentity : ICognitoIdentity
{

    private readonly IMapper _mapper;
    
    public CognitoIdentity()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            
            /*
             * Request Mappings
             */
            
            cfg.CreateMap<Structures.GetIdRequest, Amazon.CognitoIdentity.Model.GetIdRequest>()
                .ForMember(dest => dest.AccountId, opt => opt.Condition(src => !string.IsNullOrEmpty(src.AccountId)))
                .ForMember(dest => dest.Logins, opt => opt.Condition(src => src.Logins is { Count: > 0 }))
                .ForMember(dest => dest.Logins,
                    opt => opt.MapFrom(src => src.Logins!.ToDictionary(pt => pt.Provider, pt => pt.Token)));

            cfg.CreateMap<Structures.GetCredentialsForIdentityRequest,
                    Amazon.CognitoIdentity.Model.GetCredentialsForIdentityRequest>()
                .ForMember(dest => dest.CustomRoleArn,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.CustomRoleArn)))
                .ForMember(dest => dest.Logins, opt => opt.Condition(src => src.Logins is { Count: > 0 }))
                .ForMember(dest => dest.Logins,
                    opt => opt.MapFrom(src => src.Logins!.ToDictionary(pt => pt.Provider, pt => pt.Token)));

            /*
             * Response Mappings
             */
            
            cfg.CreateMap<Amazon.CognitoIdentity.Model.GetIdResponse, Structures.GetIdResponse>();
            cfg.CreateMap<Amazon.CognitoIdentity.Model.GetCredentialsForIdentityResponse,
                    Structures.GetCredentialsForIdentityResponse>();
            
            /*
             * Individual Mappings
             */

            cfg.CreateMap<Amazon.CognitoIdentity.Model.Credentials, Structures.Credentials>();


        });

        _mapper = mapperConfiguration.CreateMapper();
    }

    /// <summary>
    /// Generates (or retrieves) IdentityID. Supplying multiple logins will create an implicit linked account
    /// </summary>
    /// <param name="getIdRequest">GetId Request Parameters</param>
    /// <returns>Identity Identifier</returns>
    public Structures.GetIdResponse GetId(Structures.GetIdRequest getIdRequest)
    {
        AmazonCognitoIdentityClient client = GetCognitoClient();
        var request = _mapper.Map<Amazon.CognitoIdentity.Model.GetIdRequest>(getIdRequest);
        Amazon.CognitoIdentity.Model.GetIdResponse response = AsyncUtil.RunSync(() => client.GetIdAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.GetIdResponse>(response);
    }

    /// <summary>
    /// Returns credentials for the provided identity ID. Any provided logins will be validated against supported login providers
    /// </summary>
    /// <param name="getCredentialsForIdentityRequest">Get Credentials For Identity Request Parameters</param>
    /// <returns>Credentials</returns>
    public Structures.GetCredentialsForIdentityResponse GetCredentialsForIdentity(
        Structures.GetCredentialsForIdentityRequest getCredentialsForIdentityRequest)
    {
        AmazonCognitoIdentityClient client = GetCognitoClient();
        var request = _mapper.Map<Amazon.CognitoIdentity.Model.GetCredentialsForIdentityRequest>(getCredentialsForIdentityRequest);
        Amazon.CognitoIdentity.Model.GetCredentialsForIdentityResponse response = AsyncUtil.RunSync(() => client.GetCredentialsForIdentityAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.GetCredentialsForIdentityResponse>(response);
    }
   
    /// <summary>
    /// Anonymous / Public Cognito Client
    /// </summary>
    /// <returns>AmazonCognitoIdentityClient</returns>
    private AmazonCognitoIdentityClient GetCognitoClient() => new AmazonCognitoIdentityClient();
    
    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
}