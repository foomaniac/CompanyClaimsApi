namespace CompanyClaimsApi.Features.Claims.Dtos
{
    public class ClaimDto
    {
        public string UCR { get; init; }
        public int CompanyId { get; init; }
        public DateTime ClaimDate { get; init; }
        public DateTime LossDate { get; init; }
        public string AssuredName { get; init; }
        public decimal IncurredLoss { get; init; }
        public bool Closed { get; init; }
        public int AgeInDays { get; init; }
    }
}