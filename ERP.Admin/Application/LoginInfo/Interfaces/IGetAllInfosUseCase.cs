using Domain.Entities;

namespace Application.LoginInfo.Interfaces
{
    public interface IGetAllInfosUseCase
    {
        Task<IEnumerable<UserLoginInfo>> ExecuteAsync();
    }
}