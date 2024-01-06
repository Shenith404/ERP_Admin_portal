using Application.Interface;
using Application.Users.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.UseCases
{
    public class EditUserUseCase : IEditUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public EditUserUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task ExcuteAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
