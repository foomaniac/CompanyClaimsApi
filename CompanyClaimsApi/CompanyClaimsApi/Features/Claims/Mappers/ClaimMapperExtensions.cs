using CompanyClaimsApi.Data.Entities;
using CompanyClaimsApi.Features.Claims.Dtos;
using CompanyClaimsApi.Shared;

namespace CompanyClaimsApi.Features.Claims.Mappers
{
    public static class ClaimMapperExtensions
    {
        public static ClaimDto MapToDto(this Claim claim)
        {
            return new ClaimDto
            {
                UCR = claim.UCR,
                CompanyId = claim.CompanyId,
                ClaimDate = claim.ClaimDate,
                LossDate = claim.LossDate,
                AssuredName = claim.AssuredName,
                IncurredLoss = claim.IncurredLoss,
                Closed = claim.Closed,
                AgeInDays = DaysBetweenDates.Get(claim.ClaimDate, DateTime.Now)
            };
        }

        public static Claim MapDtoToEntity(this ClaimDto claimDto)
        {
            return new Claim()
            {
                UCR = claimDto.UCR,
                CompanyId = claimDto.CompanyId,
                ClaimDate = claimDto.ClaimDate,
                LossDate = claimDto.LossDate,
                AssuredName = claimDto.AssuredName,
                IncurredLoss = claimDto.IncurredLoss,
                Closed = claimDto.Closed
            };
        }
    }
}