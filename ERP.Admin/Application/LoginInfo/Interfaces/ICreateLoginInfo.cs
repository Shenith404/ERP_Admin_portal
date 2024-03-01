using Domain.Entities;

namespace Application.LoginInfo.Interfaces
{
    public interface ICreateLoginInfo
    {
        Task<Domain.Entities.LoginInfo> executeAsync(Domain.Entities.LoginInfo userLoginInfo);
    }
}