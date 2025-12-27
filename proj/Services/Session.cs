using proj.Models.Entities;
using System.Linq;

namespace proj.Services
{

    public static class Session
    {
        public static User? CurrentUser { get; set; }

        public static bool HasRole(string roleName)
        {
            return CurrentUser?.UserRoles
                .Any(r => r.Role.RoleName == roleName) ?? false;
        }
    }
}
