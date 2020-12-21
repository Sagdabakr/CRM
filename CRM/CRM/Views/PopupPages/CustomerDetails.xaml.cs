using CRM.DevExpressModels;
using CRM.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.ViewModels;
using CRM.VirtualModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevExpress.XamarinForms.DataForm;

namespace CRM.Views.PopupPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetails : PopupPage
    {
        CustomerDetails_VM ViewModel;
        CustomerInfo _Customer;
        Guid CutomerOid;
        public CustomerDetails(Guid CustomerOid)
        {
            InitializeComponent();
            ViewModel = new CustomerDetails_VM();
            _Customer = new CustomerInfo();
            CutomerOid = CustomerOid;
        }
        protected async override void OnAppearing()
        {
            ViewModel.CustomerInfo = await ViewModel.GetCustomerInfo(CutomerOid);
            _Customer = ViewModel.CustomerInfo;

            Button _Button = new Button()
            {
                Text = "Cancel",
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.End,
                TextColor = Color.White,
                Margin = new Thickness(10, 4),

            };
            _Button.Clicked += async (sender, EventArgs) => await CancelClicked(sender, EventArgs);
            DataFormView _dataForm = new DataFormView()
            {
                DataObject = _Customer,
                Margin = 25,
                EditorLabelColor = Color.Black,
                IsEnabled = false,
                EditorLabelFontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                EditorLabelPosition = DataFormLabelPosition.Top,
                EditorLabelFontAttributes = FontAttributes.Bold
            };
            ScrollView _ScrollView = new ScrollView()
            {
                Content = _dataForm,
            };
            StackLayout ContainerStack = new StackLayout()
            {
                Children = { _ScrollView, _Button }
            };
            Frame _Frame = new Frame()
            {
                Content = ContainerStack ,
                Margin = 20 ,
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.Center ,
                Padding = 0 ,
                CornerRadius = 12
            };
            Content = _Frame;
            BindingContext = ViewModel;
        }
        private async Task CancelClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}