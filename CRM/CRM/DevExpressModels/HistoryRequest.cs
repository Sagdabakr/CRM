using System;
using System.Collections.Generic;
using System.Text;
using CRM.Models;
namespace CRM.DevExpressModels
{
    public class HistoryRequest
    {

        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string TypeOfService { get; set; }
    }
}
