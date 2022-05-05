using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DateSoftware.Models;

namespace DateSoftware.ViewModels
{
    public class UserRolViewModel: BaseViewModel
    {
        public UserRol MyUserRol { get; set; }
        public UserRolViewModel()
        {
            MyUserRol = new UserRol();
        }

        #region LoadRol
        public async Task<List<UserRol>> LoadRoles()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
               List<UserRol> RolesList = new List<UserRol>();

                RolesList = await MyUserRol.LoadRoles();

                if (RolesList != null)
                {
                    return RolesList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { IsBusy = false; }
        }
        #endregion
    }
}
