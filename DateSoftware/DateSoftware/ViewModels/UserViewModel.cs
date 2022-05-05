using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DateSoftware.Models;
using DateSoftware.Tools;

namespace DateSoftware.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        public User MyUser { get; set; }
        public Crypto MyCrypto { get; set; }
        public UserViewModel()
        {
            MyUser = new User();
            MyCrypto = new Crypto();
        }

        #region ValidateUserLogin
        public async Task<bool> ValidateUserLogin(string pEmail, string pPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                //encrypt the password
                string EncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

                this.MyUser.Password = EncriptedPassword;
                this.MyUser.Email = pEmail;

                bool R = await MyUser.ValidateUserLogin();
                return R;
            }
            catch (Exception)
            {

                return false;
            }
            finally { IsBusy = false; }
            
        }
        #endregion

        #region Update new user
        public async Task<bool> UpdateUser(int IdUser,
                                        string Id,
                                        string FullName,
                                        string PhoneNuber,
                                        string Email,
                                        int UserRoleId)
        {
            if (IsBusy == true) return false;
            IsBusy = true;
            try
            {
                MyUser = new User();

                MyUser.UserId = IdUser;
                MyUser.Id = Id;
                MyUser.FullName = FullName;
                MyUser.PhoneNumber = PhoneNuber;
                MyUser.Email = Email;
                MyUser.UserRole.UserRoleId = UserRoleId;

                bool R = await MyUser.UpdateUser();

                return R;
            }
            catch (Exception)
            {

                return false;
            }
            finally { IsBusy = false; }
        }
        #endregion

        #region Add new User
        public async Task<bool> AddUser(string Id,
                                        string FullName,
                                        string PhoneNuber,
                                        string Email,
                                        string Password,
                                        int UserRoleId)
        {
            if (IsBusy == true) return false;
            IsBusy = true;

            try
            {
                MyUser = new User();

                //complete all information

                MyUser.Id = Id;
                MyUser.FullName = FullName;
                MyUser.PhoneNumber = PhoneNuber;
                MyUser.Email = Email;

                //encrypt the password
                string EncryptedPassword = MyCrypto.EncriptarEnUnSentido(Password);
                MyUser.Password = EncryptedPassword;

                MyUser.UserRoleId = UserRoleId;

                //call the method
                bool R = await MyUser.AddUser();

                return R;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally { IsBusy = false; }
        }
        #endregion

    }
}
