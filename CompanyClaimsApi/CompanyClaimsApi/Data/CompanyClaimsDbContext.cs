using CompanyClaimsApi.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompanyClaimsApi.Data
{
    public class CompanyClaimsDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<Claim> Claims { get; set; }

        public CompanyClaimsDbContext(DbContextOptions<CompanyClaimsDbContext> options) : base(options)
        {
            SeedData();
        }

        public void SeedData()
        {
            // Check if the database is empty
            if (!Companies.Any())
            {
                Companies.AddRange(
                    new Company()
                    {
                        Id = 1,
                        Name = "Test CompanyDto 1",
                        Address1 = "111 Test Street",
                        Address2 = "Testville",
                        Address3 = "Testshire",
                        Country = "United Kingdom",
                        Postcode = "TE1 1ST",
                        InsuranceEndDate = DateTime.Now.AddYears(1),
                        Active = true
                    },
                    new Company()
                    {
                        Id = 2,
                        Name = "Test CompanyDto 2",
                        Address1 = "222 Test Street",
                        Address2 = "Testville",
                        Address3 = "Testshire",
                        Country = "United Kingdom",
                        Postcode = "TE2 1ST",
                        InsuranceEndDate = DateTime.Now.AddYears(-2),
                        Active = false
                    },
                    new Company()
                    {
                        Id = 3,
                        Name = "Test CompanyDto 3",
                        Address1 = "333 Test Street",
                        Address2 = "Testville",
                        Address3 = "Testshire",
                        Country = "United Kingdom",
                        Postcode = "TE3 1ST",
                        InsuranceEndDate = DateTime.Now.AddYears(-1),
                        Active = false
                    }
                );

                this.SaveChanges();
            }

            if (!ClaimTypes.Any())
            {
                ClaimTypes.AddRange(new ClaimType()
                {
                    Id = 1,
                    Name = "Car Insurance"
                },
                    new ClaimType()
                    {
                        Id = 2,
                        Name = "Home Insurance"
                    },
                    new ClaimType()
                    {
                        Id = 3,
                        Name = "Liability"
                    });

                this.SaveChanges();
            }

            if (!Claims.Any())
            {
                Claims.AddRange(new Claim()
                {
                    UCR = "UCR-C1-1019",
                    CompanyId = 1,
                    ClaimDate = DateTime.Now.AddDays(-50),
                    LossDate = DateTime.Now.AddDays(-55),
                    AssuredName = "Liability",
                    IncurredLoss = 10000,
                    Closed = false
                }, new Claim()
                {
                    UCR = "UCR-C1-1020",
                    CompanyId = 1,
                    ClaimDate = DateTime.Now.AddDays(-45),
                    LossDate = DateTime.Now.AddDays(-49),
                    AssuredName = "Legal Costs",
                    IncurredLoss = 2000,
                    Closed = false
                }, new Claim()
                {
                    UCR = "UCR-C2-1021",
                    CompanyId = 2,
                    ClaimDate = DateTime.Now.AddDays(-24),
                    LossDate = DateTime.Now.AddDays(-20),
                    AssuredName = "Stolen Property",
                    IncurredLoss = 900,
                    Closed = false
                }, new Claim()
                {
                    UCR = "UCR-C3-1022",
                    CompanyId = 3,
                    ClaimDate = DateTime.Now.AddDays(-50),
                    LossDate = DateTime.Now.AddDays(-55),
                    AssuredName = "Malpractice",
                    IncurredLoss = 100000,
                    Closed = true
                });

                this.SaveChanges();
            }
        }
    }
}