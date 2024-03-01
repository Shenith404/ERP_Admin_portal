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
    public class GetAllInfosUseCase : IGetAllInfosUseCase
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public GetAllInfosUseCase(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task<IEnumerable<Domain.Entities.LoginInfo>> ExecuteAsync()
        {
            return await _userInfoRepository.GetAllInfoAsync();
        }
    }
}
