using Application.Interface;
using Application.Users.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.UseCases
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> ExecuteAsync(Guid userId)
        {
            return await _userRepository.GetUserById(userId);
        }



    }
}
