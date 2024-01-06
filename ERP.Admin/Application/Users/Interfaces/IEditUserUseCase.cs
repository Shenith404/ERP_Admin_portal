using Domain.Entities;

namespace Application.Users.Interfaces
{
    public interface IEditUserUseCase
    {
        Task ExcuteAsync(User user);
    }
}