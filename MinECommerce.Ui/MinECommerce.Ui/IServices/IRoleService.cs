using Microsoft.AspNetCore.Identity;

namespace MinECommerce.Ui.IServices
{
    public interface IRoleService
    {
        void Create();
        IdentityRole<string> FindByName(string name);
        void AddToRole(string userId, string roleId);
        List<IdentityRole> GetRoles();
    }
}
