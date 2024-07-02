using CompanyClaimsApi.Data.Entities;
using CompanyClaimsApi.Features.Companies.Repositories;
using CompanyClaimsApi.Features.Companies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;

namespace CompanyClaimsApi.Tests.Features.Companies
{
    public class CompanyServiceTests
    {
        [Fact]
        public async void GivenIHaveAValidCompanyId_IfCompanyHasAnActivePolicy_CompanyActivePolicyFlagIsTrue()
        {
            // Arrange
            var mockRepository = Substitute.For<ICompanyRepository>();
            var testCompanyId = 1;
            var futureDate = DateTime.Now.AddDays(30); // InsuranceEndDate 30 days in the future

            mockRepository.GetCompanyAsync(testCompanyId)
                .Returns(Task.FromResult(new Company
                {
                    Id = testCompanyId,
                    InsuranceEndDate = futureDate,
                    Name = "Test CompanyDto 2",
                    Address1 = "222 Test Street",
                    Address2 = "Testville",
                    Address3 = "Testshire",
                    Country = "United Kingdom",
                    Postcode = "TE2 1ST",
                    Active = true
                }));

            var companyService = new CompanyService(mockRepository, new NullLogger<CompanyService>());

            // Act
            var result = await companyService.GetCompanyAsync(testCompanyId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testCompanyId, result.Id);
            Assert.True(result.HasActivePolicy);
        }

        [Fact]
        public async void GivenIHaveAValidCompanyId_IfCompanyDoesNotHaveAnActivePolicy_CompanyActivePolicyFlagIsFalse()
        {
            // Arrange
            var mockRepository = Substitute.For<ICompanyRepository>();
            var testCompanyId = 1;
            var futureDate = DateTime.Now.AddDays(-30); // InsuranceEndDate 30 days in the future

            mockRepository.GetCompanyAsync(testCompanyId)
                .Returns(Task.FromResult(new Company
                {
                    Id = testCompanyId,
                    InsuranceEndDate = futureDate,
                    Name = "Test CompanyDto 2",
                    Address1 = "222 Test Street",
                    Address2 = "Testville",
                    Address3 = "Testshire",
                    Country = "United Kingdom",
                    Postcode = "TE2 1ST",
                    Active = true
                }));

            var companyService = new CompanyService(mockRepository, new NullLogger<CompanyService>());

            // Act
            var result = await companyService.GetCompanyAsync(testCompanyId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testCompanyId, result.Id);
            Assert.False(result.HasActivePolicy);
        }
    }
}