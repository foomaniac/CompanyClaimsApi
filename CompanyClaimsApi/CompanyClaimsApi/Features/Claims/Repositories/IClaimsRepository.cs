using CompanyClaimsApi.Data.Entities;

namespace CompanyClaimsApi.Features.Claims.Repositories
{
    public interface IClaimsRepository
    {
        Task<Claim?> GetClaimByUcrAsync(string uniqueClaimReference);

        Task<List<Claim>> GetClaimsForCompanyAsync(int companyId);
    }
}