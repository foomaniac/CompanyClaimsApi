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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
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
                });

            modelBuilder.Entity<ClaimType>().HasData(
                new ClaimType()
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

            //modelBuilder.Entity<Claim>().HasData(
            //    new Claim()
            //    {
            //        CompanyId = 1,
            //        ClaimTypeId = 1,
            //        Date = DateTime.Now,
            //        Amount = 100.00m
            //    },
            //    new Claim()
            //    {
            //        Id = 2,
            //        CompanyId = 1,
            //        ClaimTypeId = 2,
            //        Date = DateTime.Now,
            //        Amount = 200.00m
            //    },
            //    new Claim()
            //    {
            //        Id = 3,
            //        CompanyId = 2,
            //        ClaimTypeId = 3,
            //        Date = DateTime.Now,
            //        Amount = 300.00m
            //    });
        }
    }
}