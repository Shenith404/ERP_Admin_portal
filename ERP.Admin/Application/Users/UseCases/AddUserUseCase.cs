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
    public class AddUserUseCase : IAddUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public AddUserUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<User> ExcuteAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
            return user;
        }
    }
}
