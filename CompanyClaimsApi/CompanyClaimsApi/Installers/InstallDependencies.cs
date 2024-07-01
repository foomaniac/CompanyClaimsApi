using CompanyClaimsApi.Features.Companies.Repositories;

namespace CompanyClaimsApi.Installers
{
    public static class InstallDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services.AddTransient<ICompanyRepository, CompanyRepository>();
            // .AddTransient<IClaimRepository, ClaimRepository>()
            // .AddTransient<IClaimTypeRepository, ClaimTypeRepository>();
        }
    }
}