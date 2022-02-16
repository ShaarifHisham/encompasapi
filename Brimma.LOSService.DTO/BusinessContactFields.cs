using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Brimma.LOSService.DTO
{
    /// <summary>
    /// Business Contacts Fields Info
    /// </summary>
    public class BusinessContactFields
    {
        [JsonProperty(PropertyName = "Contact.AccessLevel")]
        public string AccessLevel { get; set; }

        [JsonProperty(PropertyName = "ContactOwner.UserName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "ContactCategory.CategoryName")]
        public string CategoryName { get; set; }

        [JsonProperty(PropertyName = "Contact.FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "Contact.LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Contact.CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "Contact.JobTitle")]
        public string JobTitle { get; set; }
    }
}
