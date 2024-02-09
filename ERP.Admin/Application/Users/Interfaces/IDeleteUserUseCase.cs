namespace Application.Users.Interfaces
{
    public interface IDeleteUserUseCase
    {
        Task ExecuteAsync(string userId);
    }
}