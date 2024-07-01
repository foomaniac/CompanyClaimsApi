using CompanyClaimsApi.Features.Claims.Dtos;
using CompanyClaimsApi.Features.Claims.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyClaimsApi.Features.Claims.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsService;

        public ClaimsController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }

        [HttpGet("{uniqueClaimReference}")]
        public async Task<ActionResult<ClaimDto>> GetClaimByUcrAsync(string uniqueClaimReference)
        {
            var claim = await _claimsService.GetClaimByUcrAsync(uniqueClaimReference);

            if (claim == null)
            {
                return NotFound($"No claim found with provided unique claim reference {uniqueClaimReference}");
            }

            return Ok(claim);
        }
    }
}