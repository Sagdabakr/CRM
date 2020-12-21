using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class ContractService
    {
        public Guid Oid { get; set; }

        public Guid? TypeOfService { get; set; }

        public int? NumberOfService { get; set; }

        public Guid? Contract { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        public virtual Contract Contract1 { get; set; }

        public virtual TypeOfService TypeOfService1 { get; set; }
    }
}
