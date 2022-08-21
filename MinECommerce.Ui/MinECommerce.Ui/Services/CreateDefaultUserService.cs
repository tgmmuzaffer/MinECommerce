using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MinECommerce.Context;
using MinECommerce.Entity;
using MinECommerce.Ui;
using MinECommerce.Ui.Areas.Identity.Data;
using MinECommerce.Ui.Data;
using MinECommerce.Ui.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Ui.Services
{
    public class CreateDefaultUserService : ICreateDefaultUserService
    {
        private readonly UserContext _userContext;

        public CreateDefaultUserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void CreateDefUser()
        {
            if (!_userContext.Users.Any())
            {
                List<MinECommerceUiUser> dummyUsers = new List<MinECommerceUiUser>();
                //şifre: _k2udQ.XfR*XmuP
                #region dummyData
                MinECommerceUiUser minECommerceUiUser0 = new MinECommerceUiUser();
                minECommerceUiUser0.UserName = "a@a.com";
                minECommerceUiUser0.NormalizedUserName = minECommerceUiUser0.UserName.ToUpper();
                minECommerceUiUser0.Email = minECommerceUiUser0.UserName;
                minECommerceUiUser0.NormalizedEmail = minECommerceUiUser0.NormalizedUserName;
                minECommerceUiUser0.EmailConfirmed = false;
                minECommerceUiUser0.PasswordHash = "AQAAAAEAACcQAAAAEFSmPQPyfVdp91HBjmO6FhqEhu6KKcFK8643SSJvZ3mvvFQaHAPE3KHZaDsqfslKjw==";
                minECommerceUiUser0.SecurityStamp = "O5FUFJASMXBCY2TY66H6LRDCLTK6R4P5";
                minECommerceUiUser0.PhoneNumber = String.Empty;
                minECommerceUiUser0.PhoneNumberConfirmed = false;
                minECommerceUiUser0.TwoFactorEnabled = false;
                minECommerceUiUser0.LockoutEnabled = true;
                minECommerceUiUser0.AccessFailedCount = 0;

                MinECommerceUiUser minECommerceUiUser1 = new MinECommerceUiUser();
                minECommerceUiUser1.UserName = "b@b.com";
                minECommerceUiUser1.NormalizedUserName = minECommerceUiUser1.UserName.ToUpper();
                minECommerceUiUser1.Email = minECommerceUiUser1.UserName;
                minECommerceUiUser1.NormalizedEmail = minECommerceUiUser1.NormalizedUserName;
                minECommerceUiUser1.EmailConfirmed = false;
                minECommerceUiUser1.PasswordHash = "AQAAAAEAACcQAAAAEFSmPQPyfVdp91HBjmO6FhqEhu6KKcFK8643SSJvZ3mvvFQaHAPE3KHZaDsqfslKjw==";
                minECommerceUiUser1.SecurityStamp = "O5FUFJASMXBCY2TY66H6LRDCLTK6R4P5";
                minECommerceUiUser1.PhoneNumber = String.Empty;
                minECommerceUiUser1.PhoneNumberConfirmed = false;
                minECommerceUiUser1.TwoFactorEnabled = false;
                minECommerceUiUser1.LockoutEnabled = true;
                minECommerceUiUser1.AccessFailedCount = 0;

                MinECommerceUiUser minECommerceUiUser2 = new MinECommerceUiUser();
                minECommerceUiUser2.UserName = "c@c.com";
                minECommerceUiUser2.NormalizedUserName = minECommerceUiUser2.UserName.ToUpper();
                minECommerceUiUser2.Email = minECommerceUiUser2.UserName;
                minECommerceUiUser2.NormalizedEmail = minECommerceUiUser2.NormalizedUserName;
                minECommerceUiUser2.EmailConfirmed = false;
                minECommerceUiUser2.PasswordHash = "AQAAAAEAACcQAAAAEFSmPQPyfVdp91HBjmO6FhqEhu6KKcFK8643SSJvZ3mvvFQaHAPE3KHZaDsqfslKjw==";
                minECommerceUiUser2.SecurityStamp = "O5FUFJASMXBCY2TY66H6LRDCLTK6R4P5";
                minECommerceUiUser2.PhoneNumber = String.Empty;
                minECommerceUiUser2.PhoneNumberConfirmed = false;
                minECommerceUiUser2.TwoFactorEnabled = false;
                minECommerceUiUser2.LockoutEnabled = true;
                minECommerceUiUser2.AccessFailedCount = 0;
                #endregion
                dummyUsers.Add(minECommerceUiUser0);
                dummyUsers.Add(minECommerceUiUser1);
                dummyUsers.Add(minECommerceUiUser2);
                _userContext.Users.AddRange(dummyUsers);
                _userContext.SaveChanges();
            }


        }
    }
}
