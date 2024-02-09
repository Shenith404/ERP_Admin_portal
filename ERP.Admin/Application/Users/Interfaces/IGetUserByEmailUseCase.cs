using Domain.Entities;

namespace Application.Users.UseCases
{
    public interface IGetUserByEmailUseCase
    {
        Task<User> ExecuteAsync(string email);
    }
}