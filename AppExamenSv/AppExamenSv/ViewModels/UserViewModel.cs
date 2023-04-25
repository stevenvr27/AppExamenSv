using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppExamenSv.Models;

namespace AppExamenSv.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }
        public UserStatus MyStatus { get; set; }

        public User MyUser { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public Ask Myask { get; set; }

        public UserViewModel()
        {
            MyStatus = new UserStatus();
            MyUserRole = new UserRole();
            MyUser = new User();
            MyUserDTO = new UserDTO();
            Myask = new Ask();
        }
        public async Task<UserDTO> GetUserData(string pUsername)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
          UserDTO user = new UserDTO();
                 user = await MyUserDTO.GetUserData(pUsername);

                if (user==null)
                {
                    return null;
                }
                return user;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }
        public async Task<bool>UserAccessValidation(string pUserName,string pPassword)
        {
            if(IsBusy)return false;
            IsBusy = true;
            try
            {
                MyUser.UserName = pUserName;
                MyUser.UserPassword = pPassword;

                bool R = await MyUser.ValidateLogin();
                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

       
    }
}
