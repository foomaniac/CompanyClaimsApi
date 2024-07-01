using CompanyClaimsApi.Data;
using CompanyClaimsApi.Data.Entities;

namespace CompanyClaimsApi.Features.Companies.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyClaimsDbContext _dbContext;

        public CompanyRepository(CompanyClaimsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            return await _dbContext.Companies.FindAsync(companyId);
        }
    }
}