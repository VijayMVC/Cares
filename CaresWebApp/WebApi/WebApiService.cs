using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cares.WebApp.Models;
using Cares.WebApp.RequestModels;
using Cares.WebApp.Resources;
using Cares.WebApp.WepApiInterface;

namespace Cares.WebApp.WebApi
{
    /// <summary>
    /// Web Api Service
    /// </summary>
    public sealed class WebApiService : ApiService, IWebApiService
    {
        #region Private
        /// <summary>
        ///Operation Workplace List Uri
        /// </summary>
        private string GetOperationWorkplaceListUri
        {
            get
            {
                return ApiResource.WebApiBaseAddress + ApiResource.GetOperationWorkplace;
            }
        }

        /// <summary>
        ///Hire Group List Uri
        /// </summary>
        private string GetHireGroupListUri
        {
            get
            {
                return ApiResource.WebApiBaseAddress + ApiResource.GetHireGroup;
            }
        }
        private string GetAvailableInsurancesRateUri
        {
            get
            {
                return ApiResource.WebApiBaseAddress + ApiResource.GetAvailableInsuranceRates;
            }
        }
        private string GetAvailableChauffersRatesUri
        {
            get
            {
                return ApiResource.WebApiBaseAddress + ApiResource.GetAvailableChauffersRates;
            }
        }
        private string GetAdditionalDriverChargeUri
        {
            get
            {
                return ApiResource.WebApiBaseAddress + ApiResource.GetAdditionalDriverCharge;
            }
        }

        /// <summary>
        ///Services List Uri
        /// </summary>
        private string GetServicesListUri
        {
            get
            {
                return ApiResource.WebApiBaseAddress + ApiResource.GetServices;
            }
        }

        /// <summary>
        /// Get Operation Workplace List 
        /// </summary>
        private async Task<GetOperationWorkplaceResult> GetOperationWorkplaceListAsync(long domainKey)
        {
            GetOperationWorkplaceRequest request = new GetOperationWorkplaceRequest { DomainKey = domainKey };

            string requestContents = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpResponseMessage responseMessage = await PostHttpRequestAsync(requestContents, new Uri(GetOperationWorkplaceListUri)).ConfigureAwait(false);
            //HttpResponseMessage responseMessage = await GetHttpRequestAsync(new Uri(GetOperationWorkplaceListUri + "?domainKey=" + domainKey));
            if (responseMessage.IsSuccessStatusCode)
            {
                string stringContents = await responseMessage.Content.ReadAsStringAsync();
                return new GetOperationWorkplaceResult
                {
                    OperationWorkplaces = this.CreateResultForOperationWorkplaceListRequest(stringContents)
                };
            }
            {
                string errorString = await responseMessage.Content.ReadAsStringAsync();
                return new GetOperationWorkplaceResult
                {
                    Error = errorString
                };
            }
        }

        /// <summary>
        /// Get Available HireGroup
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<GetHireGroupResult> GetHireGroupAsync(GetHireGroupRequest request)
        {
            string requestContents = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpResponseMessage responseMessage = await PostHttpRequestAsync(requestContents, new Uri(GetHireGroupListUri)).ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string stringContents = await responseMessage.Content.ReadAsStringAsync();
                return new GetHireGroupResult()
                {
                    AvailableHireGroups = this.CreateResultForHireGroupsListRequest(stringContents)
                };

            }
            else
            {
                string errorString = await responseMessage.Content.ReadAsStringAsync();
                return new GetHireGroupResult
                {
                    Error = errorString
                };
            }
        }

        /// <summary>
        /// Get Services
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<GetServicesResult> GetServicesAsync(AvailableServicesRequest request)
        {
            string orderContents = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpResponseMessage responseMessage = await PostHttpRequestAsync(orderContents, new Uri(GetServicesListUri));
            if (responseMessage.IsSuccessStatusCode)
            {
                string stringContents = await responseMessage.Content.ReadAsStringAsync();
                return new GetServicesResult()
                {
                    Insurances = this.CreateResultForServicesListRequest(stringContents)
                    //for service rate ,decide to see result of web service
                };

            }
            else
            {
                string errorString = await responseMessage.Content.ReadAsStringAsync();
                return new GetServicesResult
                {
                    Error = errorString
                };
            }
        }

        /// <summary>
        /// Create Results for Operation Workplace
        /// </summary>
        private IList<WebApiOperationWorkplace> CreateResultForOperationWorkplaceListRequest(string stringContents)
        {
            IList<WebApiOperationWorkplace> results = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WebApiOperationWorkplace>>(stringContents);
            return results;
        }

        /// <summary>
        /// Create Results for Hire Group
        /// </summary>
        private IList<WebApiHireGroup> CreateResultForHireGroupsListRequest(string stringContents)
        {
            IList<WebApiHireGroup> results = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WebApiHireGroup>>(stringContents);
            return results;
        }

