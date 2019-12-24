using Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public static class UserForGridViewExtension
    {
        public static ApplicationUser ToUser(this UserForGridView user)
        {
            return new ApplicationUser
            {
                Email = user.Email,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName,
                MotherSurname = user.MotherSurname,
                PasswordHash = user.PassWord
            };
        }
    }
}
