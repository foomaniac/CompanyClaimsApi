using CompanyClaimsApi.Data;
using CompanyClaimsApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyClaimsApi.Features.Claims.Repositories
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly CompanyClaimsDbContext _dbContext;

        public ClaimsRepository(CompanyClaimsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Claim?> GetClaimByUcrAsync(string uniqueClaimReference)
        {
            return await _dbContext.Claims.FirstOrDefaultAsync(c => c.UCR == uniqueClaimReference);
        }

        public async Task<List<Claim>> GetClaimsForCompanyAsync(int companyId)
        {
            return await _dbContext.Claims.Where(c => c.CompanyId == companyId).ToListAsync();
        }
    }
}