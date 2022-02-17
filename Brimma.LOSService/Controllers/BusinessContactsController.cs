using Brimma.LOSService.DTO;
using Brimma.LOSService.Extensions;
using Brimma.LOSService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Brimma.LOSService.Controllers
{
    [ApiVersion("1.0")]
    [Route("encompass/v{v:apiVersion}/businessContactSelector")]
    [ApiController]
    public class BusinessContactsController : Controller
    {
        private readonly IBusinessContactService businessContactService;

        public BusinessContactsController(IBusinessContactService businessContactService)
        {
            this.businessContactService = businessContactService;
        }

        /// <summary>
        /// Retrives list of Business contacts
        /// </summary>
        /// <param name="businessContactRequest">Business contacts fields</param>
        /// <param name="start">Start index</param>
        /// <param name="limit">Maximum records</param>
        /// <returns>list of business contacts</returns>
        /// <response code="200">Successfully retrieved Business Contacts.</response>
        /// <response code="401">Access token is missing or invalid.</response>
        [HttpPost]
        [Produces("application/json")]
        [ApiExplorerSettings(GroupName = "v1")]
        [MiddlewareFilter(typeof(CustomAuthorizationPipeline))]
        [ProducesResponseType(typeof(HashSet<BusinessContactResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<Object> GetContactList([FromBody] Object businessContactRequest,
                                                 [FromQuery] int start,[FromQuery] int limit)
        {
            return await businessContactService.GetBusinessContacts(businessContactRequest,start,limit).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates contact information for the specified contact ID.
        /// </summary>
        /// <param name="contactId">The unique identifier assigned to the business contacts</param>
        /// <param name="request">Business contact update request.</param>
        /// <response code="204">Successfully updated business contact.</response>
        /// <response code="401">Access token is missing or invalid.</response>
        /// <response code="400">Request has invalid values</response>
        [HttpPatch("{contactId}")]
        [Produces("application/json")]
        [ApiExplorerSettings(GroupName = "v1")]
        [MiddlewareFilter(typeof(CustomAuthorizationPipeline))]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<Object> UpdateContact([FromRoute][Required] string contactId, 
                                                [FromBody][Required] BusinessContactUpdateRequest request)
        {
            return await businessContactService.UpdateContact(contactId, request).ConfigureAwait(false);
        }
    }
}
