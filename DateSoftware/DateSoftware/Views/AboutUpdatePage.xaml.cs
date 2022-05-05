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
    public partial class AboutUpdatePage : ContentPage
    {
        ViewModels.AboutUpdateViewModel Vm;
        public AboutUpdatePage()
        {
            InitializeComponent();
            this.BindingContext = Vm = new ViewModels.AboutUpdateViewModel();
            LoadInitial();
        }

        private async void BtnUpdateUserInformation_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool R = await Vm.UpdateUser(CnnToAPI.GlobalUser.UserId, TxtId.Text.Trim(),TxtFullName.Text.Trim(),TxtPhoneNumber.Text.Trim(),TxtEmail.Text.Trim(),CnnToAPI.GlobalUser.UserRoleId);
                if (R)
                {
                    await DisplayAlert("Update", "User Information was Updated", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Update", "Something was wrong, try again", "OK");
                }
                
            }
            catch (Exception ex)
            {

                await DisplayAlert("Update", "Something was wrong, try again", "OK");
                await Navigation.PopAsync();
            }
            
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //initial load
        private void LoadInitial()
        {
            TxtId.Text = CnnToAPI.GlobalUser.Id;
            TxtFullName.Text = CnnToAPI.GlobalUser.FullName;
            TxtPhoneNumber.Text = CnnToAPI.GlobalUser.PhoneNumber;
            TxtEmail.Text = CnnToAPI.GlobalUser.Email;
            if (CnnToAPI.GlobalUser.UserRoleId == 1)
            {
                TxtRole.Text = "DOCTOR";
            }
            else
            {
                TxtRole.Text = "PATIENT";
            }

        }
    }
}