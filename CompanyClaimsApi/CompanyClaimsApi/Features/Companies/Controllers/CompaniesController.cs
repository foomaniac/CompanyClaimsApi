using CompanyClaimsApi.Features.Claims.Dtos;
using CompanyClaimsApi.Features.Claims.Services;
using CompanyClaimsApi.Features.Companies.Dtos;
using CompanyClaimsApi.Features.Companies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyClaimsApi.Features.Companies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IClaimsService _claimService;

        public CompaniesController(ICompanyService companyService, IClaimsService claimService)
        {
            _companyService = companyService;
            _claimService = claimService;
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyAsync(int companyId)
        {
            var company = await _companyService.GetCompanyAsync(companyId);

            if (company == null)
            {
                return NotFound($"No company found with provided id {companyId}");
            }

            return Ok(company);
        }

        [HttpGet("{companyId}/claims")]
        public async Task<ActionResult<List<ClaimDto>>> GetClaimsForCompanyAsync(int companyId)
        {
            var claims = await _claimService.GetClaimsForCompanyAsync(companyId);

            return Ok(claims);
        }
    }
}