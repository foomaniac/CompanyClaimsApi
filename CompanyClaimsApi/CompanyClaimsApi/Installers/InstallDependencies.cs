using CompanyClaimsApi.Features.Claims.Repositories;
using CompanyClaimsApi.Features.Claims.Services;
using CompanyClaimsApi.Features.Companies.Repositories;
using CompanyClaimsApi.Features.Companies.Services;

namespace CompanyClaimsApi.Installers
{
    public static class InstallDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services.AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<IClaimsRepository, ClaimsRepository>()
                .AddScoped<IClaimsService, ClaimsService>();
        }
    }
}