        /// <summary>
        /// Create Results for Services
        /// </summary>
        private IList<WebApiInsurance> CreateResultForServicesListRequest(string stringContents)
        {
            IList<WebApiInsurance> results = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WebApiInsurance>>(stringContents);
            return results;
        }
        #endregion

        #region Public


        /// <summary>
        /// Get Operation Workplace List
        /// </summary>
        public GetOperationWorkplaceResult GetOperationWorkplaceList(long domainKey)
        {
            return GetOperationWorkplaceListAsync(domainKey).Result;
        }

        /// <summary>
        /// Get Hire Group List
        /// </summary>
        public GetHireGroupResult GetHireGroupList(GetHireGroupRequest request)
        {
            return GetHireGroupAsync(request).Result;
        }

        /// <summary>
        /// Get Services List
        /// </summary>
        public GetServicesResult GetServicesList(AvailableServicesRequest request)
        {
            return GetServicesAsync(request).Result;
        }

        /// <summary>
        /// Get Available Insurances Rates 
        /// </summary>
        public GetAvailableInsurancesRatesResults GetAvailableInsurancesRates(WebApiRequest webApiRequest)
        {
            return GetInsurancesRatesAsync(webApiRequest).Result;
        }
        private IList<WebApiAvailableInsurancesRates> CreateResultForInsurancesListRequest(string stringContents)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WebApiAvailableInsurancesRates>>(stringContents);
        }
        private async Task<GetAvailableInsurancesRatesResults> GetInsurancesRatesAsync(WebApiRequest request)
        {
            request.DomainKey = 1;
            request.TarrifTypeCode = "D";
            request.StartDateTime = new DateTime(2014, 11, 09);
            string requestContents = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpResponseMessage responseMessage = await PostHttpRequestAsync(requestContents, new Uri(GetAvailableInsurancesRateUri)).ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string stringContents = await responseMessage.Content.ReadAsStringAsync();
                IList<WebApiAvailableInsurancesRates> webApiAvailableInsurancesRateses = CreateResultForInsurancesListRequest(stringContents);
                return new GetAvailableInsurancesRatesResults
                {
                    ApiAvailableInsurances = webApiAvailableInsurancesRateses
                };
            }
            {
                string errorString = await responseMessage.Content.ReadAsStringAsync();
                return new GetAvailableInsurancesRatesResults
                {
                    Error = errorString
                };
            }
        }

       

        /// <summary>
        /// Get Available Chauffers with chrage rates
        /// </summary>
        public GetAvailableCahuffersRatesResults GetAvailableChauffersRates(WebApiRequest webApiRequest)
        {
            return GetChauffersRatesAsync(webApiRequest).Result;
        }
        private async Task<GetAvailableCahuffersRatesResults> GetChauffersRatesAsync(WebApiRequest request)
        {

            string orderContents = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpResponseMessage responseMessage = await PostHttpRequestAsync(orderContents, new Uri(GetAvailableChauffersRatesUri));
            if (responseMessage.IsSuccessStatusCode)
            {
                string stringContents = await responseMessage.Content.ReadAsStringAsync();
                return new GetAvailableCahuffersRatesResults
                {
                    ApiAvailableChuffersRates = CreateResultForChauffersListRequest(stringContents)
                    //for service rate ,decide to see result of web service
                };

            }
            else
            {
                string errorString = await responseMessage.Content.ReadAsStringAsync();
                return new GetAvailableCahuffersRatesResults
                {
                    Error = errorString
                };
            }
        }
        private IList<WebApiAvailableChuffersRates> CreateResultForChauffersListRequest(string stringContents)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WebApiAvailableChuffersRates>>(stringContents);
        }

        /// <summary>
        /// Get Additional Driver Rates
        /// </summary>
        public GetAdditionalDriverRatesResults GetAdditionalDriverRates(WebApiRequest webApiRequest)
        {
            return GetAdditioanalDriverRatesAsync(webApiRequest).Result;
        }
        private async Task<GetAdditionalDriverRatesResults> GetAdditioanalDriverRatesAsync(WebApiRequest request)
        {
            request.TarrifTypeCode = "H";
            request.DomainKey = 1;
            string orderContents = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpResponseMessage responseMessage = await PostHttpRequestAsync(orderContents, new Uri(GetAdditionalDriverChargeUri)).ConfigureAwait(false);
            if (responseMessage.IsSuccessStatusCode)
            {
                string stringContents = await responseMessage.Content.ReadAsStringAsync();
                IList<WebApiAdditionalDriverRates> resultForAdditionalDriverListRequest = CreateResultForAdditionalDriverListRequest(stringContents);
                return new GetAdditionalDriverRatesResults
                {
                    WebApiAdditionalDriverRates = resultForAdditionalDriverListRequest
                };
            }
                string errorString = await responseMessage.Content.ReadAsStringAsync();
                return new GetAdditionalDriverRatesResults
                {
                    Error = errorString
                };
        }
        private IList<WebApiAdditionalDriverRates> CreateResultForAdditionalDriverListRequest(string stringContents)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IList<WebApiAdditionalDriverRates>>(stringContents);
        }

        #endregion
    }
}
