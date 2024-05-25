# Outsystems External Logic Connector Library for AWS Cognito Identity Pools

## Actions
The library exposes the following actions

### GetId

Generates (or retrieves) IdentityID. Supplying multiple logins will create an implicit linked account
**Input parameters**

* `AccountId` - A standard AWS account ID (9+ digits)
* `IdentityPoolId` - An identity pool ID in the format REGION:GUID.
* `Logins` - A set of optional name-value pairs that map provider names to provider tokens

**Result**

* `IdentityId` - A unique identifier in the format REGION:GUID

### GetCredentialsForIdentity

Generates (or retrieves) IdentityID. Supplying multiple logins will create an implicit linked account
**Input parameters**

* `CustomRoleArn` - The Amazon Resource Name (ARN) of the role to be assumed when multiple roles were received in the token from the identity provider. For example, a SAML-based identity provider. This parameter is optional for identity providers that do not support role customization
* `IdentityId` - A unique identifier in the format REGION:GUID
* `Logins` - A set of optional name-value pairs that map provider names to provider tokens

**Result**

* `IdentityId` - A unique identifier in the format REGION:GUID
* `Credentials` - Credentials for the provided Identity ID


