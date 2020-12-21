using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Models;
namespace CRM.VirtualModels
{
    public class Request_VM  
    {
        public String RequestNumber { get; set; }
        public string TypeOfService { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string RequestDescription { get; set; }
        public string WorkOrderNumber { get; set; }
        public int Status { get; set; }
        public string StatusValue { get; set; }
       
    }
}
