using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class Email
    {
        public Guid Oid { get; set; }
        
        public string EmailAddress { get; set; }

        public bool? IsPrimary { get; set; }

        public Guid? Customer { get; set; }

        public Guid? ManPower { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        public virtual Customer Customer1 { get; set; }
    }
}
