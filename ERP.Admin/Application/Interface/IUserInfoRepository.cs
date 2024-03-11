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
        Task<Domain.Entities.LoginInfo> CreateUserLoginInfoAsync(Domain.Entities.LoginInfo userLoginInfo);
        Task<IEnumerable<Domain.Entities.LoginInfo>> GetAllInfoAsync();
      


    }
}
