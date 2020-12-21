using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class Customer
    {
        public Guid Oid { get; set; }
         
        public string CodeCustomer { get; set; }

        public bool? HasPrimaryMobile { get; set; }

        public bool? HasPrimaryEmail { get; set; }

        public bool? HasPrimaryFixedPhone { get; set; }

        public bool? HasPrimaryFax { get; set; }

  
        public string ArabicCustomerName { get; set; }
 
        public string EnglishCustomerName { get; set; }

        public Guid? Company { get; set; }

        public Guid? Branch { get; set; }

        public byte[] Photo { get; set; }

        public virtual Company Company1 { get; set; }

        public virtual CompanyBranch CompanyBranch { get; set; }

        public virtual PermissionPolicyUser PermissionPolicyUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email> Emails { get; set; }         

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests1 { get; set; }
 
    }
}
