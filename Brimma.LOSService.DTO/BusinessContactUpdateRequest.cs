using System.ComponentModel.DataAnnotations;

namespace Brimma.LOSService.DTO
{
    public class BusinessContactUpdateRequest
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public BusinessContactCurrentMailingAddress CurrentMailingAddress { get; set; }
        public string JobTitle { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string PersonalEmail { get; set; }
        public string BusinessEmail { get; set; }
        public int CategoryId { get; set; }
        public string CompanyName { get; set; }
    }
}
