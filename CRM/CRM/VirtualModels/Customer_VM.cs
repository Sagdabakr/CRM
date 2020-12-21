using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.VirtualModels
{
    public class Customer_VM
    {
        public string EnglishCustomerName { get; set; }
        public string ArabicCustomerName { get; set; }
        public string UserName { get; set; }
        public Guid Oid { get; set; }
        public string Password { get; set; }
        public Guid? Company { get; set; }

        //Customer's Details       
        public string Email { set; get; }
        public string Mobile { set; get; }
        public string Fax { set; get; }
        public string Facebook { set; get; }
        public string FixedPhone { set; get; }
        public string WhatsApp { set; get; }
        public string CompanyBranch { set; get; }

    }
}
