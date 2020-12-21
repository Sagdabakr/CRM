using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CRM.Models;
using CRM.VirtualModels;
using CRM.DevExpressModels;
using CRM.Services;
using System.Threading.Tasks;
using System.Windows;
namespace CRM.ViewModels
{
    public class HistoryRequests_VM : BaseViewModel
    {
        public ObservableCollection<HistoryRequest> AllRequests { get; set; }
        public List<Request_VM> Requests
        {
            get { return _requests; }
            set { SetProperty(ref _requests, value); }
        }

        private List<Request_VM> _requests;
        RequestService RequestService;
        public HistoryRequests_VM()
        {
            AllRequests = new ObservableCollection<HistoryRequest>();
            Requests = new List<Request_VM>();
            _requests = new List<Request_VM>();
            RequestService = new RequestService();
        }
        public async Task<List<Request_VM>> GetHistoryRequests(Guid CustomerID)
        {
            var allRequests = await RequestService.GetRequestHistory(CustomerID);
            foreach(Request_VM Req in allRequests)
            {
                if (Req.Status >= 1 && Req.Status <= 3 || Req.Status ==8 || Req.Status ==5)
                    Req.StatusValue = ((Helper.Status)Req.Status).ToString();
                else
                    Req.StatusValue = "Pending ..";
            }
            return allRequests;
        }
    }
}
