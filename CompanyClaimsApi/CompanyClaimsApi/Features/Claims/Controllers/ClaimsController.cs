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

        [HttpPut("{uniqueClaimReference}")]
        public async Task<IActionResult> UpdateClaim(string uniqueClaimReference, [FromBody] ClaimDto claimDto)
        {
            if (uniqueClaimReference != claimDto.UCR)
            {
                return BadRequest("UCR mismatch between uri and input payload");
            }

            var updatedClaim = await _claimsService.UpdateClaimAsync(claimDto);

            if (updatedClaim == null)
            {
                return NotFound();
            }

            return Ok(updatedClaim);
        }
    }
}