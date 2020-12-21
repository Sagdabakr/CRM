using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DevExpressModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRM.Models;
using Plugin.Messaging;
using Rg.Plugins.Popup.Services;
using CRM.Views.PopupPages;
using CRM.VirtualModels;
using CRM.ViewModels;
using CRM.Services;
using DevExpress.XamarinForms.Editors;

namespace CRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestForm : ContentPage
    {
        RequestService requestService;
        public static Customer_VM CurrentCustomer;
        RequestForm_VM ViewModel;
        Customer_VM SelectedCustomer;
        TypeOfService_VM Selected_TypeOfService;       
        int Status;
        public RequestForm()
        {
            InitializeComponent();
            RequestDate.Date = DateTime.Now;            
            StatusDate.Date = DateTime.Now;
            Request_PreferredDate.MinDate = DateTime.Now;            
            SelectedCustomer = new Customer_VM();
            CurrentCustomer = new Customer_VM();
            ViewModel = new RequestForm_VM();
            requestService = new RequestService();
        }
        protected async override void OnAppearing()
        {
            var   Oid =  Guid.Parse(   Application.Current.Properties["UserGuid"].ToString()  ) ;
            CurrentCustomer =await ViewModel.GetCustomer(Oid);
            StatusComboBox.ItemsSource = Enum.GetNames(typeof(Helper.Status)).ToList();            
            StatusComboBox.SelectedItem = Helper.Status.Open.ToString();
            ViewModel.Customers =await ViewModel.GetCustomers((Guid)CurrentCustomer.Company);
            ViewModel.TypeOfServices = await ViewModel.GetTypeOfServices(CurrentCustomer.Oid);
            CustomerCombobox.ItemsSource = ViewModel.Customers;
            TypeOfServiceComboBox.ItemsSource = ViewModel.TypeOfServices;
            RequestNumber.Text = await ViewModel.GetRequestNumber();
            BindingContext = ViewModel;
        }

        private void ContactUs_Clicked(object sender, EventArgs e)
        {
          var PhoneTask =   CrossMessaging.Current.PhoneDialer;
            if(PhoneTask.CanMakePhoneCall)
            {
                PhoneTask.MakePhoneCall("01147265553","Sagda Bakr");
            }
        }

        private async void CustomerDetailsTapped(object sender, EventArgs e)
        {
            if(SelectedCustomer != null )
            {                
                await PopupNavigation.Instance.PushAsync(new CustomerDetails(SelectedCustomer.Oid));
            }            
        }

        private void OnNewCustomerSelected(object sender, EventArgs e)
        {
            SelectedCustomer = ((sender as ComboBoxEdit).SelectedItem) as Customer_VM;
            if(SelectedCustomer !=null )
                CustomerDetails.IsVisible = true;
        }

        private async void SubmitPressed(object sender, EventArgs e)
        {
            if(SelectedCustomer.Oid == null || Request_PreferredDate.Date == null || Request_PreferredTime.Time == null ||Selected_TypeOfService.Oid == null)
            {
                await DisplayAlert("", "Fill All Required Fields First", "Cancel");
            }
            else
            {
                Request NewRequest = new Request()
                {
                    RequestedByCustomer = SelectedCustomer.Oid,
                    PreferredDate = Request_PreferredDate.Date,
                    PrefferedTime = Request_PreferredTime.Time,
                    CreatedByCustomer = CurrentCustomer.Oid,
                    RequestNumber = RequestNumber.Text,
                    RequestDateTime = RequestDate.Date,
                    Description = Request_Description.Text,
                    TypeOfService = Selected_TypeOfService.Oid,
                    StatusDateTime = StatusDate.Date
                };
                CustomerCombobox.SelectedIndex = -1;
                TypeOfServiceComboBox.SelectedIndex = -1;
                Request_Description.Text = string.Empty;                
                Request_PreferredDate.Date = null;                
                 Request_PreferredTime.Time = null;               

                var x = await requestService.SubmitRequest(NewRequest);
                if (x != null)
                {
                    await DisplayAlert("", "Request Submitted", "Cancel");
                }
                else
                {
                    await DisplayAlert("Error", "Enter Valid Data", "Cancel");
                }

                RequestNumber.Text = await ViewModel.GetRequestNumber();
                RequestDate.Date = DateTime.Now;
                StatusDate.Date = DateTime.Now;
            }
     
        }

        private async void HistoryPressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryRequests(CurrentCustomer));
        }

        private void OnTypeOfServiceChanged(object sender, EventArgs e)
        {
           Selected_TypeOfService = ((sender as ComboBoxEdit).SelectedItem) as TypeOfService_VM;           
        }

        private void OnStatusChanged(object sender, EventArgs e)
        {
            var  SelectedStatus = (sender as ComboBoxEdit).SelectedItem as string;
            Helper.Status color = (Helper.Status)System.Enum.Parse(typeof(Helper.Status), SelectedStatus);
            Status = (int)color;
        }

    }
}