using Domain.Entities;

namespace Application.Users.Interfaces
{
    public interface IGetUsersByNameUseCase
    {
        Task<IEnumerable<User>> ExecuteAsync(string name = " ");
    }
}