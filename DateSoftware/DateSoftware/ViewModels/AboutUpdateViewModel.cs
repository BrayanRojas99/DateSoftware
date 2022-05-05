using DateSoftware.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DateSoftware.ViewModels
{
    public class AboutUpdateViewModel: BaseViewModel
    {
        public User MyUser { get; set; }

        public AboutUpdateViewModel()
        {
            MyUser = new User();
        }


        //create the method to consume
        //todo consumir en la vista
        public async Task<bool> UpdateUser(int UserId,
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

                //complete all information

                MyUser.UserId = UserId;
                MyUser.Id = Id;
                MyUser.FullName = FullName;
                MyUser.PhoneNumber = PhoneNuber;
                MyUser.Email = Email;

                MyUser.UserRoleId = UserRoleId;

                //call the method
                bool R = await MyUser.UpdateUser();

                return R;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
            finally { IsBusy = false; }

        }
    }
}
