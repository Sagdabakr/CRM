using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRM.Models;
using CRM.VirtualModels;
namespace CRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryRequests : ContentPage
    {
        HistoryRequests_VM ViewModel;
        Customer_VM CurrentCustomer;
        public HistoryRequests(Customer_VM _currentCustomer)
        {
            InitializeComponent();
            ViewModel = new HistoryRequests_VM();
            CurrentCustomer = _currentCustomer;        
        }
        protected async override void OnAppearing()
        {
            ViewModel.Requests =  await ViewModel.GetHistoryRequests(CurrentCustomer.Oid);
            if(ViewModel.Requests == null || ViewModel.Requests.Count ==0)
            {
                await DisplayAlert("Sorry " , "No Data to show" , "Cancel");
            }
            else
            {
                HistoryRequestGrid.ItemsSource = ViewModel.Requests;
            }            
            
            BindingContext = ViewModel;
        }
        private async void BackTapped(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new RequestForm());
        }
    }
}