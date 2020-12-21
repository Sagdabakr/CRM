using CRM.DevExpressModels;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRM.VirtualModels;
using CRM.ViewModels;
namespace CRM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginForm : ContentPage
    {
        LoginForm_VM ViewModel;
        public LoginForm()
        {
            InitializeComponent();
            ViewModel = new LoginForm_VM();
            SelectedLang.ItemsSource = Enum.GetNames(typeof(Helper.Language)).ToList();
            SelectedLang.SelectedItem = Helper.Language.Arabic.ToString();
        }

        private async void OnLoginPressed(object sender, EventArgs e)
        {            
            Customer_VM customer = new Customer_VM()
            {
                UserName = UserName.Text,
                Password = "",
            };
            var userData = await ViewModel.Login(customer);  
            
            if(userData == null )
            {
                await DisplayAlert("", "Please Enter valid username and password", "Cancel");
            }
            else
            {
                Application.Current.Properties["UserGuid"] = userData.Oid.ToString();
                Application.Current.Properties["IsLoggedIn"] = "True";
                await Navigation.PushAsync(new RequestForm());
            }
        }
 
    }
}