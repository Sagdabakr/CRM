using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class Contract
    {
        public Guid Oid { get; set; }
 
        public string ContractNumber { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? Company { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        public virtual Company Company1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractService> ContractServices { get; set; }
         
    }
}
