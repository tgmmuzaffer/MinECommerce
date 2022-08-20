using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MinECommerce.Context;
using MinECommerce.Entity;
using MinECommerce.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinECommerce.Service.Services
{
    public class CreateDefaultUser : ICreateDefaultUser
    {
        private readonly UserContext _userContext;
        private readonly UserManager<MinECommerceUiUser> _userManager;
        private readonly IUserStore<MinECommerceUiUser> _userStore;
        private readonly IUserEmailStore<MinECommerceUiUser> _emailStore;

        public CreateDefaultUser(UserContext userContext,UserManager<MinECommerceUiUser> userManager, IUserStore<MinECommerceUiUser> userStore )
        {
            _userContext = userContext;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        public async Task CreateDefUser()
        {
            bool userExist = _userContext.Users.Any();
            if (!userExist)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, "a@a.com", CancellationToken.None);
                await _emailStore.SetEmailAsync(user, "a@a.com", CancellationToken.None);
                await _userManager.CreateAsync(user, "_k2udQ.XfR*XmuP");
            }

        }
        private MinECommerceUiUser CreateUser()
        {
            try
            {
                var a = Activator.CreateInstance<MinECommerceUiUser>();
                return a;
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(MinECommerceUiUser)}'. " +
                    $"Ensure that '{nameof(MinECommerceUiUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<MinECommerceUiUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<MinECommerceUiUser>)_userStore;
        }
    }
}
