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
    public partial class DoctorsPage : ContentPage
    {
        public DoctorsPage()
        {
            InitializeComponent();
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAddDoctor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoctorAddPage());
        }
    }
}