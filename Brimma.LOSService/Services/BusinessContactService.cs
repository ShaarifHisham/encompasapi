using Brimma.LOSService.Common;
using Brimma.LOSService.Config;
using Brimma.LOSService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brimma.LOSService.Services
{
    public class BusinessContactService : ControllerBase, IBusinessContactService
    {
        private readonly IHttpService httpService;
        private readonly EncompassAPIs encompassAPIs;
        private readonly ILogger<BusinessContactService> logger;
        public BusinessContactService(IHttpService httpService, IOptions<EncompassAPIs> config, ILogger<BusinessContactService> logger)
        {
            this.httpService = httpService;
            encompassAPIs = config.Value;
            this.logger = logger;
        }
        public async Task<Object> GetBusinessContacts(Object request, int start, int limit)
        {
            Object response = new Object();
            string apiURL = string.Empty;

            try
            {
                if (request != null)
                {
                    apiURL = string.Format(encompassAPIs.RetrieveBusinessContacts, start, limit);
                }
                ApiResponse<HashSet<BusinessContactResponse>> apiResponse = await httpService.PostAsync<HashSet<BusinessContactResponse>>(apiURL, request).ConfigureAwait(false);
                if (apiResponse.Success)
                {
                    HashSet<BusinessContactResponse> businessContacts = apiResponse.Data;
                    return businessContacts;
                }
                else if (apiResponse.ErrorResponse != null && apiResponse.ErrorResponse.Error != null)
                {
                    logger.LogError(string.Format("Error occured at GetBusinessContacts. Error Response= {0};", apiResponse.ErrorResponse));
                    return StatusCode(apiResponse.ErrorResponse.Error.Code, apiResponse.ErrorResponse);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Error Occued at GetBusinessContacts. Error Message= {0}; Stack Trace={1}", ex.Message, ex.StackTrace));
                return StatusCode(500, ErrorHandling.GetErrorResponse(500, string.Format("Error Occued at GetBusinessContacts. Error Message= {0}; Stack Trace={1}", ex.Message, ex.StackTrace)));
            }
            return response;
        }
        public async Task<Object> UpdateContact(string contactId, BusinessContactUpdateRequest request)
        {
            Object response = new Object();
            string apiURL = string.Empty;

            try
            {
                if (request != null)
                {
                    apiURL = string.Format(encompassAPIs.UpdateBusinessContact, contactId);
                }
                ApiResponse<Object> apiResponse = await httpService.PatchAsync<Object>(apiURL, request).ConfigureAwait(false);
                if (apiResponse.Success)
                {
                    return NoContent();
                }
                else if (apiResponse.ErrorResponse != null && apiResponse.ErrorResponse.Error != null)
                {
                    logger.LogError(apiResponse.ErrorResponse.Error.Message);
                    return StatusCode(apiResponse.ErrorResponse.Error.Code, apiResponse.ErrorResponse);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(string.Format("Error Occued at UpdateContact. Error Message= {0}; Stack Trace={1}", ex.Message, ex.StackTrace));
            }
            return response;
        }
    }
}
