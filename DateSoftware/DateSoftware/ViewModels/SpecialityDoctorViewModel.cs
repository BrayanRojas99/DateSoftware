using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DateSoftware.Models;

namespace DateSoftware.ViewModels
{

    public class SpecialityDoctorViewModel : BaseViewModel
    {
        SpecialityDoctor specialityDoctor { get; set; }
        public SpecialityDoctorViewModel()
        {
            specialityDoctor = new SpecialityDoctor();
        }

        #region Add new speciality
        public async Task<bool> AddSpeciality(string Description)
        {
            if (IsBusy == true) return false;
            IsBusy = true;

            try
            {
                specialityDoctor = new SpecialityDoctor();

                //complete all information

                specialityDoctor.Description = Description;

                //call the method
                bool R = await specialityDoctor.AddSpeciality();

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
