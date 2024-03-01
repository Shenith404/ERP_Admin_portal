using Application.Interface;
using Application.LoginInfo.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LoginInfo.UseCases
{
    public class CreateLoginInfo : ICreateLoginInfo
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public CreateLoginInfo(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task<Domain.Entities.LoginInfo> executeAsync(Domain.Entities.LoginInfo userLoginInfo)
        {

            return await _userInfoRepository.CreateUserLoginInfoAsync(userLoginInfo);
        }
    }
}
