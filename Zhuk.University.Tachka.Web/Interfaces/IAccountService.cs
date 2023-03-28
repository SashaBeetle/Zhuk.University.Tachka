using System.Security.Claims;
using Zhuk.University.Tachka.Core.Response;
using Zhuk.University.Tachka.Web.Pages.Account;

namespace Zhuk.University.Tachka.Web.Interfaces
{
    
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginModel model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordModel model);
    }
}

