using CompanyClaimsApi.Data.Entities;
using CompanyClaimsApi.Features.Claims.Dtos;
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

            //TODO:// Implement mapping solution
            return new ClaimDto
            {
                UCR = claim.UCR,
                CompanyId = claim.CompanyId,
                ClaimDate = claim.ClaimDate,
                LossDate = claim.LossDate,
                AssuredName = claim.AssuredName,
                AgeInDays = DaysBetweenDates.Get(claim.ClaimDate, DateTime.Now),
            };
        }

        public async Task<List<ClaimDto>> GetClaimsForCompanyAsync(int companyId)
        {
            List<Claim> claims = await _claimsRepository.GetClaimsForCompanyAsync(companyId);

            if (!claims.Any())
            {
                _logger.LogInformation($"No claims found for company with ID {companyId}");
                return Enumerable.Empty<ClaimDto>().ToList();
            }

            //TODO:// Implement mapping solution
            return claims.Select(claim => new ClaimDto
            {
                UCR = claim.UCR,
                CompanyId = claim.CompanyId,
                ClaimDate = claim.ClaimDate,
                LossDate = claim.LossDate,
                AssuredName = claim.AssuredName,
                IncurredLoss = claim.IncurredLoss,
                Closed = claim.Closed,
                AgeInDays = DaysBetweenDates.Get(claim.ClaimDate, DateTime.Now),
            }).ToList();
        }
    }
}