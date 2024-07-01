using System;

namespace CompanyClaimsApi.Features.Companies.Dtos
{
    public class CompanyDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Address1 { get; init; }
        public string Address2 { get; init; }
        public string Address3 { get; init; }
        public string Postcode { get; init; }
        public string Country { get; init; }
        public bool Active { get; init; }
        public DateTime InsuranceEndDate { get; init; }
        public bool HasActivePolicy { get; init; }
    }
}