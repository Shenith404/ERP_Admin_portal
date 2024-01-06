using Domain.Entities;

namespace Application.Users.Interfaces
{
    public interface IAddUserUseCase
    {
        Task<User> ExcuteAsync(User user);
    }
}