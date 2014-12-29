using System.Security.Claims;
using Cares.Commons;
using Cares.Models.DomainModels;
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

        public static MenuRight CreateFrom(this MenuRight source)
        {
            return new MenuRight
            {
                MenuRightId = source.MenuRightId,
                MenuId = source.MenuId,
                RoleId = source.RoleId,
                Menu = source.Menu.CreateFrom()
            };
        }
        /// <summary>
        /// Mapper used for Converting Menu in Menu Right
        /// </summary>
        public static Menu CreateFrom(this Menu source)
        {
            return new Menu
            {
                IsRootItem = source.IsRootItem,
                MenuId = source.MenuId,
                MenuFunction = source.MenuFunction,
                MenuImagePath = source.MenuImagePath,
                MenuKey = source.MenuKey,
                MenuTargetController = source.MenuTargetController,
                MenuTitle = source.MenuTitle,
                ParentItem = source.ParentItem != null ? source.ParentItem.CreateFrom() : null,
                ParentMenuId = source.ParentMenuId,
                PermissionKey = source.PermissionKey,
                SortOrder = source.SortOrder
            };
        }
    }

}
