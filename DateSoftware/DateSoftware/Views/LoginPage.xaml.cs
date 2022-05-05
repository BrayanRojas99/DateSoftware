using DateSoftware.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        UserViewModel VmU;
        UserRolViewModel VmUR;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = VmU = new UserViewModel();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (this.TxtEmail.Text.Trim() != string.Empty && this.TxtPassword.Text.Trim() != string.Empty)
                {
                    bool R = await VmU.ValidateUserLogin(TxtEmail.Text.Trim(), TxtPassword.Text.Trim());
                    if (R)
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Login", "Something was wrong, try again", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Incomplete Information", "Please review the spaces", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Incomplete Information", "Please review the spaces", "OK");
            }
            
        }





        private void SwSeePassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}