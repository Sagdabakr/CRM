using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRM.Services;
using CRM.VirtualModels;
namespace CRM.ViewModels
{
    public  class RequestForm_VM : BaseViewModel
    {
        CustomerService CustomerService;
        RequestService RequestService;
        public List<Customer_VM> Customers
        {
            get { return _Customers; }
            set { SetProperty(ref _Customers, value); }
        }

        private List<Customer_VM> _Customers;
        
        public List<TypeOfService_VM> TypeOfServices
        {
            get { return _typeOfServices; }
            set { SetProperty(ref _typeOfServices, value); }
        }

        private List<TypeOfService_VM> _typeOfServices;

        public RequestForm_VM()
        {
            Customers = new List<Customer_VM>();
            _Customers = new List<Customer_VM>();
            TypeOfServices = new List<TypeOfService_VM>();
            _typeOfServices = new List<TypeOfService_VM>();
            CustomerService = new CustomerService();
            RequestService = new RequestService();
        }

        public async Task<List<Customer_VM>> GetCustomers(Guid CompanyID)
        {
            var allcustomers = await CustomerService.GetAllCustomers(CompanyID);
            return allcustomers;
        }
        
        public async Task<Customer_VM> GetCustomer(Guid CustomerOid)
        {
            var _Customer = await CustomerService.GetCustomer(CustomerOid);
            return _Customer;
        }
        
        public async Task<string> GetRequestNumber()
        {
            var RequestNumber = await RequestService.GetRequestNumber();
            return RequestNumber;
        }
        
        public async Task<List<TypeOfService_VM>> GetTypeOfServices(Guid CustomerOid)
        {
            var RequestNumber = await RequestService.GetTypeOfService(CustomerOid);
            return RequestNumber;
        }
    }
}
