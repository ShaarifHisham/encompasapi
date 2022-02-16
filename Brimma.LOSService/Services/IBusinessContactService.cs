using Brimma.LOSService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brimma.LOSService.Services
{
    public interface IBusinessContactService
    {
        /// <summary>
        /// Retrive Business Contacts
        /// </summary>
        /// <param name="request">BusinessContactRequest</param>
        /// <param name="start">Start Index</param>
        /// <param name="limit">Maximum Records</param>
        /// <returns>List of Business Contacts</returns>
        Task<Object> GetBusinessContacts(Object request, int start, int limit);
    }
}
