using CompanyClaimsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyClaimsApi.Installers
{
    public static class InstallDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CompanyClaimsDbContext>(options => options.UseInMemoryDatabase("CompanyDb"));
            return service;
        }
    }
}