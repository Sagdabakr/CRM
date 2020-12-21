using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class Company
    {
        public Guid Oid { get; set; }
       
        public string CompanyCode { get; set; }
         
        public string ArabicCompanyName { get; set; }
 
        public string EnglishCompanyName { get; set; }
 
        public string Website { get; set; }

        public byte[] Logo { get; set; }

        public bool? HasHeadQuarter { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contracts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
