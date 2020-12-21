using DevExpress.XamarinForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Views
{
    public enum Status
    {
        Open,
        InProcessing,
        Completed,
        WaitingApproval,
        Closed
    }
    public class RequestInfo
    {
        [DataFormNumericEditor]
        public int RequsestNumber { get; set; }

        public DateTime RequsestDate { get; set; }
        
        public Status Status { get; set; }

        [DataFormDateEditor]
        public DateTime StatusDate { get; set; }

        [DataFormDateEditor]
        public DateTime PreferredDate { get; set; }

       [DataFormTimeEditor]
        public TimeSpan PreferredTime { get; set; }

        [DataFormMultilineEditor]
        public string RequestDescription { get; set; }
    }
}
