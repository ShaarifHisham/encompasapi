using System.ComponentModel.DataAnnotations;

namespace Brimma.LOSService.DTO
{
    public class BusinessContactCurrentMailingAddress
    {
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
