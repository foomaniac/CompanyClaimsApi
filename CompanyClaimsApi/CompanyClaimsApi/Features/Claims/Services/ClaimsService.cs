using CompanyClaimsApi.Data.Entities;
using CompanyClaimsApi.Features.Claims.Dtos;
using CompanyClaimsApi.Features.Claims.Mappers;
using CompanyClaimsApi.Features.Claims.Repositories;
using CompanyClaimsApi.Shared;

namespace CompanyClaimsApi.Features.Claims.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly IClaimsRepository _claimsRepository;
        private readonly ILogger<ClaimsService> _logger;

        public ClaimsService(IClaimsRepository claimsRepository, ILogger<ClaimsService> logger)
        {
            _claimsRepository = claimsRepository;
            _logger = logger;
        }

        public async Task<ClaimDto?> GetClaimByUcrAsync(string uniqueClaimReference)
        {
            Claim? claim = await _claimsRepository.GetClaimByUcrAsync(uniqueClaimReference);

            if (claim == null)
            {
                _logger.LogInformation($"No claim found with UCR {uniqueClaimReference}");
                return null;
            }

            return claim.MapToDto();
        }

        public async Task<List<ClaimDto>> GetClaimsForCompanyAsync(int companyId)
        {
            List<Claim> claims = await _claimsRepository.GetClaimsForCompanyAsync(companyId);

            if (!claims.Any())
            {
                _logger.LogInformation("No claims found for company with ID {companyId}", companyId);
                return Enumerable.Empty<ClaimDto>().ToList();
            }

            return claims.Select(claim => claim.MapToDto()).ToList();
        }

        public async Task<ClaimDto?> UpdateClaimAsync(ClaimDto claimDto)
        {
            Claim? existingClaim = await _claimsRepository.GetClaimByUcrAsync(claimDto.UCR);

            if (existingClaim is null)
            {
                _logger.LogInformation("No claim found with UCR {claim.UCR}", claimDto.UCR);
                return null;
            }

            existingClaim = claimDto.MapDtoToEntity();

            Claim updatedClaim = await _claimsRepository.UpdateClaim(existingClaim);

            return updatedClaim.MapToDto();
        }
    }
}