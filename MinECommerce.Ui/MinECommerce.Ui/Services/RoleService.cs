using Microsoft.AspNetCore.Identity;
using MinECommerce.Service.Dtos;
using MinECommerce.Ui.Data;
using MinECommerce.Ui.IServices;
using System.Data;
using System.Xml.Linq;

namespace MinECommerce.Ui.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserContext _userContext;

        public RoleService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void AddToRole(string userId, string roleId)
        {
            IdentityUserRole<string> role = new()
            {
                RoleId = roleId,
                UserId = userId
            };
            _userContext.UserRoles.Add(role);
            _userContext.SaveChanges();
        }
        
        public void Create()
        {
            if (!_userContext.Roles.Any())
            {
                List<IdentityRole> identityRoles = new List<IdentityRole>();
                #region roles
                IdentityRole identityRole0 = new()
                {
                    Name = "SysAdmin",
                    NormalizedName = "SysAdmin"
                };
                IdentityRole identityRole1 = new()
                {
                    Name = "Admin",
                    NormalizedName = "Admin"
                };
                IdentityRole identityRole2 = new()
                {
                    Name = "Customer",
                    NormalizedName = "Customer"
                };
                #endregion
                identityRoles.Add(identityRole0);
                identityRoles.Add(identityRole1);
                identityRoles.Add(identityRole2);
                _userContext.Roles.AddRange(identityRoles);
                _userContext.SaveChanges();
            }
        }

        public IdentityRole<string> FindByName(string id)
        {
            var result = _userContext.Roles.FirstOrDefault(x => x.Id == id);
            if (result != null)
                return result;
            return new IdentityRole<string>();
        }

        public List<IdentityRole> GetRoles()
        {
            var result = _userContext.Roles.ToList();
            if (result != null)
                return result;
            return new List<IdentityRole>();
        }
    }
}