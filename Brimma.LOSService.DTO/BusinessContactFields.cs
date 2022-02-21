using Newtonsoft.Json;

namespace Brimma.LOSService.DTO
{
    /// <summary>
    /// Business Contacts Fields Info
    /// </summary>
    public class BusinessContactFields
    {
        /// <summary>
        /// Contact.AccessLevel
        /// </summary>
        [JsonProperty(PropertyName = "Contact.AccessLevel")]
        public string AccessLevel { get; set; }

        /// <summary>
        /// ContactOwner.UserName
        /// </summary>
        [JsonProperty(PropertyName = "ContactOwner.UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// ContactCategory.CategoryName
        /// </summary>
        [JsonProperty(PropertyName = "ContactCategory.CategoryName")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Contact.FirstName
        /// </summary>
        [JsonProperty(PropertyName = "Contact.FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Contact.LastName
        /// </summary>
        [JsonProperty(PropertyName = "Contact.LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Contact.CompanyName
        /// </summary>
        [JsonProperty(PropertyName = "Contact.CompanyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Contact.JobTitle
        /// </summary>
        [JsonProperty(PropertyName = "Contact.JobTitle")]
        public string JobTitle { get; set; }
    }
}
