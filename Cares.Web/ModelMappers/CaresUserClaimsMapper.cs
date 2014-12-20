using System.Security.Claims;
using Cares.Commons;
using Cares.Models.MenuModels;

namespace Cares.Web.ModelMappers
{
    public static class CaresUserClaimsMapper
    {
        /// <summary>
        /// Create Domain License Detail claim
        /// </summary>
        public static Claim CreateFromDomainLicenseDetail(this MenuRight source)
        {
            var claim = new Claim(CaresUserClaims.UserMenu,
                        ClaimHelper.Serialize(
                            new MenuRight
                            {
                                MenuRightId = source.MenuRightId,
                                MenuId = source.MenuId,
                                RoleId = source.RoleId
                            }),
                        typeof(MenuRight).AssemblyQualifiedName);
            return claim;
        }

        /// <summary>
        /// Create Permission key claim
        /// </summary>
        public static string CreatePermissionKey(this MenuRight source)
        {
           return source.Menu.PermissionKey;
        }

        public static MenuRightClaims CreateMenuRightClaims(this MenuRight source)
        {
            return new MenuRightClaims
            {
                MenuRightId = source.MenuRightId,
                MenuId = source.MenuId,
                RoleId = source.RoleId
            };
        }
    }

}
