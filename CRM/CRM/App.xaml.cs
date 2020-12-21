using CRM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRM
{
    public partial class App : Application
    {
        public static string ServiceURL = "http://sagdaomar-001-site1.itempurl.com/";
        public App()
        {
            InitializeComponent();
            Application.Current.Properties["UserGuid"] = "0";
            Application.Current.Properties["IsLoggedIn"] = "False";
            var CurrentUser = Application.Current.Properties["IsLoggedIn"].ToString();
            if(CurrentUser == "False")
            {
                Application.Current.Properties["UserGuid"] = "0";
            }
            MainPage = new NavigationPage(new LoginForm());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
