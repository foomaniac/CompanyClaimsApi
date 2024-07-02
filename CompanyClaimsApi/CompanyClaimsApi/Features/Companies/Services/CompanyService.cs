using CompanyClaimsApi.Data.Entities;
using CompanyClaimsApi.Features.Companies.Dtos;
using CompanyClaimsApi.Features.Companies.Repositories;

namespace CompanyClaimsApi.Features.Companies.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<CompanyDto?> GetCompanyAsync(int companyId)
        {
            Company? company = await _companyRepository.GetCompanyAsync(companyId);

            if (company is null)
            {
                _logger.LogError($"Company with id {companyId} not found");
                return null;
            }

            //TODO:// Implement mapper solution
            CompanyDto companyDto = new CompanyDto()
            {
                Active = company.Active,
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Country = company.Country,
                Id = company.Id,
                InsuranceEndDate = company.InsuranceEndDate,
                Name = company.Name,
                Postcode = company.Postcode,
                HasActivePolicy = company.InsuranceEndDate.Date > DateTime.UtcNow.Date
            };

            return companyDto;
        }
    }
}