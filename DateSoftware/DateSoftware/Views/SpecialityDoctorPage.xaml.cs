using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DateSoftware.ViewModels;

namespace DateSoftware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpecialityDoctorPage : ContentPage
    {
        SpecialityDoctorViewModel Vm;
        public SpecialityDoctorPage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new SpecialityDoctorViewModel();
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAddSpeciality_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool R = await Vm.AddSpeciality(TxtDescription.Text.Trim());
                if (R)
                {
                    await DisplayAlert("ADD", "Specialty of the Doctor was ADDED", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("ADD", "Something was wrong, try again", "OK");
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Update", "Something was wrong, try again", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}