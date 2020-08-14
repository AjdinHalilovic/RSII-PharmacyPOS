using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Filters;
using Pharmacy.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    #region Claim user
    public class ClaimUser
    {
        public ClaimUser(IEnumerable<Claim> claims)
        {
            claims = claims.ToArray();

            UserId = int.Parse(claims.FirstOrDefault(x => x.Type.Equals(nameof(Pharmacy.Core.Entities.Base.DTO.UserDto.UserId)))?.Value ?? throw new InvalidOperationException());

            //Claim organizationIdClaim = claims.FirstOrDefault(x => x.Type.Equals(nameof(EmaHealth.Core.Entities.Base.DTO.UserDto.OrganizationId)));
            //OrganizationId = organizationIdClaim != null && organizationIdClaim.Value.IsSet() ? int.Parse(organizationIdClaim.Value) : (int?)null;

        }

        public int UserId { get; set; }

        //public int? OrganizationId { get; set; }


    }

    #endregion

    [ApiController]
    public class BaseController : ControllerBase
    {
        #region Properties
        protected ClaimUser ClaimUser => HttpContext.User.Claims.Any() ? new ClaimUser(HttpContext.User.Claims) : null;
        protected Uri BaseUri => new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}");

        protected readonly IDataUnitOfWork DataUnitOfWork;
        #endregion

        public BaseController(IDataUnitOfWork dataUnitOfWork)
        {
            DataUnitOfWork = dataUnitOfWork;
        }

        #region Object results

        protected static ObjectResult Gone(object value)
        {
            return new ObjectResult(value)
            {
                StatusCode = StatusCodes.Status410Gone
            };
        }

        protected static ObjectResult InternalServerError(object value)
        {
            return new ObjectResult(value)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        #endregion
    }
}
