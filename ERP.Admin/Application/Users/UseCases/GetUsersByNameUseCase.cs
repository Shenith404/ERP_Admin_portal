using Application.Interface;
using Application.Users.Interfaces;
using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.UseCases
{


    public class GetUsersByNameUseCase : IGetUsersByNameUseCase
    {
        public readonly IUserRepository _userRepository;

        public GetUsersByNameUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ExecuteAsync(string name = " ")
        {
            return await _userRepository.GeAllUsersAsync(name);
        }
    }
}
