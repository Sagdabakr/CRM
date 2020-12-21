using System;
using System.Collections.Generic;
using System.Text;
using CRM.Models;
using CRM.VirtualModels;
using CRM.Services;
using System.Threading.Tasks;

namespace CRM.ViewModels
{
    public class CustomerDetails_VM : BaseViewModel
    {
        CustomerService customerService;
        public CustomerInfo CustomerInfo
        {
            get { return _CustomerInfo; }
            set { SetProperty(ref _CustomerInfo, value); }
        }

        private CustomerInfo _CustomerInfo;

        public CustomerDetails_VM()
        {
            customerService = new CustomerService();
            CustomerInfo = new CustomerInfo();
            _CustomerInfo = new CustomerInfo();
        }

        public async Task<CustomerInfo> GetCustomerInfo (Guid CustomerOid)
        {
            var Customerinfo = await customerService.GetCustomerInfo(CustomerOid);
            return Customerinfo;
        }
    }
}
