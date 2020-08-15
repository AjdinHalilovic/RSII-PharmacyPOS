using System; using System.Text.Json;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pharmacy.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TokenValidation : ActionFilterAttribute
    {
        private readonly bool _ignoreTokenExpirationDateTime;

        public TokenValidation(bool ignoreTokenExpirationDateTime = false)
        {
            _ignoreTokenExpirationDateTime = ignoreTokenExpirationDateTime;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IDataUnitOfWork dataUnitOfWork =
                (IDataUnitOfWork) context.HttpContext.RequestServices.GetService(typeof(IDataUnitOfWork));
            ITokenProcessor tokenProcessor =
                (ITokenProcessor) context.HttpContext.RequestServices.GetService(typeof(ITokenProcessor));

            string token =
                tokenProcessor.ConvertTokenFormatIfNedeed(
                    context.HttpContext.Request.Headers["Authorization"]);

            if (!token.IsSet())
            {
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                context.Result =
                    new JsonResult("Access token is not sent with the request. Check your request headers!");
            }
            else
            {
                bool addClaimsToHttpContext = true;
                //ToDo :: encrypt whole jwt token with hardcoded key
                User user = dataUnitOfWork.BaseUow.UsersRepository.GetByAccessToken(token);

                if (user == null)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    context.Result = new JsonResult("User doesn't exists. Check Access Token!");
                    addClaimsToHttpContext = false;
                }
                else if (DateTime.Now > user.TokenExpirationDateTime && !_ignoreTokenExpirationDateTime)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult("Bad access token!");
                    addClaimsToHttpContext = false;
                }
                else if (DateTime.Now > user.RefreshTokenExpirationDateTime && !_ignoreTokenExpirationDateTime)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Gone;
                    context.Result = new JsonResult("Bad refresh token!");
                    addClaimsToHttpContext = false;
                }

                if (addClaimsToHttpContext)
                {
                    IEnumerable<Claim> claims = tokenProcessor.GetTokenClaims(token);
                    if (claims != null)
                    {
                        ClaimsIdentity appIdentity = new ClaimsIdentity(claims);
                        context.HttpContext.User.AddIdentity(appIdentity);
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
}