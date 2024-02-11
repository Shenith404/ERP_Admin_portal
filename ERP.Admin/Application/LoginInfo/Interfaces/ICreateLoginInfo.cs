using Domain.Entities;

namespace Application.LoginInfo.Interfaces
{
    public interface ICreateLoginInfo
    {
        Task<UserLoginInfo> executeAsync(UserLoginInfo userLoginInfo);
    }
}