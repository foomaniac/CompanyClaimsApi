using System.ComponentModel.DataAnnotations;

namespace CompanyClaimsApi.Data.Entities
{
    public class ClaimType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}