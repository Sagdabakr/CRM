using CRM.Models;
using CRM.VirtualModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Services
{
   
    public class CustomerService
    {
        readonly HttpClient client;
        public CustomerService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri($"{App.ServiceURL}")
            };
        }
        string api = App.ServiceURL + "api/";

        public async Task<List<Customer_VM>> GetAllCustomers(Guid CompanyID)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api  + "{0}{1}", "Companies/GetCustomersInSameCompany?CompanyID=", CompanyID);

            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            List<Customer_VM> user =
                JsonConvert.DeserializeObject<List<Customer_VM>>(ResponseMessage);
            return user;
        }
        
        public async Task<Customer_VM> Login(Customer_VM _customer)
        {
            var serializedUser = JsonConvert.SerializeObject(_customer);
            var content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/policyusers/customerlogin", content);
            var result = await response.Content.ReadAsStringAsync();
            var User = await Task.Run(() => JsonConvert.DeserializeObject<Customer_VM>(result));
            return User;
        }

        public async Task<CustomerInfo> GetCustomerInfo(Guid CustomerOid)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Customers/getcustomerinformation?customerOid=", CustomerOid);

            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            CustomerInfo CustomerInfo =
                JsonConvert.DeserializeObject<CustomerInfo>(ResponseMessage);
            return CustomerInfo;
        }
        public async Task<Customer_VM> GetCustomer(Guid CustomerOid)
        {
            var httpClient = new HttpClient();
            var URL = string.Format(api + "{0}{1}", "Customers/getcustomer?customerOid=", CustomerOid);

            var ResponseMessage = await httpClient.GetStringAsync(URL);
            ResponseMessage = ResponseMessage.Replace("\\", "");

            Customer_VM CustomerInfo =
                JsonConvert.DeserializeObject<Customer_VM>(ResponseMessage);
            return CustomerInfo;
        }

    }
}
