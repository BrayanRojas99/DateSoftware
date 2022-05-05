using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DateSoftware.ViewModels;
using DateSoftware.Models;

namespace DateSoftware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        UserRolViewModel VmUR;
        UserViewModel VmU;
        UserRol MyRol;

        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = VmUR = new UserRolViewModel();
            this.BindingContext = VmU = new UserViewModel();
            MyRol = new UserRol();
            LoadRoles();
        }

        #region loadRoles
        private async void LoadRoles()
        {
            CboUserRol.ItemsSource = await VmUR.LoadRoles();
        }

        #endregion

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            MyRol = new UserRol();
            MyRol = (UserRol)CboUserRol.SelectedItem;

            int IdRol = MyRol.UserRoleId;

            bool R = await VmU.AddUser(TxtId.Text.Trim(),
                                        TxtFullName.Text.Trim(),
                                        TxtPhoneNumber.Text.Trim(),
                                        TxtEmail.Text.Trim(),
                                        TxtPassword.Text.Trim(),
                                        IdRol);
            if (R == true)
            {
                await DisplayAlert("!!!", "The user was added", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(","Something went wrong!","OK");
            }
        }

        private void SwSeePassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled == false)
            {
                TxtPassword.IsPassword = true;
            }
            else
            {
                TxtPassword.IsPassword = false; 
            }
        }
    }
}