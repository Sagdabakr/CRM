using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class RequestAttachment
    {
        public Guid Oid { get; set; }

        public Guid? Request { get; set; }

        public byte[] RequestFile { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        public virtual Request Request1 { get; set; }
    }
}
