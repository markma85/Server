using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace InnovateFuture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AmazonCognitoIdentityProviderClient _cognitoClient;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            _cognitoClient = new AmazonCognitoIdentityProviderClient();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // var userPoolId = _configuration["AWS:UserPoolId"];
            // var clientId = _configuration["AWS:ClientId"];
            // var region = _configuration["AWS:Region"];
            
            var userPoolId = "ap-southeast-2_tTkhqKaFp";
            var clientId = "bp239bfvl928p58jepshs5kn9";
            var region = "ap-southeast-2";

            // Construct the authentication request for Cognito
            var cognitoClient = new AmazonCognitoIdentityProviderClient(RegionEndpoint.APSoutheast2);

            var authRequest = new AdminInitiateAuthRequest
            {
                UserPoolId = userPoolId,
                ClientId = clientId,
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
                AuthParameters = new System.Collections.Generic.Dictionary<string, string>
                {
                    { "USERNAME", request.Email },
                    { "PASSWORD", request.Password }
                }
            };

            try
            {
                // Call Cognito to authenticate the user
                var authResponse = await _cognitoClient.AdminInitiateAuthAsync(authRequest);

                // Get the JWT token from the response
                var idToken = authResponse.AuthenticationResult.IdToken;
                var accessToken = authResponse.AuthenticationResult.AccessToken;
                var refreshToken = authResponse.AuthenticationResult.RefreshToken;

                // Return the tokens
                return Ok(new
                {
                    IdToken = idToken,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                });
            }
            catch (Exception ex)
            {
                // Handle error (invalid credentials, network issues, etc.)
                return Unauthorized(new { message = ex.Message });
            }
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
