using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
    public class PermissionPolicyUser
    {
        public Guid Oid { get; set; }

        public string StoredPassword { get; set; }

        public bool? ChangePasswordOnFirstLogon { get; set; }
     
        public string UserName { get; set; }

        public bool? IsActive { get; set; }

        public int? OptimisticLockField { get; set; }

        public int? GCRecord { get; set; }

        public int? ObjectType { get; set; }

        public virtual Customer Customer { get; set; }      

    //    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
