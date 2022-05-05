using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DateSoftware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        

        private async void BtnAbout_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new GeneralInformationPage());
        }

        private async void BtnDoctors_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;
            await App.MasterDet.Detail.Navigation.PushAsync(new DoctorsPage());
        }
    }
}