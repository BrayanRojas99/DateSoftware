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
    public partial class GeneralInformationPage : ContentPage
    {
        public GeneralInformationPage()
        {
            InitializeComponent();
            LoadUserInformation();
        }


        public void LoadUserInformation()
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

        private async void BtnUpdateUserInformation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutUpdatePage()); 
        }
    }
}