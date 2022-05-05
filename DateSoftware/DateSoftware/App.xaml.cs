using DateSoftware.Services;
using DateSoftware.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DateSoftware
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
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
