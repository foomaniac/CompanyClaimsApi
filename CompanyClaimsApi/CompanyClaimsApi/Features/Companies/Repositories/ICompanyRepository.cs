using CompanyClaimsApi.Data.Entities;

namespace CompanyClaimsApi.Features.Companies.Repositories
{
    public interface ICompanyRepository
    {
        public Task<Company> GetCompanyAsync(int companyId);
    }
}