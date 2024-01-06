using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
        Task <IEnumerable<User>> GeAllUsersAsync(string name);
        Task<bool> ExitUserAsync(string name);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);    
        Task DeleteUserAsync(Guid id);

    }
}
