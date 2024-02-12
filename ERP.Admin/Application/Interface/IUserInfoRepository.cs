using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserInfoRepository
    {
        Task<UserLoginInfo> CreateUserLoginInfoAsync(UserLoginInfo userLoginInfo);
        Task<IEnumerable<UserLoginInfo>> GetAllInfoAsync();
        Task<IEnumerable<UserLoginInfo>> GetAljlInfoAsync();
        Task<IEnumerable<UserLoginInfo>> GetAlgugjgjhgjlInfoAsync();
        Task<IEnumerable<UserLoginInfo>> GetAlgugjdgjhgjlInfoAsync();
        Task<IEnumerable<UserLoginInfo>> GetAlgugjdsgjhgjlInfoAsync();


    }
}
