using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public  class CompanyBranch
    {
        public Guid Oid { get; set; }
       
        public string BranchCode { get; set; }

        public Guid? Company { get; set; }
       
        public string EnglishBranchName { get; set; }
      
        public string ArabicBranchName { get; set; }

        public Guid? Country { get; set; }

        public Guid? City { get; set; }
      
        public string PostalCode { get; set; }

        public bool? HeadQuarter { get; set; }

    
        public string MapLatitude { get; set; }

    
        public string MapLongitude { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }
      
        public virtual Company Company1 { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

     
    }
}
