using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class Request
    {
       
        public Guid Oid { get; set; }
  
        public string RequestNumber { get; set; }

        public DateTime? RequestDateTime { get; set; }

        public Guid? RequestedByCustomer { get; set; }

        public Guid? CreatedByCustomer { get; set; }

        public Guid? TypeOfService { get; set; }

        public int? LastNumberServices { get; set; }

        public DateTime? StatusDateTime { get; set; }

        public DateTime? PreferredDate { get; set; }

        public DateTime? PrefferedTime { get; set; }

        public DateTime? ActualDate { get; set; }

        public DateTime? ActualTime { get; set; }

        public string Description { get; set; }

        public Guid? WorkOrder { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Customer Customer1 { get; set; }

        public virtual TypeOfService TypeOfService1 { get; set; }

       public virtual WorkOrder WorkOrder1 { get; set; }

    }
}
