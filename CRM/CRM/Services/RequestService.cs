using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CRM.VirtualModels;
using CRM.Models;
namespace CRM.Services
{
    public  class RequestService
    {
        readonly HttpClient client;
        public RequestService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri($"{App.ServiceURL}")
            };
        }
        string api = App.ServiceURL + "api/";

        public async Task<string> GetRequestNumber()
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "requests/getrequestnumber");

            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            string RequestNumber =
                JsonConvert.DeserializeObject<string>(ResponseMessage);
            return RequestNumber;
        }
        
        public async Task<List<Request_VM>> GetRequestHistory(Guid CustomerGuid)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}","/requests/GetCustomerRequests?CustomerGuid=",CustomerGuid);

            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            List<Request_VM> RequestNumber =
                JsonConvert.DeserializeObject<List<Request_VM>>(ResponseMessage);
            return RequestNumber;
        }
        
        public async Task<List<TypeOfService_VM>> GetTypeOfService(Guid CustomerOid)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Typeofservices/gettypeofservices?customerOid=", CustomerOid);

            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            List<TypeOfService_VM> TypeOfServices =
                JsonConvert.DeserializeObject<List<TypeOfService_VM>>(ResponseMessage);
            return TypeOfServices;
        }

        public async Task<Request_VM> SubmitRequest(Request NewRequest)
        {
            var serializedUser = JsonConvert.SerializeObject(NewRequest);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/requests/Submitrequest", content);
            var result = await response.Content.ReadAsStringAsync();
            var _NewRequest = await Task.Run(() => JsonConvert.DeserializeObject<Request_VM>(result));
            return _NewRequest;
        }
    }
}
