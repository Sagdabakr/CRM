using System;
using System.Collections.Generic;
using System.Text;
using CRM.VirtualModels;
using CRM.Services;
using System.Threading.Tasks;

namespace CRM.ViewModels
{
    public class LoginForm_VM :BaseViewModel
    {
        CustomerService CustomerService;
        public Customer_VM User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private Customer_VM _user;

        public LoginForm_VM()
        {
            User = new Customer_VM();
            _user = new Customer_VM();
            CustomerService = new CustomerService();
        }

        public async Task<Customer_VM> Login(Customer_VM _customer)
        {                        
            var _Customer = await CustomerService.Login(_customer);
            return _Customer;
        }
    }
}
