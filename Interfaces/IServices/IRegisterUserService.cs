using Cares.Models.IdentityModels.ViewModels;

namespace Cares.Interfaces.IServices
{
    public interface IRegisterUserService
    {
        /// <summary>
        /// User Model
        /// </summary>
        double AddLicenseDetail(RegisterViewModel userModel);
    }
}
