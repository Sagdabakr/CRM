using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Models
{
   public class Helper
    {
        public enum Status
        {
            Open = 1,
            InProgressing = 2,
            Completed = 5,
            WaitingApproval = 8,
            Closed = 3
        }
        public enum Language
        {
            Arabic,
            English
        }
    }
}
