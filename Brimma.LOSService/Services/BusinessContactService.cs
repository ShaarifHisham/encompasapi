using Brimma.LOSService.Config;
using Brimma.LOSService.DTO;
using Microsoft.AspNetCore.Mvc;
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
        public BusinessContactService(IHttpService httpService, IOptions<EncompassAPIs> config)
        {
            this.httpService = httpService;
            encompassAPIs = config.Value;
        }
        public async Task<Object> GetBusinessContacts(Object request, int start, int limit)
        {
            Object response = new Object();
            string apiURL = string.Empty;

                if (request != null)
                {
                    apiURL = string.Format(encompassAPIs.RetrieveBusinessContacts,start,limit);
                }
                ApiResponse<HashSet<BusinessContactResponse>> apiResponse = await httpService.PostAsync<HashSet<BusinessContactResponse>>(apiURL, request).ConfigureAwait(false);               
                if (apiResponse.Success)
                {
                    return apiResponse;
                }
                else if (apiResponse.ErrorResponse != null && apiResponse.ErrorResponse.Error != null)
                {
                    return StatusCode(apiResponse.ErrorResponse.Error.Code, apiResponse.ErrorResponse);
                }
            return response;
        }
    }
}
