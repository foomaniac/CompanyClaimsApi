using CompanyClaimsApi.Features.Claims.Dtos;

namespace CompanyClaimsApi.Features.Claims.Services
{
    public interface IClaimsService
    {
        Task<ClaimDto?> GetClaimByUcrAsync(string uniqueClaimReference);

        Task<List<ClaimDto>> GetClaimsForCompanyAsync(int companyId);
    }
}