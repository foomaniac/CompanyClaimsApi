using CompanyClaimsApi.Data.Entities;

namespace CompanyClaimsApi.Features.Companies.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company?> GetCompanyAsync(int companyId);
    }
}