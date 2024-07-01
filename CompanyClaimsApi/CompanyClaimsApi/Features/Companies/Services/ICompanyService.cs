using CompanyClaimsApi.Features.Companies.Dtos;

namespace CompanyClaimsApi.Features.Companies.Services
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetCompanyAsync(int companyId);
    }
}