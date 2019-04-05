using GroupSports.BL.BC;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace GroupSportsApiRest.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        user userFinded;
        int userLoggedTypeId;
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                LoginDTO loginDTO = new LoginDTO()
                {
                    userName = context.UserName,
                    password = context.Password
                };

                var userService = new UserService();
                userFinded = userService.Login(loginDTO);
                if (userFinded != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userFinded.username),
                        new Claim("UserID", userFinded.id.ToString())
                    };
                    userLoggedTypeId = userService.getUserLoggedTypeId(userFinded.id);
                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            //add user Id and status as additional response parameter
            context.AdditionalResponseParameters.Add("id", userFinded.id);
            context.AdditionalResponseParameters.Add("username", userFinded.username);
            context.AdditionalResponseParameters.Add("userType", userFinded.userType);
            context.AdditionalResponseParameters.Add("firstName", userFinded.firstName);
            context.AdditionalResponseParameters.Add("lastName", userFinded.lastName);
            context.AdditionalResponseParameters.Add("cellPhone", userFinded.cellPhone);
            context.AdditionalResponseParameters.Add("address", userFinded.address);
            context.AdditionalResponseParameters.Add("emailAddress", userFinded.emailAddress);
            context.AdditionalResponseParameters.Add("userLoggedTypeId", userLoggedTypeId);
            context.AdditionalResponseParameters.Add("pictureUrl", userFinded.pictureUrl);
            return base.TokenEndpoint(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}