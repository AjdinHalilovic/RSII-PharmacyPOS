using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Helpers.TokenProcessor;
using Pharmacy.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Pharmacy.Core.Constants;
using Pharmacy.API.Controllers;

namespace Pharmacy.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TokenValidation : ActionFilterAttribute
    {
        private readonly bool _ignoreTokenExpirationDateTime;
        private Enumerations.WebRole[] _roles { get; }

        public TokenValidation(bool ignoreTokenExpirationDateTime = false, Enumerations.WebRole[] roles = null)
        {
            _ignoreTokenExpirationDateTime = ignoreTokenExpirationDateTime;
            _roles = roles;

        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            IDataUnitOfWork dataUnitOfWork =
                (IDataUnitOfWork)context.HttpContext.RequestServices.GetService(typeof(IDataUnitOfWork));
            ITokenProcessor tokenProcessor =
                (ITokenProcessor)context.HttpContext.RequestServices.GetService(typeof(ITokenProcessor));

            string token =
                tokenProcessor.ConvertTokenFormatIfNedeed(
                    context.HttpContext.Request.Headers["Authorization"]);

            if (!token.IsSet())
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
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

                    if (_roles != null)
                    {
                        ClaimUser ClaimUser = context.HttpContext.User.Claims.Any() ? new ClaimUser(context.HttpContext.User.Claims) : null;
                        var roles = ClaimUser.UserRole;

                        var authorized = false;
                        foreach (var role in _roles)
                        {
                            if (roles.Select(x => x.RoleId).Contains((int)role))
                            {
                                authorized = true;
                            }
                        }
                        if (!authorized)
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult("You are not authorized to access requested resource.");
                            addClaimsToHttpContext = false;
                        }
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
}